import { Component } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';

@Component({
  selector: 'app-fourth-query',
  templateUrl: './fourth-query.component.html',
  styleUrls: ['./fourth-query.component.scss']
})
export class FourthQueryComponent {

  queryColumns: IColumn[] = [
    {
      header: 'Card ID',
      field: 'cardId',
      type: ColumnType.Number,
    },
    {
      header: 'Card Name',
      field: 'cardName',
      type: ColumnType.String,
    },
    {
      header: 'Count',
      field: 'count',
      type: ColumnType.Number,
    },
    {
      header:'Clan Id',
      field:'clanId',
      type: ColumnType.Number
    }
    
  ];

  constructor(public queryService: QueryService)
  {
   
  }

 
  
  itemParsingFunction(data: any): Structure{
    return {
      cardId : data.cardId,
      cardName : data.cardName,
      count : data.count,
      clanId : data.clanId
    }
  }



}
