import { Injectable } from '@angular/core';
import { User } from '../models/User';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Router } from "@angular/router";
import { API_ENDPOINT } from './Consts';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  url: string = API_ENDPOINT + "auth/login";

  constructor(private httpClient: HttpClient, private router: Router, ) { }

  createToken(user: User){
    let credentials = JSON.stringify(user);
    this.httpClient.post(this.url, credentials, {
      headers: new HttpHeaders({
        "Content-Type": "application/json"
      })
    }).subscribe(response => {
      let token = (<any>response).token;
      localStorage.setItem("thinkaboutus_admin_jwt", token);
      console.log("TOKEN: ", token);
      this.router.navigate(["/"]);
    }, err => {
    });
  }

  isAdminLoggedIn() : boolean {
    let token = localStorage.getItem('thinkaboutus_admin_jwt');
    if(token == null){
      return false;
    }  
    return true;
  }

  logOut() {
    localStorage.removeItem("thinkaboutus_admin_jwt");
    this.router.navigate(['/login']);
 }

 getToken(): string{
    let token = localStorage.getItem("thinkaboutus_admin_jwt");
    if(token == null){
      this.router.navigate(['/login']);
    }

    return token;
 }
}
