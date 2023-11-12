import {ICardDto} from "../cards/ICardDto";

export interface IPlayerDto{
  Id: Number;
  Alias: string,
  Elo: Number,
  Level : Number
  Victories : Number
  CardAmount : Number
  MaxElo : Number
  FavoriteCard: ICardDto
}
