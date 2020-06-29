import { Injectable } from '@angular/core';
import { HttpHeaders, HttpParams, HttpClient } from '@angular/common/http';
import { Observable, throwError } from 'rxjs';
import { IDog, Status } from '../models/IDog';
import { catchError, map } from 'rxjs/operators';
import { ICreateReportDto } from '../models/ICreateReportDto';
import { IReport } from '../models/IReport';
import { AuthenticationService } from './authentication.service';
import { Router } from '@angular/router';
import { DogService } from './dog.service';
import { API_ENDPOINT } from './Consts';

@Injectable({
  providedIn: 'root'
})
export class ReportService {
  url: string = API_ENDPOINT + "reports/";

  constructor(private httpClient: HttpClient, private authService: AuthenticationService, private dogService: DogService) { }

  private formatErrors(error: any) {
    return throwError(error.error);
  }

  //Public korisnici mozat da submitiraat reports
  submitReport(report: ICreateReportDto) {
    return this.httpClient.post(
      this.url + "create",
      JSON.stringify(report),
      { headers: { 'Content-Type': 'application/json' } }
    ).pipe(catchError(this.formatErrors));
  }

  //Treba token za da uspee requestot
  getAllReports(): Observable<any> {
    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.get(this.url + "pending", httpOptions)
    .pipe(catchError(this.formatErrors));
  }

  sendEmailReport(report : IReport): Observable<any> {
    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };

    return this.httpClient.get(this.url + "send", httpOptions)
    .pipe(catchError(this.formatErrors));
  }

  //Bara token za da uspee rquestot
  deleteReportAndUpdateDogStatus(report: IReport) {
    if(report.dog.status == Status.pendingAdoption){
      report.dog.status = Status.adopted;
    }
    else if(report.dog.status == Status.pendingFound) {
      report.dog.status = Status.found;
    }

    const token = this.authService.getToken();
    const httpOptions = {
      headers: new HttpHeaders({
        'Authorization': 'Bearer ' + token,
        'Content-Type': 'application/json'
      })
    };
    return this.httpClient
      .post(this.url + "deleteReportAndUpdateDog", JSON.stringify(report), httpOptions)
      .pipe(map(res => { return res; })
      ).subscribe();
  }
}
