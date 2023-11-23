import { Component } from '@angular/core';
import { BattlesService } from './battles.service';
import { Battle } from './IBattle';
import { IColumn, ColumnType } from '../grid/IColumn';
import { PlayerService } from '../players/player.service';
import { IPlayerDto } from '../players/IPlayerDto';
import { OnInit } from '@angular/core';
import { TokenStorageService } from 'src/app/services/token-storage.service';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { MessageService } from 'primeng/api';

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
      field: 'winnerId',
      type: ColumnType.String, 
    },
    {
      header: 'Loser',
      field: 'loserId',
      type: ColumnType.String, 
    },
    {
      header: 'Duration',
      field: 'durationInSeconds',
      type: ColumnType.Number, 
    },
    {
      header: 'Date',
      field: 'date',
      type: ColumnType.String, 
    },
    {
      header: 'Trophies',
      field: 'amountTrophies',
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


  constructor( public battleSer: BattlesService, public playerService:PlayerService, private tokenstor: TokenStorageService, public http:HttpClient, private mess:MessageService) {
    this.is_Admin = this.tokenstor.isAdmin() || this.tokenstor.isSuperAdmin()
    
  }

  visibleAdd: boolean = false;

    showAdd() {
        this.visibleAdd = !this.visibleAdd;
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
      winnerId : data.winner.alias,
      loserId : data.loser.alias,
      amountTrophies : data.amountTrophies,
      //filter where clans.id = data.id, get the clans.name
      date : data.date,
      durationInSeconds : data.durationInSeconds

     
    }
  }

  showError(message:string){
    this.mess.add({ severity: 'error', summary: 'Error', detail: message });
  }

  showSuccess(message:string){
    this.mess.add({ severity: 'success', summary: 'Success', detail: message });
  }

  httpOptions = {
    headers: new HttpHeaders({ 'Content-Type': 'application/json' })
  };

  Post(){
    var url = 'http://localhost:5085/api/battles'

    if (!this.selectedLoser || !this.selectedWinner || !this.trophies || !this.duration || !this.date){
      this.showError('Cannot have empty fields')
      return
    }

    if (this.selectedLoser.id==this.selectedWinner.id){
      this.showError('Winner and Loser are the same')
      return
    }

    //if any fields are empty, show error
    
    
    if (this.date > new Date()){
      this.showError('Date is in the future')
      return
    }
    
    
    this.http.post(url,{'amountTrophies': this.trophies,'winnerId':this.selectedWinner.id, 'loserId': this.selectedLoser.id,  'durationInSeconds': this.duration, 'date':this.date.toISOString()},this.httpOptions).subscribe(data=>{
      this.showSuccess('battle added')
    }, err =>{
      this.showError(err.error)
     
    })
    this.visibleAdd = false
    
    
   
    
  }


}