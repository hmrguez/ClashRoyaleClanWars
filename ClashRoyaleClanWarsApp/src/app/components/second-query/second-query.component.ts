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
      header: 'Clan Name',
      field: 'clanName',
      type: ColumnType.String,
    },
    {
      header: 'Trophies',
      field: 'trophiesInWar',
      type: ColumnType.Number,
    },
    {
      header: 'Region',
      field: 'region',
      type : ColumnType.String,
    }
    
  ];

  constructor(public queryService: QueryService)
  {
  }

 
  
  itemParsingFunction(data: any): Structure{
    return {
      clanId : data.clanId,
      clanName : data.clanName,
      region : data.region,
      trophiesInWar : data.trophiesInWar
    }
  }



}
