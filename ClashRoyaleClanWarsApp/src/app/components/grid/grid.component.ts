import {Component, Input, OnInit, ViewChild} from '@angular/core';
import {ColumnType, IColumn} from "./IColumn";
import {Table} from "primeng/table";

@Component({
  selector: 'clash-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})

export class GridComponent implements OnInit{
  @Input() data: any[] = []
  @Input() columns: IColumn[] = []
  @ViewChild('dt1') table!: Table
  protected readonly ColumnType = ColumnType;
  filterFields: string[] = [];
  globalFilter: string = ''

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
}
