import { Injectable } from '@angular/core';
import { CrudService } from 'src/app/services/CrudService';
import { HttpClient } from '@angular/common/http';
import { Structure } from './Structre';

@Injectable({
  providedIn: 'root'
})
export class FirstQueryService extends CrudService<Structure>{

  baseUrl: string =  `http://localhost:5085/queries/firstquery`
  constructor( http: HttpClient) { 
    super(http);
   }
}
  

