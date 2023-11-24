import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { GridComponent } from './components/grid/grid.component';
import { TableModule } from "primeng/table";
import { BadgeModule } from "primeng/badge";
import { ButtonModule } from "primeng/button";
import { RippleModule } from "primeng/ripple";
import {InputTextModule} from "primeng/inputtext";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MultiSelectModule} from "primeng/multiselect";
import {DropdownModule} from "primeng/dropdown";
import {BrowserAnimationsModule} from "@angular/platform-browser/animations";
import {CardModule} from "primeng/card";
import {ToolbarModule} from "primeng/toolbar";
import {InputSwitchModule} from "primeng/inputswitch";
import {TooltipModule} from "primeng/tooltip";
import {DialogModule} from "primeng/dialog";
import {InputTextareaModule} from "primeng/inputtextarea";
import {PaginatorModule} from "primeng/paginator";
import {CheckboxModule} from "primeng/checkbox";
import {CalendarModule} from "primeng/calendar";
import {ContextMenuModule} from "primeng/contextmenu";
import {ToastModule} from "primeng/toast";
import {MessageService} from "primeng/api";
import {LogInComponent } from './components/log-in/log-in.component';
import {SidenavComponent} from "./components/sidenav/sidenav.component";
import {BodyComponent} from "./components/body/body.component";
import { PlayersComponent } from './components/players/players.component';
import { CardsComponent } from './components/cards/cards.component';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import {HttpClient, HttpClientModule, HttpHandler} from "@angular/common/http";
import { ProfileComponent } from './components/profile/profile.component';
import { ClansComponent } from './components/clans/clans.component';
import { FAQComponent } from './components/faq/faq.component';
import { GraphComponent } from './components/graph/graph.component';
import {ChartModule} from "primeng/chart";
import { GalleriaModule } from 'primeng/galleria';
import { DividerModule } from 'primeng/divider';
import { FirstQueryComponent } from './components/first-query/first-query.component';
import { SecondQueryComponent } from './components/second-query/second-query.component';
import { ThirdQueryComponent } from './components/third-query/third-query.component';
import { FourthQueryComponent } from './components/fourth-query/fourth-query.component';
import { FifthQueryComponent } from './components/fifth-query/fifth-query.component';
import { SixthQueryComponent } from './components/sixth-query/sixth-query.component';
import { QueryViewerComponent } from './components/query-viewer/query-viewer.component';
import { AccordionModule } from 'primeng/accordion';
import { InputNumberModule } from 'primeng/inputnumber';
import { AnalyticsComponent } from './components/analytics/analytics.component';
import { DragDropModule } from 'primeng/dragdrop';
import { RatingModule } from 'primeng/rating';
import { ListboxModule } from 'primeng/listbox';
import { BattlesComponent } from './components/battles/battles.component';
import { CardPopularityComponent } from './components/card-popularity/card-popularity.component';
import { SelectButtonModule } from 'primeng/selectbutton';
import { ClanPopComponent } from './components/clan-pop/clan-pop.component';
import { UsersComponent } from './components/users/users.component';






@NgModule({
  declarations: [
    AppComponent,
    GridComponent,
    LogInComponent,
    SidenavComponent,
    BodyComponent,
    PlayersComponent,
    CardsComponent,
    DashboardComponent,
    ProfileComponent,
    ClansComponent,
    FAQComponent,
    GraphComponent,
    FirstQueryComponent,
    SecondQueryComponent,
    ThirdQueryComponent,
    FourthQueryComponent,
    FifthQueryComponent,
    SixthQueryComponent,
    QueryViewerComponent,
    AnalyticsComponent,
    BattlesComponent,
    CardPopularityComponent,
    ClanPopComponent,
    UsersComponent,
   
   

  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    AppRoutingModule,
    TableModule,
    BadgeModule,
    ButtonModule,
    RippleModule,
    InputTextModule,
    FormsModule,
    MultiSelectModule,
    DropdownModule,
    CardModule,
    ToolbarModule,
    InputSwitchModule,
    TooltipModule,
    DialogModule,
    InputTextareaModule,
    PaginatorModule,
    CheckboxModule,
    CalendarModule,
    ReactiveFormsModule,
    ContextMenuModule,
    ToastModule,
    HttpClientModule,
    ChartModule,
    GalleriaModule,
    DividerModule,
    AccordionModule,
    InputNumberModule,
    DragDropModule,
    RatingModule,
    ListboxModule,
    SelectButtonModule
  ],
  providers: [MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
