import { Injectable } from '@angular/core';
import {CrudService} from "../../services/CrudService";
import {IPlayerDto} from "./IPlayerDto";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class PlayerService extends CrudService<IPlayerDto>{
  baseUrl: string = `http://localhost:5123/player`;
  constructor(http: HttpClient) {
    super(http);
  }
}