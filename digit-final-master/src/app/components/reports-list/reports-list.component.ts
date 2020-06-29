import { Component, OnInit } from '@angular/core';
import { ReportService } from 'src/app/services/report.service';
import { IReport } from '../../models/IReport';
import { MatDialog } from '@angular/material';
import { IDog } from '../../models/IDog';
import { DogDetailsComponent } from '../dog-details/dog-details.component';
import { AuthenticationService } from 'src/app/services/authentication.service';

@Component({
  selector: 'app-reports-list',
  templateUrl: './reports-list.component.html',
  styleUrls: ['./reports-list.component.css']
})
export class ReportsListComponent implements OnInit {

  public reports: IReport[];
  constructor(private reportService: ReportService, private dialog: MatDialog, private authService: AuthenticationService) { }

  ngOnInit() {
    this.reportService.getAllReports().subscribe (
      result => {
        console.log(result);
        this.reports = result;
      },
      error => {
        console.log("error: " , error)
        this.authService.logOut();
      }
    )
  }

  seeMore(dog : IDog):void {
    console.log(dog);
    //console.log(dog.code);
    const dialogRef = this.dialog.open(DogDetailsComponent, {
      data: dog
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  sendEmail(report : IReport){
    this.reportService.sendEmailReport(report);
  }

  confirmDogSaved(report: IReport){
    this.reportService.deleteReportAndUpdateDogStatus(report);
    const index = this.reports.indexOf(report, 0);
    if (index > -1) {
      this.reports.splice(index, 1);
    }
  }

}
