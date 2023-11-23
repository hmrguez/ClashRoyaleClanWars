import { Component, OnInit } from '@angular/core';
import {ClanService} from "./clan.service";
import {ColumnType, IColumn} from "../grid/IColumn";
import { IClanDto } from './IClanDto';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { PlayerService } from '../players/player.service';
import { IPlayerDto } from '../players/IPlayerDto';

export interface Player{
  id: Number,
  name: string
}
@Component({
  selector: 'app-clans',
  templateUrl: './clans.component.html',
  styleUrls: ['./clans.component.scss']
})

export class ClansComponent implements OnInit {

  isSuperuser: boolean = false
  isAdmin: boolean = false

  allPlayers!: Player[] 
  playerSelected!: Player



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



  constructor(public clanService: ClanService, private tokenStorage: TokenStorageService, public playerSer: PlayerService ) { 
    this.isAdmin = this.tokenStorage.isAdmin()
    this.isSuperuser = this.tokenStorage.isSuperAdmin()
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

  regions: string[] = []
  visible = false
  selectedRegion :any

  showDialog(){
    this.visible = true
  }

  async LoadPlayers(){
    var play :IPlayerDto[] = []
    var players :Player[] =[]
  
   
    //map play and only add id and name to this.allpayers
    const func = ((data: any)=>{
        play = data
    });
  
    const obeservable = await this.playerSer.getAll().toPromise();
    func(obeservable)
  
    for (let i=0;i<play.length;i++){
      players.push({id: play[i].id, name:play[i].alias})}

    return players

  }
  async ngOnInit() {
    
      this.regions.push('Dubai')
      this.allPlayers = await this.LoadPlayers()
      console.log(this.allPlayers)





      
      

  }
  

  
  
}
