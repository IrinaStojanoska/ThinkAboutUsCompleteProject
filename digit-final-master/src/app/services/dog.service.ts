import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IDog } from '../models/IDog';
import { catchError } from 'rxjs/operators';
import { API_ENDPOINT } from './Consts';
import { AuthenticationService } from './authentication.service';

@Injectable({
  providedIn: 'root'
})
export class DogService {
  url: string = API_ENDPOINT + "dogs/";
  sizesUrl: string = API_ENDPOINT + "sizes/"

  constructor(private httpClient: HttpClient, private authService: AuthenticationService) { }

  private formatErrors(error: any) {
    return throwError(error.error);
  }

  deleteDog(dog: IDog): Observable<any>{
    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient
      .delete(this.url + dog.id, httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  getSizes(): Observable<any>{
    return this.httpClient.get(this.sizesUrl)
      .pipe(catchError(this.formatErrors));
  }

  getHomelessDogs(): Observable<any> {
    return this.httpClient.get(this.url + "homeless")
      .pipe(catchError(this.formatErrors));
  }

  getLostDogs(): Observable<any> {
    return this.httpClient.get(this.url + "lost")
      .pipe(catchError(this.formatErrors));
  }

  //Ne go koristime nigde
  getSingleDog(id: number): Observable<any>{
    return this.httpClient.get(this.url + "single/" + id.toString())
      .pipe(catchError(this.formatErrors));
  }

  //Treba token za ovoj request
  getAdoptedDogs(): Observable<any>{ 
    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.get(this.url + "adopted", httpOptions)
      .pipe(catchError(this.formatErrors));
  }
  
  //Treba token za ovoj request
  getFoundDogs(): Observable<any>{
    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.get(this.url + "found", httpOptions)
      .pipe(catchError(this.formatErrors));
  }

  getAdoptedAndFoundDogs(): Observable<any>{
    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.get(this.url + "AdoptedAndFound", httpOptions)
      .pipe(catchError(this.formatErrors));
  };

  update(path: string, body: Object = {}): Observable<any> {
    console.log(this.url + path);
    console.log(JSON.stringify(body));
    return this.httpClient.put(
      this.url + path,
      JSON.stringify(body),
      { headers: { 'Content-Type': 'application/json'}}
    ).pipe(catchError(this.formatErrors));
  }
}
