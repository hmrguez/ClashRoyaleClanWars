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
