import { Component } from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';
import { GridComponent } from '../grid/grid.component';

@Component({
  selector: 'app-fifth-query',
  templateUrl: './fifth-query.component.html',
  styleUrls: ['./fifth-query.component.scss']
})
export class FifthQueryComponent {

  playerId:number = 1
  baseUrl:string = ""
  data :Structure[] = []

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
    this.baseUrl = queryService.baseUrl
    this.queryService.baseUrl += "/1"
  }
 

 
  
  itemParsingFunction(data: any): Structure{
    return {
      clanId: data.clanId,
      clanName: data.clanName,
    }
  }

  GetData(){
   
    this.queryService.getAll().subscribe((data)=>{
      this.data = data
    })
   
  }

  Show(){
    let url = this.baseUrl + '/'+ this.playerId.toString();
    this.queryService.baseUrl = url
    this.GetData()
  }



}
