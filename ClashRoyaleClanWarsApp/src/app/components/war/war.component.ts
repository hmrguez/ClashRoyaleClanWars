import { Component } from '@angular/core';
import { WarService } from './war.service';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { MessageService } from 'primeng/api';
import { War } from './WarDto';
import { ColumnType, IColumn } from '../grid/IColumn';
import { ViewChild } from '@angular/core';
import { GridComponent } from '../grid/grid.component';
import { ClanService } from '../clans/clan.service';


@Component({
  selector: 'app-war',
  templateUrl: './war.component.html',
  styleUrls: ['./war.component.scss']
})
export class WarComponent {

  isAdmin = false
  allClans: any[] = []
  allWars :any[] = []

  @ViewChild('grid') grid :GridComponent = {} as GridComponent

  columns: IColumn[] =[
    
    {
      header: 'StartDate',
      field: 'startDate',
      type: ColumnType.String,
    },
  
]


itemParsingFunction(data:any) : War{
  return {
    id : data.id,
    startDate : data.startDate,
 
  }
}

  constructor(private tokens:TokenStorageService, public warService:WarService, private mess:MessageService, private clanSer: ClanService){
    this.isAdmin = this.tokens.isAdmin() || this.tokens.isSuperAdmin()
    this.clanSer.getAll().subscribe((data)=>{this.allClans=data})
    this.warService.getAll().subscribe((data)=>{this.allWars=data})
  }



  showError(message:string){
    this.mess.add({ severity: 'error', summary: 'Error', detail: message });
  }

  showSuccess(message:string){
    this.mess.add({ severity: 'success', summary: 'Success', detail: message });
  }

  showInsert = false
  dateInsert !: Date

  DisplayInsert(){
    this.showInsert = !this.showInsert
    this.showClanWar = false
  }

  Insert(){
    if (!this.dateInsert){
      this.showError('Need to select a date')
      return
    }

    var body: War = {
      id:1,
      startDate:this.dateInsert.toJSON()
    }

    this.warService.create(body).subscribe((data)=>{
      this.showSuccess('War inserted')
      this.grid.loadData()
      this.warService.getAll().subscribe((data)=>{this.allWars=data})
      
    },(err)=>{
      this.showError('Could not insert \n' + err.error)
    })
  }

  showClanWar =false

  DisplayClanWar(){
    this.showClanWar = !this.showClanWar
    this.showInsert = false
  }

  clanSelected !: any
  warSelected !: any
  prize !: number

  PostClanWar(){
    if (!this.clanSelected){
      this.showError('Need to select a clan')
      return
    }
    if (!this.warSelected){
      this.showError('Need to select a war')
      return
    }
    if (!this.prize){
      this.showError('Need to select a prize')
      return
    }

    var url = this.warService.baseUrl + '/' + this.warSelected.id + '/' + this.clanSelected.id + '?prize=' + this.prize.toString()

    var body={
      id:1,
      //convert now to ISO string
      startDate: new Date().toJSON()
    }

    var base = this.warService.baseUrl
    this.warService.baseUrl = url

    this.warService.create(body).subscribe((data)=>{
      this.showSuccess('Clan Added to War')
      this.warService.baseUrl=base
      this.grid.loadData()
      
    },(err)=>{
      this.showError('Could not insert \n' + err.error)
    })

    this.warService.baseUrl=base
  }

}




