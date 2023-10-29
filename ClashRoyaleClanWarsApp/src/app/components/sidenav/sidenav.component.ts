import {Component, EventEmitter, HostListener, OnInit, Output} from '@angular/core';
import { TokenStorageService } from '../../services/token-storage.service';



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
  isLoggedIn = false;
  navData :any;

  constructor(private tokenStorage: TokenStorageService) { 
    this.isLoggedIn = !!this.tokenStorage.getToken();

    this.navData = [
      {
        routeLink: "/",
        icon: "pi pi-home",
        label: "Home",
      },
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
      routeLink: "/faq",
      icon: "pi pi-question-circle",
      label: "FAQ",
    },
    {
      routeLink: "/graph",
      icon: "pi pi-chart-bar",
      label: "Graph",
    }
  ]

    if (this.isLoggedIn) {
      const user = this.tokenStorage.getUser();
      this.navData.push({
        routeLink: "/profile",
        icon: "pi pi-user",
        label: user.username,
      })
    }
    else {
      this.navData.push({
        routeLink: "/login",
        icon: "pi pi-user-plus",
        label: "Sign Up",
      })
    }
  }

 

  // navData: any = [
  //   {
  //     routeLink: "/players",
  //     icon: "pi pi-user",
  //     label: "Players",
  //   },
  //   {
  //     routeLink: "/cards",
  //     icon: "pi pi-id-card",
  //     label: "Cards",
  //   },
  //   {
  //     routeLink: "/clans",
  //     icon: "pi pi-sitemap",
  //     label: "Clans",
  //   },
  //   {
  //     routeLink: "/login",
  //     icon: "pi pi-user-plus",
  //     label: "Sign Up",
  //   }

  // ];

  

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
