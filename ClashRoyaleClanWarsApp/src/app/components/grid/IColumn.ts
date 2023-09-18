import {SelectItem} from "primeng/api";

export interface IColumn {
  header: string
  field: string
  type: ColumnType
  enumColors?: Map<string, string>
  enumOptions?: SelectItem[]
  listColumns?: IColumn[]
}

export enum ColumnType{
  String,
  LargeString,
  Number,
  Date,
  Enum,
  Image,
  Boolean,
  List
}
