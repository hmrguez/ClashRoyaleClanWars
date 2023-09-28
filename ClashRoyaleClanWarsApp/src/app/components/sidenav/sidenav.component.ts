import {Component, EventEmitter, HostListener, OnInit, Output} from '@angular/core';


interface SideNavToggle {
  screenWidth: number;
  collapsed: boolean;
}

@Component({
  selector: 'app-sidenav',
  templateUrl: './sidenav.component.html',
  styleUrls: ['./sidenav.component.scss']
})
export class SidenavComponent implements OnInit {

  @Output() onToggleSideNav: EventEmitter<SideNavToggle> = new EventEmitter<SideNavToggle>()

  collapsed = false;
  screenWidth: number = 0;

  navData: any = [
    {
      routeLink: "/players",
      icon: "pi pi-user",
      label: "Players",
    },
    {
      routeLink: "/cards",
      icon: "pi pi-id-card",
      label: "Cards",
    },
    {
      routeLink: "/clans",
      icon: "pi pi-sitemap",
      label: "Clans",
    },
    {
      routelink: "/log-in",
      icon: "pi pi-user-plus",
      label: "Sign Up",
    }

  ];

  @HostListener('window:resize', ['$event'])
  onResize() {
    this.screenWidth = window.innerWidth;
    if (this.screenWidth <= 768) {
      this.collapsed = false;
      this.onToggleSideNav.emit({screenWidth: this.screenWidth, collapsed: this.collapsed})
    }
  }

  toggleCollapse() {
    this.collapsed = !this.collapsed;
    this.onToggleSideNav.emit({screenWidth: this.screenWidth, collapsed: this.collapsed})
  }

  closeNavbar() {
    this.collapsed = false;
    this.onToggleSideNav.emit({screenWidth: this.screenWidth, collapsed: this.collapsed})
  }

  ngOnInit(): void {
    this.screenWidth = window.innerWidth;
  }
}
