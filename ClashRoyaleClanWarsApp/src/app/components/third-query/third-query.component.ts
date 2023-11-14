import { Component } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';

@Component({
  selector: 'app-third-query',
  templateUrl: './third-query.component.html',
  styleUrls: ['./third-query.component.scss']
})
export class ThirdQueryComponent {

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
      header: 'Region',
      field: 'region',
      type: ColumnType.String,
    },
    {
      header: 'Amount',
      field: 'amount',
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
      cardId : data.cardId,
      cardName : data.cardName,
      region : data.region,
      amount : data.amount
      
    }
  }



}
