import { Component, ViewChild } from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';
import { GridComponent } from '../grid/grid.component';
import { PlayerService } from '../players/player.service';
import { MessageService } from 'primeng/api';


@Component({
  selector: 'app-fifth-query',
  templateUrl: './fifth-query.component.html',
  styleUrls: ['./fifth-query.component.scss']
})
export class FifthQueryComponent {

  @ViewChild("grid") grid: GridComponent = {} as GridComponent;

  
  baseUrl:string = ""
  data :Structure[] = []
  update:boolean = false


  queryColumns: IColumn[] = [
   
    {
      header: 'Clan Name',
      field: 'clanName',
      type: ColumnType.String,
    },
   
    
  ];

  allPlayers: any[] = []
  selectedPlayer: any

  constructor(public queryService: QueryService, private playerSer:PlayerService , private mess:MessageService){
    this.playerSer.getAll().subscribe((data)=>{this.allPlayers=data})
  }
  
 
  
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

    if (!this.selectedPlayer){
      this.mess.add({ severity: 'error', summary: 'Error', detail: "Need to select player " });
      return
    }

    this.queryService.insertId(this.selectedPlayer.id)
    this.update = true
    var d = await this.loadData()
    var e = await this.loadData()
    //duplicated because it takes a while to refresh
    this.grid.loadData()
    this.update = false
  }



}
