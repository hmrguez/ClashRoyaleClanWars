import { Injectable } from '@angular/core';
//import {decode} from 'jsonwebtoken'



const TOKEN_KEY = 'auth-token';
const USER_KEY = 'auth-user';
var roles_saved = 0;

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

  }

  public expToken(date:string):void{

    //\"iat\":\"31-Oct-23 5:24:20 AM\"
    //not working del todo

    var x = date.split(':')[1].substring(2,-2);

    var y = x.split(' ')[1];

    sessionStorage.setItem('expDate', y)



  }

  public saveExp(exp:string):void{
   // \"exp\":1698733460}"

   var expp = exp.split(':')[1]
   expp = expp.substring(0,expp.length-2)
   sessionStorage.setItem("exp", expp);
  }

  public saveRoles(roles:string):void{
    //"{\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":\"User\"
    for (let index = 1; index < roles_saved+1; index++) {
      sessionStorage.removeItem("Role"+index)
    }

    var r = roles.split(':')[2]
    var rol = r.split('"')

    var index = 1

    for (index; index < rol.length-1; index++) {
      const element = rol[index].substring(0, rol[index].length );
      sessionStorage.setItem("Role" + index, element)

    }

    roles_saved = index-1
   
    
  }



  public getToken(): string | null {
    return window.sessionStorage.getItem(TOKEN_KEY);
  }

  public saveUser(user: any): void {
    window.sessionStorage.removeItem(USER_KEY);

    var spl = user.split(':')
    user = spl[2]
    var us = user.substring(2, user.length-2)

    window.sessionStorage.setItem(USER_KEY, user);
  }

  public getUser(): any {
    const user = window.sessionStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }

    return {};
  }

  public getRoles():any{
    var rol = []
    for (let index = 0; index < roles_saved; index++) {
      var x = sessionStorage.getItem("Role"+(index+1))
      rol.push(x)      
    }

    return rol;
  }

  
}
