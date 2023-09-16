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


@NgModule({
  declarations: [
    AppComponent,
    GridComponent
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
    ReactiveFormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
