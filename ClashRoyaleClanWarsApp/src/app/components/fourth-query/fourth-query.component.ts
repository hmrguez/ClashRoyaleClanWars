import { Component } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';
import { ClanService } from '../clans/clan.service';
import { IClanDto } from '../clans/IClanDto';


@Component({
  selector: 'app-fourth-query',
  templateUrl: './fourth-query.component.html',
  styleUrls: ['./fourth-query.component.scss']
})
export class FourthQueryComponent {

  clans: IClanDto[] = []

  queryColumns: IColumn[] = [
    
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
      header:'Clan Name',
      field:'clanName',
      type: ColumnType.String
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
      //filter where clans.id = data.id, get the clans.name
      clanName : data.clanName,

     
    }
  }



}
