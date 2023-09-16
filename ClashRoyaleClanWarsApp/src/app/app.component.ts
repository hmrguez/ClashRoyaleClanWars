import { Component } from '@angular/core';
import {ColumnType, IColumn} from "./components/grid/IColumn";
import {SelectItem} from "primeng/api";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  columns: IColumn[] = [
    { header: 'ID', field: 'id', type: ColumnType.Number },
    { header: 'Name', field: 'name', type: ColumnType.LargeString },
    { header: 'Age', field: 'age', type: ColumnType.Number },
    {
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
    },
    { header: 'Country', field: 'country', type: ColumnType.String },
    {
      header: 'Status',
      field: 'status',
      type: ColumnType.Enum,
      enumColors: new Map<string, string>([
        ['Active', 'green'],
        ['Inactive', 'red'],
      ]),
      enumOptions: [
        <SelectItem>{label: 'Active', value: 'Active'},
        <SelectItem>{label: 'Inactive', value: 'Inactive'}
      ]
    },
    { header: 'Verified', field: 'verified', type: ColumnType.Boolean },
  ];

sampleData: any[] = [
    {id: 1, name: 'John Doe', age: 30, gender: 'Male', country: 'USA', status: 'Active', verified: true}, {

    id: 2,
    name: 'Alice Johnson',
    age: 25,
    gender: 'Female',
    country: 'Canada',
    status: 'Inactive', verified: true
  }, {
    id: 3,
    name: 'Bob Smith',
    age: 35,
    gender: 'Male',
    country: 'UK',
    status: 'Active', verified: false
  }, {
    id: 4,
    name: 'Eva Martinez',
    age: 28,
    gender: 'Female',
    country: 'Spain',
    status: 'Active', verified: true
  }, {
    id: 5,
    name: 'Michael Brown',
    age: 40,
    gender: 'Male',
    country: 'Australia',
    status: 'Inactive', verified: false
  }, {
    id: 6,
    name: 'Sophia Lee',
    age: 22,
    gender: 'Female',
    country: 'South Korea',
    status: 'Active', verified: true
  }, {
    id: 7,
    name: 'David Wilson',
    age: 45,
    gender: 'Male',
    country: 'Canada',
    status: 'Active', verified: true
  }, {
    id: 8,
    name: 'Olivia Davis',
    age: 29,
    gender: 'Female',
    country: 'USA',
    status: 'Inactive', verified: true
  }, {
    id: 9,
    name: 'Liam Taylor',
    age: 33,
    gender: 'Male',
    country: 'UK',
    status: 'Active', verified: true
  }, {
    id: 10,
    name: 'Emma Smith',
    age: 27,
    gender: 'Female',
    country: 'Australia',
    status: 'Active', verified: true
  }, {
    id: 11,
    name: 'Mia Johnson',
    age: 31,
    gender: 'Female',
    country: 'USA',
    status: 'Active', verified: true
  },];

  createFunc = (model: any) => console.log(model)
  updateFunc = (model: any) => console.log(model)
  fetchData = () => new Promise<any[]>((resolve, reject) => resolve(this.sampleData))
}
