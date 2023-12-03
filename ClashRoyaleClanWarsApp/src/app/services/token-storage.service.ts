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
    //"{\"http://schemas.microsoft.com/ws/2008/06/identity/claims/role\":\"User\"
    var k = token.split(':')[2].split('"')[1]
    

    window.sessionStorage.setItem(TOKEN_KEY, k);

  }

  public expToken(exp:number):void{
    var iatt = new Date(exp*1000)
    sessionStorage.setItem('expDate', iatt.toISOString())



  }

  public getExp():Date{
    const d = sessionStorage.getItem('expDate')
    const date = new Date(d!.slice(0,-1))
    return date
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

  public updateUser(user:string){
    window.sessionStorage.removeItem(USER_KEY);
    window.sessionStorage.setItem(USER_KEY, user);
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
     
      return JSON.parse(user)
      
    }

    return {};
  }

  public getRoles(): string[]{
    var rol = []
    for (let index = 1; index < 4; index++) {
      var x = sessionStorage.getItem("Role"+(index))
      if (x) rol.push(x)      
    }

    return rol
  }

  public isAdmin() :boolean{
    let role = this.getRoles()
    return role.includes('Admin')
  }

  public isSuperAdmin() : boolean{
    let role = this.getRoles()
    return role.includes('SuperAdmin')
  }
  
}
