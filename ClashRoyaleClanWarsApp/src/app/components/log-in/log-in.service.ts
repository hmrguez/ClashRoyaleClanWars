import { Injectable } from '@angular/core';
import {CrudService} from "../../services/CrudService";
import {HttpClient} from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class LogInService extends CrudService<any> {

  baseUrl: string = `http://localhost:5123/login`;
  constructor(http: HttpClient) {
    super(http);
  }

  
}
