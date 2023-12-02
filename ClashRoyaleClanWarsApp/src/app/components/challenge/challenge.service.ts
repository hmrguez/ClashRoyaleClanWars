import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CrudService } from 'src/app/services/CrudService';
import { Challenge } from './ChallengeDto';

@Injectable({
  providedIn: 'root'
})
export class ChallengeService extends CrudService<Challenge>{

   baseUrl= 'http://localhost:5085/api/challenges/open'

  constructor(http:HttpClient) {
    super(http)
   }
}
