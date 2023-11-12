import { Component } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';

@Component({
  selector: 'app-sixth-query',
  templateUrl: './sixth-query.component.html',
  styleUrls: ['./sixth-query.component.scss']
})
export class SixthQueryComponent {

  queryColumns: IColumn[] = [
    {
      header: 'Challenge ID',
      field: 'challengeId',
      type: ColumnType.Number,
    },
    {
      header: 'Challenge Name',
      field: 'challengeName',
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
      challengeId : data.challengeId,
      challengeName : data.challengeName
    }
  }



}
