import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CrudService } from 'src/app/services/CrudService';
import { Battle } from './IBattle';

@Injectable({
  providedIn: 'root'
})
export class BattlesService extends CrudService<Battle>{

  baseUrl = 'http://localhost:5085/api/battles'
  constructor(http :HttpClient) { 
      super(http)
  }

}
