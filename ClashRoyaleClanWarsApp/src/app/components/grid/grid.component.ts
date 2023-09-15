import {Component, Input, OnInit} from '@angular/core';
import {ColumnType, IColumn} from "./IColumn";

@Component({
  selector: 'clash-grid',
  templateUrl: './grid.component.html',
  styleUrls: ['./grid.component.scss']
})

export class GridComponent {
  @Input() data: any[] = []
  @Input() columns: IColumn[] = []
  protected readonly ColumnType = ColumnType;
  protected readonly scroll = scroll;
}
