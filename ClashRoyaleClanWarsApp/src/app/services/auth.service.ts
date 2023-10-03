import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Token } from '@angular/compiler';

const AUTH_API = 'http://localhost:8080/api/account/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  loggedInToken : any;

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {

    const data={
      username:username,
      password:password
    }

    this.loggedInToken = this.http.post(AUTH_API + 'login', data, httpOptions);
    return this.loggedInToken;
  }

  register(username: string, password: string): Observable<any> {
    return this.http.post(AUTH_API + 'register', {
      username,
      password
    }, httpOptions);
  }

}
