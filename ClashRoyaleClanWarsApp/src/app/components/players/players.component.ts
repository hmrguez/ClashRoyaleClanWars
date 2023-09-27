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
      field: 'Alias',
      type: ColumnType.String,
    },
    {
      header: 'Elo',
      field: 'Elo',
      type: ColumnType.Number,
    },
    {
      header: 'Level',
      field: 'Level',
      type: ColumnType.Number,
    },
    {
      header: 'Victories',
      field: 'Victories',
      type: ColumnType.Number,
    },
    {
      header: 'Card Amount',
      field: 'CardAmount',
      type: ColumnType.Number,
    },
    {
      header: 'Max Elo',
      field: 'MaxElo',
      type: ColumnType.Number,
    },
  ]

  constructor(public playerService: PlayerService) { }
}
