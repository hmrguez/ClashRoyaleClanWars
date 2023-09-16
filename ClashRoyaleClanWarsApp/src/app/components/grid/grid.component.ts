import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {ColumnType, IColumn} from "./IColumn";
import {Table} from "primeng/table";
import * as FileSaver from 'file-saver';
import jsPDF from 'jspdf'
import autoTable from 'jspdf-autotable'

@Component({
  selector: 'clash-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})

export class GridComponent implements OnInit{
  @Input() title: string = '';
  @Input() data: any[] = [];
  @Input() columns: IColumn[] = [];
  @ViewChild('dt') table!: Table;

  @Input() adminUser: boolean = false
  @Input() createFunc!: (model: any) => any
  @Input() deleteFunc!: (model: any) => any
  @Input() updateFunc!: (model: any) => any

  filterFields: string[] = [];
  globalFilter: string = '';
  selectionOnlyExport: boolean = false;
  selectedData: any[] = [];

  visibleDialog: boolean = false
  createEditModel: any = {}

  protected readonly ColumnType = ColumnType;

  ngOnInit(): void {
    this.filterFields = this.columns.map(x=>x.field)
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

  saveAsExcelFile(buffer: any, fileName: string): void {
    let EXCEL_TYPE = 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet;charset=UTF-8';
    let EXCEL_EXTENSION = '.xlsx';
    const data: Blob = new Blob([buffer], {
      type: EXCEL_TYPE
    });
    FileSaver.saveAs(data, fileName + '_export_' + new Date().getTime() + EXCEL_EXTENSION);
  }

  openNew() {
    this.createEditModel = {};
    this.visibleDialog = true;
  }

  openEdit(model: any){
    this.createEditModel = {}
    this.visibleDialog = true
  }

  hideDialog(){
    this.visibleDialog = false;
  }

  deleteSelectedProducts() {
    for (const selectedDatum of this.selectedData) {
      this.deleteFunc(selectedDatum)
    }
  }
}
