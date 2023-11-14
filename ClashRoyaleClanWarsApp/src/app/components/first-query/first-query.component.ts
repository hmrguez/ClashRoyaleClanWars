import { Component } from '@angular/core';
import { FirstQueryService } from './first-query.service';
import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structre';

@Component({
  selector: 'app-first-query',
  templateUrl: './first-query.component.html',
  styleUrls: ['./first-query.component.scss']
})
export class FirstQueryComponent {

  queryColumns: IColumn[] = [
    {
      header: 'Player ID',
      field: 'playerId',
      type: ColumnType.Number,
    },
    {
      header: 'Player Name',
      field: 'playerName',
      type: ColumnType.String,
    },
    {
      header: 'Trophies',
      field: 'trophies',
      type: ColumnType.Number,
    },
    
  ];


  constructor(public queryService: FirstQueryService)
  {
    this.queryService.getAll().subscribe((data)=>{
        console.log("DATA", data);
  }
  );
  }

 
  
  itemParsingFunction(data: any): Structure{
    return {

      playerId: data.playerId,
    playerName: data.playerName,
    trophies : data.trophies
    }
  }

}
