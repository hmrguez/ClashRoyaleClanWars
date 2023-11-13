import { Component } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';

@Component({
  selector: 'app-fifth-query',
  templateUrl: './fifth-query.component.html',
  styleUrls: ['./fifth-query.component.scss']
})
export class FifthQueryComponent {

  queryColumns: IColumn[] = [
    {
      header: 'Clan ID',
      field: 'clanId',
      type: ColumnType.Number,
    },
    {
      header: 'Clan Name',
      field: 'clanName',
      type: ColumnType.String,
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

      clanId: data.clanId,
      clanName: data.clanName,
    }
  }



}
