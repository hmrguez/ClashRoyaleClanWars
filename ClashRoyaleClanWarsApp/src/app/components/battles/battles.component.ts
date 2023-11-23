import { Component } from '@angular/core';
import { BattlesService } from './battles.service';
import { Battle } from './IBattle';
import { IColumn, ColumnType } from '../grid/IColumn';

@Component({
  selector: 'app-battles',
  templateUrl: './battles.component.html',
  styleUrls: ['./battles.component.scss']
})
export class BattlesComponent {

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


  constructor( public battleSer: BattlesService){
    // var b = this.battleSer.getAll().subscribe((data)=>
    // {this.battles = data},(err)=>
    // {console.log(err.error)});
  }

  CreateBattleObject(){
    // for (let index = 0; index < this.battles.length; index++) {
    //   const element = this.battles[index];
    //   this.BattlesForGrid.push({
    //     winner: element.winner.alias,
    //     loser: element.loser.alias,
    //     trophies : element.amountTrophies,
    //     duration : element.duationInSeconds,
    //     date: element.date
    //   })
      
    // }
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


}
