import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { War } from './WarDto';
import { CrudService } from 'src/app/services/CrudService';


@Injectable({
  providedIn: 'root'
})


export class WarService extends CrudService<War>{

  baseUrl:string = 'http://localhost:5085/api/wars'

  constructor(http:HttpClient) {
    super(http)
   }

  
}
