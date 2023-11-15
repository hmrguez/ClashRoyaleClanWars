import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';

const AUTH_API = 'http://localhost:5085/api/analytics';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class AnalyticsService {

  constructor(private http: HttpClient) { }

 
  rqst(deck: string[]): Observable<any> {
    const x = this.http.post(AUTH_API , {
      deck : deck
    }, httpOptions);

    return x;
  }
}
