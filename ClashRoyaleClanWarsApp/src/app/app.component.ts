import { Component, OnInit } from '@angular/core';
import {ColumnType, IColumn} from "./components/grid/IColumn";
import {SelectItem} from "primeng/api";
import {of} from "rxjs";
import { TokenStorageService } from './services/token-storage.service';


@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent implements OnInit {
  sampleData: any;
  columns: any;

  private roles: string[] = [];
  isLoggedIn = false;
  isAdmin = false;
  username?: string;

  constructor(private tokenStorageService: TokenStorageService) {
    // this.sampleData = [
    //   {
    //     stringField: "Sample 1",
    //     numberField: 123,
    //     listField: [
    //       { subStringField1: "Item 1.1", subStringField2: "Item 1.2" },
    //       { subStringField1: "Item 2.1", subStringField2: "Item 2.2" },
    //     ],
    //   },
    //   {
    //     stringField: "Sample 2",
    //     numberField: 456,
    //     listField: [
    //       { subStringField1: "Item 3.1", subStringField2: "Item 3.2" },
    //       { subStringField1: "Item 4.1", subStringField2: "Item 4.2" },
    //     ],
    //   },
    //   {
    //     stringField: "Sample 3",
    //     numberField: 789,
    //     listField: [
    //       { subStringField1: "Item 5.1", subStringField2: "Item 5.2" },
    //       { subStringField1: "Item 6.1", subStringField2: "Item 6.2" },
    //     ],
    //   },
    //   {
    //     stringField: "Sample 4",
    //     numberField: 101112,
    //     listField: [
    //       { subStringField1: "Item 7.1", subStringField2: "Item 7.2" },
    //       { subStringField1: "Item 8.1", subStringField2: "Item 8.2" },
    //     ],
    //   },
    // ];

    // this.columns = [
    //   {
    //     header: "String Column",
    //     field: "stringField",
    //     type: ColumnType.String,
    //   },
    //   {
    //     header: "Number Column",
    //     field: "numberField",
    //     type: ColumnType.Number,
    //   },
    //   {
    //     header: "List Column",
    //     field: "listField",
    //     type: ColumnType.List,
    //     listColumns: [
    //       {
    //         header: "Sub String Column 1",
    //         field: "subStringField1",
    //         type: ColumnType.String,
    //       },
    //       {
    //         header: "Sub String Column 2",
    //         field: "subStringField2",
    //         type: ColumnType.String,
    //       },
    //     ],
    //   },
    // ];
  }



  isSideNavCollapsed = false;
  screenWidth: number = 0;

  onToggleSideNav(data: SideNavToggle) {
    this.screenWidth = data.screenWidth;
    this.isSideNavCollapsed = data.collapsed;
  }

  ngOnInit(): void {
      this.isLoggedIn = !!this.tokenStorageService.getToken();

      if (this.isLoggedIn) {
        const user = this.tokenStorageService.getUser();
        this.roles = user.roles;

        this.isAdmin = this.roles.includes('ROLE_ADMIN');
        this.username = user.username;
      }
  }
  
  logout(): void {
    this.tokenStorageService.signOut();
    window.location.reload();
  }

}

interface SideNavToggle{
  screenWidth: number;
  collapsed: boolean;
}
