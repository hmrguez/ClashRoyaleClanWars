import { Component } from '@angular/core';
import {ColumnType, IColumn} from "./components/grid/IColumn";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  columns: IColumn[] = [
    { header: 'ID', field: 'id', type: ColumnType.General },
    { header: 'Name', field: 'name', type: ColumnType.General },
    { header: 'Age', field: 'age', type: ColumnType.General },
    {
      header: 'Gender',
      field: 'gender',
      type: ColumnType.Enum,
      enumColors: new Map<string, string>([
        ['Male', 'blue'],
        ['Female', 'pink'],
      ]),
    },
    { header: 'Country', field: 'country', type: ColumnType.General },
    {
      header: 'Status',
      field: 'status',
      type: ColumnType.Enum,
      enumColors: new Map<string, string>([
        ['Active', 'green'],
        ['Inactive', 'red'],
      ]),
    },
    { header: 'Avatar', field: 'avatar', type: ColumnType.Image },
  ];

sampleData: any[] = [
    {id: 1, name: 'John Doe', age: 30, gender: 'Male', country: 'USA', status: 'Active'}, {

    id: 2,
    name: 'Alice Johnson',
    age: 25,
    gender: 'Female',
    country: 'Canada',
    status: 'Inactive',
  }, {
    id: 3,
    name: 'Bob Smith',
    age: 35,
    gender: 'Male',
    country: 'UK',
    status: 'Active',
  }, {
    id: 4,
    name: 'Eva Martinez',
    age: 28,
    gender: 'Female',
    country: 'Spain',
    status: 'Active',
  }, {
    id: 5,
    name: 'Michael Brown',
    age: 40,
    gender: 'Male',
    country: 'Australia',
    status: 'Inactive',
  }, {
    id: 6,
    name: 'Sophia Lee',
    age: 22,
    gender: 'Female',
    country: 'South Korea',
    status: 'Active',
  }, {
    id: 7,
    name: 'David Wilson',
    age: 45,
    gender: 'Male',
    country: 'Canada',
    status: 'Active',
  }, {
    id: 8,
    name: 'Olivia Davis',
    age: 29,
    gender: 'Female',
    country: 'USA',
    status: 'Inactive',
  }, {
    id: 9,
    name: 'Liam Taylor',
    age: 33,
    gender: 'Male',
    country: 'UK',
    status: 'Active',
  }, {
    id: 10,
    name: 'Emma Smith',
    age: 27,
    gender: 'Female',
    country: 'Australia',
    status: 'Active',
  }, {
    id: 11,
    name: 'Mia Johnson',
    age: 31,
    gender: 'Female',
    country: 'USA',
    status: 'Active',
  },];
}
