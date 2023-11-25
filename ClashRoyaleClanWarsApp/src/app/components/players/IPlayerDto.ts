import {ICardDto} from "../cards/ICardDto";

export interface IPlayerDto{
  id: Number;
  alias: string,
  elo: Number,
  level : Number
  victories : Number
  cardAmount : Number
  maxElo : Number
  favoriteCard: ICardDto
}
