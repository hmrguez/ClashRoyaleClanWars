import {Component} from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import {PlayerService} from "./player.service";
import { IPlayerDto } from './IPlayerDto';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { MessageService } from 'primeng/api';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { ViewChild } from '@angular/core';
import { GridComponent } from '../grid/grid.component';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {

  @ViewChild("grid") grid: GridComponent = {} as GridComponent;

  columns: IColumn[] = [
    {
      header: 'Alias',
      field: 'alias',
      type: ColumnType.String,
    },
    {
      header: 'Elo',
      field: 'elo',
      type: ColumnType.Number,
    },
    {
      header: 'Level',
      field: 'level',
      type: ColumnType.Number,
    },
    {
      header: 'Victories',
      field: 'victories',
      type: ColumnType.Number,
    },
    {
      header: 'Card Amount',
      field: 'cardAmount',
      type: ColumnType.Number,
    },
    {
      header: 'Max Elo',
      field: 'maxElo',
      type: ColumnType.Number,
    },
  ]

  allPlayers :any[] = []

  is_Admin = false
  visibleAdd = false
  visibleUpdate = false
  visibleDelete = false


  aliasAdd !: string
  eloAdd !: number
  levelAdd !: number

  aliasUp !: string
  eloUp!:number
  levelUp!:number
  selectedUp!: any

  selectedDelete!: any


  constructor(public playerService: PlayerService, private tokens :TokenStorageService, private mess:MessageService, private http:HttpClient) { 
    this.is_Admin = this.tokens.isAdmin() || this.tokens.isSuperAdmin()
    this.playerService.getAll().subscribe((data)=>{
      this.allPlayers=data
      
    })
  }

  showError(message:string){
    this.mess.add({ severity: 'error', summary: 'Error', detail: message });
  }

  showSuccess(message:string){
    this.mess.add({ severity: 'success', summary: 'Success', detail: message });
  }

  showAdd(){
    this.visibleAdd= !this.visibleAdd
    this.visibleUpdate = false
    this.visibleDelete = false
    
  }

  showUpdate(){
    this.visibleUpdate = !this.visibleUpdate
    this.visibleAdd = false
    this.visibleDelete = false
  }

  showDelete(){
    this.visibleDelete = !this.visibleDelete
    this.visibleAdd = false
    this.visibleUpdate = false
  }

  Post(){
    if (!this.eloAdd || !this.levelAdd || !this.aliasAdd){
      this.showError("Fields cannot be empty")
      return
    }

    this.http.post(this.playerService.baseUrl, {'elo':this.eloAdd, 'level':this.levelAdd, 'alias':this.aliasAdd}).subscribe((data)=>{
      this.showSuccess('Player Created')
      this.grid.loadData()
    }, (err)=>{this.showError(err.error)})

  }

  Update(){
    if (!this.eloUp && !this.aliasUp && !this.levelUp){
      this.showError('Not all fields can be empty')
      return
    }

    if (!this.selectedUp){
      this.showError('You need to select a player')
      return
    }

    if(!this.eloUp) this.eloUp = this.selectedUp.elo
    if (!this.aliasUp) this.aliasUp = this.selectedUp.alias
    if (!this.levelUp) this.levelUp = this.selectedUp.level

    var id = this.selectedUp.id

    this.playerService.update(id, {'alias': this.aliasUp, 'elo': this.eloUp, 'level':this.levelUp, 'id': id, 'victories': this.selectedUp.victories,
    'cardAmount': this.selectedUp.cardAmount,  'maxElo': this.selectedUp.maxElo, 'favoriteCard': this.selectedUp.favoriteCard}).subscribe((data)=>{
      this.showSuccess('Updated')
      this.grid.loadData()
    }, (err)=>{
      this.showError(err.error)
    })
  
  }

  Delete(){
    if (!this.selectedDelete){
      this.showError('Select a player to delete')
      return
    }

    var id = this.selectedDelete.id

    this.playerService.delete(id).subscribe((data)=>{
      this.showSuccess('Deleted')
      this.grid.loadData()
    }, (err)=>{
      this.showError(err.error)
    })
  }
    
    
  
 
}
