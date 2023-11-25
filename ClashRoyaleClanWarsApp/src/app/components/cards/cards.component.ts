import {Component} from '@angular/core';
import {ColumnType, IColumn} from "../grid/IColumn";
import {DenominationEnum, QualityEnum, TargetEnum} from "./CardEnums";
import {SelectItem} from "primeng/api";
import {CardService} from "./card.service";
import {ICardDto} from "./ICardDto";

@Component({
  selector: 'app-cards',
  templateUrl: './cards.component.html',
  styleUrls: ['./cards.component.scss']
})
export class CardsComponent {
  items: Array<ICardDto> = []

  stateOptions: any[] = [{label: 'View Pictures', value: false}, {label: 'Show Details', value: true}];

  value: boolean ;

  currIndex = 0

  constructor(public cardService: CardService) {
    this.getCards()
    this.value = false
    
  }

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
      header: 'Name',
      field: 'name',
      type: ColumnType.String,
    },
    {
      header: 'Type',
      field: 'type',
      type: ColumnType.Enum,
      enumOptions: Object.values(DenominationEnum).map((value) => (<SelectItem>{
        label: value,
        value: value,
      })),
      enumColors: new Map(Object.entries(this.enumColors.DenominationEnum)),
    },
    // {
    //   header: 'Description',
    //   field: 'description',
    //   type: ColumnType.String,
    // },
    {
      header: 'Elixir',
      field: 'elixir',
      type: ColumnType.Number,
    },
    {
      header: 'Quality',
      field: 'quality',
      type: ColumnType.Enum,
      enumOptions: [
        <SelectItem>{label: 'Rare', value: 'Rare' },
        <SelectItem>{label: 'Common', value: 'Common'},
        <SelectItem>{label: 'Legendary', value: 'Legendary'},
        <SelectItem>{label: 'Epic', value: 'Epic'},
        <SelectItem>{label: 'Champion', value: 'Champion'}
      ],
      enumColors: new Map(Object.entries(this.enumColors.QualityEnum)),
    },
    {
      header: 'Damage',
      field: 'damage',
      type: ColumnType.Number,
    },
    {
      header: 'Area Damage',
      field: 'areaDamage',
      type: ColumnType.Boolean,
    },
    {
      header: 'Target',
      field: 'target',
      type: ColumnType.Enum,
      enumOptions: Object.values(TargetEnum).map((value) => (<SelectItem>{
        label: value,
        value: value,
      })),
      enumColors: new Map(Object.entries(this.enumColors.TargetEnum)),
    },
    {
      header: 'Initial Level',
      field: 'initialLevel',
      type: ColumnType.Number,
    },
    
  ];


  itemParsingFunction(data: any): ICardDto{
    return {
      areaDamage: data.areaDamage,
      damage: data.damage,
      description: data.description,
      elixir: data.elixir,
      id: data.id,
      imageUrl: data.imageUrl,
      initialLevel: data.initialLevel,
      name: data.name,
      quality: QualityEnum[data.quality],
      target: TargetEnum[data.target],
      type: DenominationEnum[data.type]
    }
  }

  getCards(){
    this.cardService.getAll().subscribe(cards=>{
      cards.forEach(cardData => {
        let parsed = this.itemParsingFunction(cardData);
          if(!parsed){
            throw Error("Failed to parse card");
          } else {
            this.items.push(parsed);
          }
          });
    })
  }

  plusSlides(position :number){
    let size = this.items.length
    let newpos = this.currIndex+position

    if (newpos>=size){
      this.currIndex=0;
    }
    else if (newpos<0){
      this.currIndex=size-1;
    }
    else{
      this.currIndex=newpos;
    }

  }

  
  }


