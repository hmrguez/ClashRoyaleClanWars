import { Component, OnInit } from '@angular/core';
import {ClanService} from "./clan.service";
import {ColumnType, IColumn} from "../grid/IColumn";
import { IClanDto } from './IClanDto';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { PlayerService } from '../players/player.service';
import { MessageService } from 'primeng/api';
import { GridComponent } from '../grid/grid.component';
import { ViewChild } from '@angular/core';



@Component({
  selector: 'app-clans',
  templateUrl: './clans.component.html',
  styleUrls: ['./clans.component.scss']
})

export class ClansComponent {
  @ViewChild("grid") grid: GridComponent = {} as GridComponent;


  isAdmin: boolean = false

  isUser = false


  playerSelected!: any



  clanColumns: IColumn[] = [
    {
      header: 'Name',
      field: 'name',
      type: ColumnType.String,
    },
    {
      header: 'Description',
      field: 'description',
      type: ColumnType.String,
    },
    {
      header: 'Region',
      field: 'region',
      type: ColumnType.String,
    },
    {
      header: 'Public',
      field: 'typeOpen',
      type: ColumnType.Boolean,
    },
    {
      header: 'Member Count',
      field: 'amountMembers',
      type: ColumnType.Number,
    },
    {
      header: 'Trophies in wars',
      field: 'trophiesInWar',
      type: ColumnType.Number,
    },
    {
      header: 'Min Trophies',
      field: 'minTrophies',
      type: ColumnType.Number,
    },
  ]

 allClans : any[] = []

  baseUrl !: string
  constructor(public clanService: ClanService, private tokenStorage: TokenStorageService, public playerSer: PlayerService, private mess:MessageService ) { 
    this.isAdmin = this.tokenStorage.isAdmin() || this.tokenStorage.isSuperAdmin()
    this.isUser = !this.isAdmin && !!this.tokenStorage.getToken()
    this.playerSer.getAll().subscribe((data)=>{this.allPlayers=data})
    this.clanService.getAll().subscribe((data)=>{this.allClans=data})
    this.baseUrl = this.clanService.baseUrl
  }


  itemParsingFunction(data: any): IClanDto{
    return {
      id: data.id,
      name: data.name,
      description: data.description,
      region: data.region,
      typeOpen: data.typeOpen,
      amountMembers: data.amountMembers,
      trophiesInWar: data.trophiesInWar,
      minTrophies: data.minTrophies
    }
  }


  allPlayers :any[] = []

  
  visibleAdd = false
  visibleUpdate = false
  visibleDelete = false
  visiblePlayer = false


  nameAdd !: string
  descAdd !: string
  regionAdd !: string
  openAdd :boolean = false
  trophiesAdd !: number 
  trophWarAdd !: number 
  playerAdd !: any


  nameUp !: string
  descUp !: string
  regionUp !: string
  openUp = false
  trophiesUp !: number
  trophWarUp !: number
  selectedUp!: any

  selectedDelete!: any

  selectedClan !: any
  selectedPlayer !: any

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
    this.visiblePlayer = false
    
  }

  showUpdate(){
    this.visibleUpdate = !this.visibleUpdate
    this.visibleAdd = false
    this.visibleDelete = false
    this.visiblePlayer = false
  }

  showDelete(){
    this.visibleDelete = !this.visibleDelete
    this.visibleAdd = false
    this.visibleUpdate = false
    this.visiblePlayer = false
  }

  showAddPlayer(){
    this.visiblePlayer = !this.visiblePlayer
    this.visibleAdd = false
    this.visibleUpdate = false
    this.visibleDelete = false

  }

  Post(){

    if (this.isUser){
      this.playerAdd = this.allPlayers.filter(x => x.alias == this.tokenStorage.getUser())[0]
    }

    if (!this.playerAdd) {
      this.showError('Player field cannot be empty')
      return
    }

    if (!this.nameAdd || !this.descAdd || !this.regionAdd){
      this.showError('Fields cannot be empty')
      return
    }

    if (isNaN(this.trophWarAdd) || isNaN(this.trophiesAdd) ){
      this.showError('Fields cannot be empty')
      return
    }

    var id = this.playerAdd.id
    var url = this.baseUrl +'/' + id.toString()

    this.clanService.baseUrl = url
    this.clanService.create({'name':this.nameAdd, 'id':1, 'description':this.descAdd, 'typeOpen':this.openAdd, 'region': this.regionAdd, 'amountMembers':1, 'trophiesInWar':this.trophWarAdd, 
    'minTrophies':this.trophiesAdd}).subscribe((data)=>{
      this.showSuccess('Clan added')
      this.clanService.baseUrl = this.baseUrl
      this.clanService.getAll().subscribe((data)=>{this.allClans=data})
      this.grid.loadData()
    }, (err)=>{
      this.showError(err.error)
    })

    this.clanService.baseUrl = this.baseUrl
  }

  Update(){
    if (!this.selectedUp){
      this.showError('You need to select a clan')
      return
    }

    if (!this.nameUp) this.nameUp = this.selectedUp.name
    if (!this.descUp) this.descUp = this.selectedUp.description
    if (!this.regionUp) this.regionUp = this.selectedUp.region
    console.log(this.trophWarUp)
    if (isNaN(this.trophWarUp)) this.trophWarUp = this.selectedUp.trophiesInWar
    if (isNaN(this.trophiesUp)) this.trophiesUp= this.selectedUp.minTrophies
    

    var id = this.selectedUp.id
    
    this.clanService.update(id, {'name': this.nameUp, 'description': this.descUp, 'id':id, 'typeOpen':this.openUp, 'region':this.regionUp,
    'amountMembers':1, 'trophiesInWar':this.trophWarUp, 'minTrophies':this.trophiesUp}).subscribe((data)=>{
      this.showSuccess('Clan Updated')
      this.clanService.getAll().subscribe((data)=>{this.allClans=data})
      this.grid.loadData()
    }, (err)=>{
      this.showError(err.error)
    
    })

    
  
  }

  Delete(){
    if (!this.selectedDelete){
      this.showError('Select a clan to delete')
      return
    }

    var id = this.selectedDelete.id
    this.clanService.delete(id).subscribe((data)=>{
      this.showSuccess('Clan Deleted')
      this.clanService.getAll().subscribe((data)=>{this.allClans=data})
      this.grid.loadData()
    },(err)=>{
      this.showError(err.error)
    })
    
  }


    AddPlayerToClan(){
      if (!this.selectedClan || !this.selectedPlayer){
        this.showError("select player and clan")
        return;
      }

      let url = this.clanService.baseUrl
      
      this.clanService.baseUrl += '/'+this.selectedClan.id + '/players/' + this.selectedPlayer.id

      this.clanService.create({'id':1,'name':'na','description':'ja','region':'USA','typeOpen': true,'amountMembers':12,'trophiesInWar':10,'minTrophies':10}).subscribe((data)=>
      {
        this.showSuccess('Player added to clan')
        this.grid.loadData()

      },(err)=>{
        this.showError(err.error)
        console.log(err)
      })

      this.clanService.baseUrl=url

    }

  
}
