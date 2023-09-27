import {ICardDto} from "../cards/ICardDto";

export interface IPlayerDto{
  Id: number;
  Alias: string,
  Elo: number,
  Level : number
  Victories : number
  CardAmount : number
  MaxElo : number
  FavoriteCard: ICardDto
}
