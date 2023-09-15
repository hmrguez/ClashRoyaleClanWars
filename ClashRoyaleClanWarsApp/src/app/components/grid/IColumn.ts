import {SelectItem} from "primeng/api";

export interface IColumn {
  header: string
  field: string
  type: ColumnType
  enumColors?: Map<string, string>
  enumOptions?: SelectItem[]
}

export enum ColumnType{
  General,
  Enum,
  Image,
  Boolean
}
