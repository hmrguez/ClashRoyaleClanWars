The way to work with the gris is simple
1. You need to fetch the data you want to have in the table. Let that be `myData` of type any[]
2. Create an IColumn array which is an interface with the following signature

```typescript
export interface IColumn {
  header: string // The display value for the column
  field: string // The name of the property of the object
  type: ColumnType // Types are mentioned below, everything that's not an Enum, Image or Boolean is just General
  
  // These 2 values are nullable because are only filled if the column is of enum type
  
  // This represents the hexadecimal collors assign to each enum value
  enumColors?: Map<string, string>
  
  // This represents the items that will be used in the dropdown selection list for the filtering
  enumOptions?: SelectItem[]
}

export enum ColumnType{
  General,
  Enum,
  Image,
  Boolean
}
```

For example. If you have people and want to create the Gender column it would go like this

```typescript
const genderColumn: IColumn = {
  header: 'Gender',
  field: 'gender',
  type: ColumnType.Enum,
  enumColors: new Map<string, string>([
    ['Male', 'blue'],
    ['Female', 'pink'],
  ]),
  enumOptions: [
    <SelectItem>{label: 'Male', value: 'Male'},
    <SelectItem>{label: 'Female', value: 'Female'}
  ]
}
```

3. After both the data and columns are fetched or created. You need to instantiate the component

```angular2html
<clash-grid [columns]="columns"
            [data]="sampleData"
            [adminUser]="true"
            [title]="'Citizens'"
            [createFunc]="createFunc"
            [updateFunc]="updateFunc"
            [deleteFunc]="deleteFunc"
></clash-grid>

```

adminUser is a boolean that should reflect that the user has access to create, edit and delete data

All three functions are functions that the first argument is the model and are interacted when deleting, creating and updating data

4. Enjoy!!!

5. Complains are attended by (Hector Rodriguez)[zealot.algo@gmail.com]
