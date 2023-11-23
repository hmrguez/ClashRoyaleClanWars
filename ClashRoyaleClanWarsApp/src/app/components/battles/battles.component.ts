import { Component } from '@angular/core';
import { BattlesService } from './battles.service';
import { Battle } from './IBattle';
import { IColumn, ColumnType } from '../grid/IColumn';
import { PlayerService } from '../players/player.service';
import { IPlayerDto } from '../players/IPlayerDto';
import { OnInit } from '@angular/core';
import { TokenStorageService } from 'src/app/services/token-storage.service';

export interface Player{
  id: Number,
  alias: string,
}
@Component({
  selector: 'app-battles',
  templateUrl: './battles.component.html',
  styleUrls: ['./battles.component.scss']
})
export class BattlesComponent implements OnInit {

  battles !: any

  BattlesForGrid :Battle[] = [] 

  queryColumns : IColumn[] = [
    {
      header: 'Winner',
      field: 'winner',
      type: ColumnType.String, 
    },
    {
      header: 'Loser',
      field: 'loser',
      type: ColumnType.String, 
    },
    {
      header: 'Duration',
      field: 'duration',
      type: ColumnType.Number, 
    },
    {
      header: 'Date',
      field: 'date',
      type: ColumnType.String, 
    },
    {
      header: 'Trophies',
      field: 'trophies',
      type: ColumnType.Number 
    },
    


  ]

  players: Player[] = []
  is_Admin:boolean = false

  selectedWinner!: Player 
  selectedLoser!: Player
  date !: Date 
  duration!: number
  trophies !: number


  constructor( public battleSer: BattlesService, public playerService:PlayerService, private tokenstor: TokenStorageService) {
    this.is_Admin = this.tokenstor.isAdmin() || this.tokenstor.isSuperAdmin()
    
  }

  visible: boolean = false;

    showDialog() {
        this.visible = true;
    }

  async ngOnInit() {
    this.players = await this.LoadPlayers()
    console.log(this.players)
      
  }

  async LoadPlayers(){
    var play :IPlayerDto[] = []
    var players :Player[] =[]
  
   
    //map play and only add id and name to this.allpayers
    const func = ((data: any)=>{
        play = data
    });
  
    const obeservable = await this.playerService.getAll().toPromise();
    func(obeservable)
  
    for (let i=0;i<play.length;i++){
      players.push({id: play[i].id, alias:play[i].alias})}

    return players

  }
  

  itemParsingFunction(data: any): Battle{
    return {
      winner : data.winner.alias,
      loser : data.loser.alias,
      trophies : data.amountTrophies,
      //filter where clans.id = data.id, get the clans.name
      date : data.date,
      duration : data.durationInSeconds

     
    }
  }

  Post(){
    console.log(this.date.toISOString())
    this.battleSer.create({winner:this.selectedWinner.id.toString(), loser: this.selectedLoser.id.toString(), trophies: this.trophies, duration: this.duration, date:this.date.toISOString()}).subscribe((data)=>{
      console.log(data)
    }, (err)=>{
      console.log(err.error)
    })
    
  }


}
