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

  currIndex = 0

  constructor(public cardService: CardService) {
    this.getCards()
  }

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


