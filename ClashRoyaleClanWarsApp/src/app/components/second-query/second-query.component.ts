import { Component } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';

@Component({
  selector: 'app-second-query',
  templateUrl: './second-query.component.html',
  styleUrls: ['./second-query.component.scss']
})
export class SecondQueryComponent {

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

  constructor(public queryService: QueryService)
  {
    this.queryService.getAll().subscribe((data)=>{
        console.log("DATA", data);
  }
  );
  }

 
  
  itemParsingFunction(data: any): Structure{
    return {

      id: data.playerId,
      name: data.playerName,
      trophies : data.trophies
    }
  }



}