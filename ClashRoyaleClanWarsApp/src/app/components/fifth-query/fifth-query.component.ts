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
  update:boolean = false


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

  constructor(public queryService: QueryService){}
  
 
  
  async loadData(){

    var datasets1 = this.data

    if (this.update){
      const func = ((data: any)=>{
          datasets1 = data
      });
  
      const obeservable = await this.queryService.getAll().toPromise();
      func(obeservable)

      this.data = datasets1
    }
  
    return datasets1

}
  
  itemParsingFunction(data: any): Structure{
    return {
      clanId: data.clanId,
      clanName: data.clanName,
    }
  }

  updateData(){
    console.log('data', this.data)
    return this.data
  }

 

  async Show(){

    this.queryService.reset()
    this.queryService.insertId(this.playerId)
    this.update = true
    var d = await this.loadData()


    this.update = false

    
    


  }



}
