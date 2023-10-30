import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Token } from '@angular/compiler';

const AUTH_API = 'http://localhost:5123/api/account/';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  constructor(private http: HttpClient) { }

  login(username: string, password: string): Observable<any> {

    const x = this.http.post(AUTH_API + 'login/user', {Username: username, Password:password}, httpOptions);
    console.log(x);
    return x;
  }

  register(username: string, password: string, ConfirmPassword: string): Observable<any> {
    const x = this.http.post(AUTH_API + 'register/user', {
      Username: username,
      Password: password,
      ConfirmPassword: ConfirmPassword
    }, httpOptions);

    return x;
  }

}
