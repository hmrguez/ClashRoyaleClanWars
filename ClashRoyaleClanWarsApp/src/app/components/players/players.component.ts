import {Component} from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import {PlayerService} from "./player.service";

@Component({
  selector: 'app-players',
  templateUrl: './players.component.html',
  styleUrls: ['./players.component.scss']
})
export class PlayersComponent {

  columns: IColumn[] = [
    {
      header: 'Alias',
      field: 'alias',
      type: ColumnType.String,
    },
    {
      header: 'Elo',
      field: 'elo',
      type: ColumnType.Number,
    },
    {
      header: 'Level',
      field: 'level',
      type: ColumnType.Number,
    },
    {
      header: 'Victories',
      field: 'victories',
      type: ColumnType.Number,
    },
    {
      header: 'Card Amount',
      field: 'cardAmount',
      type: ColumnType.Number,
    },
    {
      header: 'Max Elo',
      field: 'maxElo',
      type: ColumnType.Number,
    },
  ]

  constructor(public playerService: PlayerService) { }
}
