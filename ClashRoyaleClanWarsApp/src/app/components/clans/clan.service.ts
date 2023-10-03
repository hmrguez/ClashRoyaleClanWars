import { Injectable } from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {CrudService} from "../../services/CrudService";
import {IClanDto} from "./IClanDto";

@Injectable({
  providedIn: 'root'
})
export class ClanService extends CrudService<IClanDto>{
  baseUrl: string = `http://localhost:5123/api/clans`;
  constructor(http: HttpClient) {
    super(http);
  }
}
