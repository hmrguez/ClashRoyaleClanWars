export interface IColumn {
  header: string
  field: string
  type: ColumnType
  enumColors?: Map<string, string>
}

export enum ColumnType{
  General,
  Enum,
  Image
}
