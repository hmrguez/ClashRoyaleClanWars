import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Structure } from './Structure';
import { CrudService } from 'src/app/services/CrudService';

@Injectable({
  providedIn: 'root'
})
export class QueryService extends CrudService<Structure> {
  basic :string = `http://localhost:5085/queries/fifthquery`;
  override baseUrl: string = `http://localhost:5085/queries/fifthquery`;

  insertId(playerId:number){
    this.baseUrl += "/" + playerId.toString()
  }

  reset(){
    this.baseUrl = this.basic
  }

  constructor(http : HttpClient) { 
    super(http)
  }
}
