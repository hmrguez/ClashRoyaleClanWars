import { Injectable } from '@angular/core';
import {CrudService} from "../../services/CrudService";
import {ICardDto} from "./ICardDto";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class CardService extends CrudService<ICardDto>{
  baseUrl: string = `http://localhost:5085/api/cards`;
  constructor(http: HttpClient) {
    super(http);
  }
}
