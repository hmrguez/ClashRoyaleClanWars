import { Injectable } from '@angular/core';



const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';

@Injectable({
  providedIn: 'root'
})
export class TokenStorageService {

  constructor() { }

  signOut(): void {
    window.sessionStorage.clear();
  }
  
  public saveToken(token: string): void {
    window.sessionStorage.removeItem(TOKEN_KEY);
    window.sessionStorage.setItem(TOKEN_KEY, token);

    //get id, exp and roles from token and save it in session storage
    //no me queda claro como llega el string token



    // const decodedToken = helper.decodeToken(token);
    // const expirationDate = helper.getTokenExpirationDate(token);
    
      //this.id = decodedToken.id;
      //this.roles = decodedToken.roles;
      //this.expirationDate = expirationDate;

      //this.autoLogout(expirationDate.getTime() - new Date().getTime());
    
    



  }

  public autoLogout(time: number)
  {
    setTimeout(() => {
      this.signOut();
    }, time);
  }
    
  

  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, JSON.stringify(user));
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  
}
