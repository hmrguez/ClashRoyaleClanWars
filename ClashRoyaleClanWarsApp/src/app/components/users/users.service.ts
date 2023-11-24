import { Injectable } from '@angular/core';
import { CrudService } from 'src/app/services/CrudService';
import { User } from './UserDto';
import { HttpClient } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})
export class UsersService extends CrudService<User>{

  override baseUrl: string = 'http://localhost:5085/api/users'
  constructor( http:HttpClient) {
    super(http)
   }
}
