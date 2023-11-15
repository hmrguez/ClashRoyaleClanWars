import { Component } from '@angular/core';
import {ClanService} from "./clan.service";
import {ColumnType, IColumn} from "../grid/IColumn";
import { IClanDto } from './IClanDto';

@Component({
  selector: 'app-clans',
  templateUrl: './clans.component.html',
  styleUrls: ['./clans.component.scss']
})
export class ClansComponent {
  clanColumns: IColumn[] = [
    {
      header: 'Name',
      field: 'name',
      type: ColumnType.String,
    },
    {
      header: 'Description',
      field: 'description',
      type: ColumnType.String,
    },
    {
      header: 'Region',
      field: 'region',
      type: ColumnType.String,
    },
    {
      header: 'Public',
      field: 'typeOpen',
      type: ColumnType.Boolean,
    },
    {
      header: 'Member Count',
      field: 'amountMembers',
      type: ColumnType.Number,
    },
    {
      header: 'Trophies in wars',
      field: 'trophiesInWar',
      type: ColumnType.Number,
    },
    {
      header: 'Min Trophies',
      field: 'minTrophies',
      type: ColumnType.Number,
    },
  ]


  constructor(public clanService: ClanService) { 
    
  }

  itemParsingFunction(data: any): IClanDto{
    return {
      id: data.id,
      name: data.name,
      description: data.description,
      region: data.region,
      typeOpen: data.typeOpen,
      amountMembers: data.amountMembers,
      trophiesInWar: data.trophiesInWar,
      minTrophies: data.minTrophies
    }
  }
  
  
  
}
