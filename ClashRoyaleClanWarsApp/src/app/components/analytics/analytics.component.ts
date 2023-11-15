import { Component, ViewChild } from '@angular/core';
import { CardService } from '../cards/card.service';
import { ICardDto } from '../cards/ICardDto';
import { QualityEnum } from '../cards/CardEnums';
import { TargetEnum } from '../cards/CardEnums';
import { DenominationEnum } from '../cards/CardEnums';
import { OnInit } from '@angular/core';
import { Deck } from './Results';
import { AnalyticsService } from './analytics.service';


@Component({
  selector: 'app-analytics',
  templateUrl: './analytics.component.html',
  styleUrls: ['./analytics.component.scss']
})
export class AnalyticsComponent implements OnInit {

    displayResults = false;

    imageSrcs = [
      {
        deck: "Giant Double Prince",
        img: "/assets/gallery/decks/giantDouble.PNG"
      },
    ]

    queryResults: any =[]

    canDrop = true

    available: ICardDto[] =[];

    selected: ICardDto[] =[];

    currentlyDragging: ICardDto  | null = null;

    constructor(private cardServ : CardService, private deckService: AnalyticsService){}

    ngOnInit() {
      this.selected = [];
      //save into availabale products the results from getall in the cardService
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
    this.cardServ.getAll().subscribe(cards=>{
      cards.forEach(cardData => {
        let parsed = this.itemParsingFunction(cardData);
          if(!parsed){
            throw Error("Failed to parse card");
          } else {
            this.available.push(parsed);
          }
          });
    })
  }

  dragStart(product: ICardDto) {
      this.currentlyDragging = product;
  }

  drop() {
      if (this.currentlyDragging && this.canDrop) {
          let draggedProductIndex = this.findIndex(this.currentlyDragging);
          this.selected = [...this.selected, this.currentlyDragging];
          this.available = this.available.filter((val, i) => i != draggedProductIndex);
          this.currentlyDragging = null;
          if (this.selected.length==8){
            this.canDrop=false
          }
      }
  }

  dragEnd() {
      this.currentlyDragging = null;
  }

  findIndex(product: ICardDto) {
      let index = -1;
      for (let i = 0; i < this.available.length; i++) {
          if (product.id === this.available[i].id) {
              index = i;
              break;
          }
      }
      return index;
  } 

  Remove(id:number){
    
    let card:ICardDto 

    for (let i = 0; i < this.selected.length; i++) {
      if (this.selected[i].id==id){
        card = this.selected[i]
        this.available.push(card)
        this.selected = this.selected.filter(x=> x!=card)
        this.canDrop = true
        break
      }
      
    }
  }

  getImage(name: string){

    let obj = this.imageSrcs.filter(x => x.deck==name)
    return obj[0].img
  }

  

  MakeRqst(){
    let arr:string[] = []
    arr = this.selected.map(x => x.name)
    console.log('data', arr)

    this.deckService.rqst(arr).subscribe((data)=>{
      this.queryResults = data
}
);
    this.displayResults = true



  }

  rst(){
    this.displayResults = false
    this.available = this.available.concat(this.selected)
    this.selected = []
    this.canDrop = true
  }

 
}





