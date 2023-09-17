import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {ColumnType, IColumn} from "./IColumn";
import {Table} from "primeng/table";
import * as FileSaver from 'file-saver';
import jsPDF from 'jspdf'
import autoTable from 'jspdf-autotable'
import {FormControl, FormGroup, NgForm, Validators} from "@angular/forms";
import {CrudService} from "../../services/CrudService";
import {Observable} from "rxjs";
import {MenuItem, MessageService} from "primeng/api";
import {Route, Router} from "@angular/router";

@Component({
  selector: 'clash-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})

export class GridComponent implements OnInit{
  @Input() title: string = '';
  @Input() columns: IColumn[] = [];
  @Input() primaryKey: string = '';
  @Input() detailPage: string = ''
  @ViewChild('dt') table!: Table;

  @Input() dataService!: CrudService<any>;
  @Input() adminUser: boolean = false;
  @Input() customFetchDataFunc!: () => Observable<any[]>

  data: any[] = []

  filterFields: string[] = [];
  globalFilter: string = '';
  selectionOnlyExport: boolean = false;
  selectedData: any[] = [];

  @ViewChild('myForm', { static: false }) myForm!: NgForm;
  createEditForm!: FormGroup;
  visibleDialog: boolean = false
  isCreating: boolean = false; // true for creating and false for editing

  menuItems: MenuItem[] = [];
  selectedDatum: any;

  protected readonly ColumnType = ColumnType;

  constructor(private router: Router, private messageService: MessageService) { }

  ngOnInit(): void {
    this.loadData().then();
    this.createFormModel();
    this.filterFields = this.columns.map(x=>x.field)

    this.menuItems = [
      { label: 'View ', visible: this.detailPage != '', icon: 'pi pi-fw pi-search', command: () => this.viewContextMenuAction()},
      { label: 'Delete', visible: this.adminUser, icon: 'pi pi-fw pi-times', command: () => this.deleteContextMenuAction()},
      { label: 'Edit', visible: this.adminUser, icon: 'pi pi-fw pi-pencil', command: () => this.editContextMenuAction()},
    ]
  }

  private async loadData() {
    const fetchData = this.customFetchDataFunc ? this.customFetchDataFunc() : this.dataService.getAll();
    fetchData.subscribe({
        next: (v) => this.data = v,
        error: (e) => console.log(e)
      }
    )
  }

  filterData() {
    this.table.filterGlobal(this.globalFilter, 'contains')
  }

  clear() {
    this.table.clear();
    this.globalFilter = ''
  }


  exportPdf() {
    const doc = new jsPDF()
    const exportData = this.selectionOnlyExport ? this.selectedData : this.data
    const body = exportData.map(item => Object.values(item).map(y=>String(y)))

    autoTable(doc, {
      head: [this.columns.map(x=>x.header)],
      body: body
    })

    doc.save('table.pdf')
  }

  exportExcel() {
    import("xlsx").then(xlsx => {
      const worksheet = xlsx.utils.json_to_sheet(this.selectionOnlyExport ? this.selectedData : this.data);
      const workbook = { Sheets: { 'data': worksheet }, SheetNames: ['data'] };
      const excelBuffer: any = xlsx.write(workbook, { bookType: 'xlsx', type: 'array' });
      this.saveAsExcelFile(excelBuffer, "data");
    });
  }

  private saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  }

  openNew() {
    this.createFormModel()
    this.visibleDialog = true;
    this.isCreating = true;
  }

  openEdit(model: any){
    this.createFormModel(model)
    this.visibleDialog = true
    this.isCreating = false;
  }

  hideDialog(){
    this.visibleDialog = false;
  }

  deleteSelectedProducts() {
    for (const selectedDatum of this.selectedData) {
      this.dataService.delete(selectedDatum[this.primaryKey]).subscribe({
        next: () => this.messageService.add({severity:'success', summary: this.title + ' deleted'}),
        error: () => this.messageService.add({severity: 'danger', summary: 'Error', detail: 'Error while deleting data. Try again later'})
      })
    }

    this.loadData().then()
  }

  saveProduct() {
    if(!this.createEditForm.valid) return;
    const model = this.createEditForm.value
    if(this.isCreating){
      this.dataService.create(model).subscribe({
        next: () => {
          this.messageService.add({severity: 'success', summary: 'Created ' + this.title})
          this.loadData().then()
        },
        error: () => {
          this.messageService.add({severity: 'danger', summary: 'Error', detail: 'Error while creating ' + this.title + '. Try again later'})
        }
      })
    } else {
      this.dataService.update(model[this.primaryKey], model).subscribe({
        next: () => {
          this.messageService.add({severity: 'success', summary: 'Updated ' + this.title})
          this.loadData().then()
        },
        error: () => {
          this.messageService.add({severity: 'danger', summary: 'Error', detail: 'Error while updating ' + this.title + '. Try again later'})
        }
      })
    }

    this.hideDialog()
  }

  private createFormModel(model: any = null){
    const formControls: { [key: string]: FormControl } = {};

    this.columns.forEach((column) => {
      switch (column.type){
        case ColumnType.String:
          formControls[column.field] = new FormControl(model?.[column.field] ?? '', Validators.required);
          break;
        case ColumnType.LargeString:
          formControls[column.field] = new FormControl(model?.[column.field] ?? '', Validators.required);
          break;
        case ColumnType.Image:
          formControls[column.field] = new FormControl(model?.[column.field] ?? '', Validators.required);
          break;
        case ColumnType.Number:
          formControls[column.field] = new FormControl(model?.[column.field] ?? 0, Validators.required);
          break;
        case ColumnType.Boolean:
          formControls[column.field] = new FormControl(model?.[column.field] ?? false, Validators.required);
          break;
        case ColumnType.Date:
          formControls[column.field] = new FormControl(model?.[column.field] ?? new Date(), Validators.required);
          break;
        case ColumnType.Enum:
          formControls[column.field] = new FormControl(model?.[column.field] ?? column.enumOptions?.[0].value, Validators.required);
          break;
        default:
          throw new Error(`No supported type, ${column.type}`)
      }
    });

    this.createEditForm = new FormGroup(formControls);
  }

  viewContextMenuAction(){
    this.router.navigate([this.detailPage + "/" + this.selectedDatum[this.primaryKey]]).then()
  }

  private deleteContextMenuAction() {
    this.dataService.delete(this.selectedDatum[this.primaryKey]).subscribe({next: this.loadData})
  }

  private editContextMenuAction() {
    this.openEdit(this.selectedDatum)
  }
}
