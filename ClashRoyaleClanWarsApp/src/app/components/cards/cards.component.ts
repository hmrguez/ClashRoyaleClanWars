import {Component} from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import {DenominationEnum, QualityEnum, TargetEnum} from "./CardEnums";
import {SelectItem} from "primeng/api";
import {CardService} from "./card.service";

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.scss']
})
export class CardsComponent {
  enumColors = {
    DenominationEnum: {
      Spell: 'blue',
      Structure: 'green',
      Troop: 'red',
      Unknown: 'gray',
    },
    QualityEnum: {
      Common: 'gray',
      Rare: 'blue',
      Epic: 'purple',
      Legendary: 'orange',
      Champion: 'gold',
    },
    TargetEnum: {
      Ground: 'brown',
      Air: 'skyblue',
      Buildings: 'gray',
      Ground_Air: 'green',
      Nothing: 'red',
    },
  };

  cardColumns: IColumn[] = [
    {
      header: 'ID',
      field: 'Id',
      type: ColumnType.Number,
    },
    {
      header: 'Name',
      field: 'Name',
      type: ColumnType.String,
    },
    {
      header: 'Type',
      field: 'Type',
      type: ColumnType.Enum,
      enumOptions: Object.values(DenominationEnum).map((value) => (<SelectItem>{
        label: value,
        value: value,
      })),
      enumColors: new Map(Object.entries(this.enumColors.DenominationEnum)),
    },
    {
      header: 'Description',
      field: 'Description',
      type: ColumnType.String,
    },
    {
      header: 'Elixir',
      field: 'Elixir',
      type: ColumnType.Number,
    },
    {
      header: 'Quality',
      field: 'Quality',
      type: ColumnType.Enum,
      enumOptions: Object.values(QualityEnum).map((value) => (<SelectItem>{
        label: value,
        value: value,
      })),
      enumColors: new Map(Object.entries(this.enumColors.QualityEnum)),
    },
    {
      header: 'Damage',
      field: 'Damage',
      type: ColumnType.Number,
    },
    {
      header: 'Area Damage',
      field: 'AreaDamage',
      type: ColumnType.Boolean,
    },
    {
      header: 'Target',
      field: 'Target',
      type: ColumnType.Enum,
      enumOptions: Object.values(TargetEnum).map((value) => (<SelectItem>{
        label: value,
        value: value,
      })),
      enumColors: new Map(Object.entries(this.enumColors.TargetEnum)),
    },
    {
      header: 'Initial Level',
      field: 'InitialLevel',
      type: ColumnType.Number,
    },
    {
      header: 'Image URL',
      field: 'ImageUrl',
      type: ColumnType.String,
    },
  ];

  constructor(public cardService: CardService) { }
}
