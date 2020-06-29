import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { ReportService } from '../../services/report.service';
import { Status, Gender } from '../../models/IDog';
import { ICreateDogDto } from 'src/app/models/ICreateDogDto';
import { ICreateReportDto } from 'src/app/models/ICreateReportDto';
import { DogService } from 'src/app/services/dog.service';
import { IDogSize } from 'src/app/models/IDogSize';


@Component({
  selector: 'app-report',
  templateUrl: './report.component.html',
  styleUrls: ['./report.component.css']
})
export class ReportComponent implements OnInit {
  Status = Status;
  Gender = Gender;
  reportForm: FormGroup;
  submitted = false;
  sizes: any[];

  constructor(private formBuilder: FormBuilder, private router: Router, private reportService: ReportService, private dogService: DogService) { }

  ngOnInit() {
    this.dogService.getSizes().subscribe(res => {
      console.log(res);
      this.sizes = res;
      this.reportForm.get('size').setValue(this.sizes[0].id);
    });

    this.submitted = false;
    this.reportForm = this.formBuilder.group({
      id: [],
      status: Status.homeless,
      code: ['',Validators.required],
      size: ['',Validators.required],
      gender: Gender.male,
      location: ['',Validators.required],
      breed: ['',Validators.required],
      description: ['',Validators.required],
      image: ['',Validators.required],
      contactEmail: ['', Validators.required],
      contactPhone: ['', Validators.required]
    });
  }

  
  reportDog():void{
    console.log(this.reportForm);
    this.submitted = true;
    if(this.reportForm.invalid){
      return;
    }
    console.log(this.reportForm.controls['size'].value + " AUFF");
    let dog: ICreateDogDto = {
      status: this.reportForm.controls.status.value,
      code: this.reportForm.controls['code'].value,
      sizeId: this.reportForm.controls['size'].value,
      gender: this.reportForm.controls['gender'].value,
      location: this.reportForm.controls['location'].value,
      breed: this.reportForm.controls['breed'].value,
      description: this.reportForm.controls['description'].value,
      imageUrl: this.reportForm.controls['image'].value,
    }

    let createReportDto: ICreateReportDto = {
      contactNumber: this.reportForm.controls['contactPhone'].value,
      contactEmail: this.reportForm.controls['contactEmail'].value,
      dog: dog
    }

    if(dog.status === Status.lost ) {
      this.reportService.submitReport(createReportDto).subscribe(res => {
        this.router.navigate(["/find"]);
      })
    }
    else {
      this.reportService.submitReport(createReportDto).subscribe(res => {
        this.router.navigate(["/adopt"]);
      })
    }
    
  }

}
