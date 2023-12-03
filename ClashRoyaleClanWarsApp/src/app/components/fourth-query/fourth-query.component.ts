import { Component, ViewChild } from '@angular/core';

import {ColumnType, IColumn} from "../grid/IColumn";
import { Structure } from './Structure';
import { QueryService } from './query.service';
import { ClanService } from '../clans/clan.service';
import { IClanDto } from '../clans/IClanDto';
import { GridComponent } from '../grid/grid.component';



@Component({
  selector: 'app-fourth-query',
  templateUrl: './fourth-query.component.html',
  styleUrls: ['./fourth-query.component.scss']
})
export class FourthQueryComponent {
  data :any[] = []
  clans: IClanDto[] = []
  @ViewChild("grid") grid: GridComponent = {} as GridComponent;

  //create dictionary for types of card
  cardTypes = new Map<number, string>();

  



  queryColumns: IColumn[] = [
    
    {
      header: 'Card Name',
      field: 'cardName',
      type: ColumnType.String,
    },
    {
      header: 'Card Type',
      field: 'cardType',
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

  count = 0

  constructor(public queryService: QueryService)
  {
    this.cardTypes.set(0,'Unknown')
    this.cardTypes.set(1,'Spell')
    this.cardTypes.set(2,'Structure')
    this.cardTypes.set(3,'Troop')

    this.queryService.getAll().subscribe((data)=>{
      data.forEach(element => {
        this.data.push({
          cardName: element.cardName,
          count: element.count,
          clanName: element.clanName,
          queryId : this.count,
          cardType : this.cardTypes.get(element.cardType)
        })
        this.count++
      });
      this.grid.loadData()
    })
  }

 

 

}
  
  
