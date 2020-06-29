import { Component, OnInit } from '@angular/core';
import { IDog, Status } from '../../models/IDog';
import { DogService } from '../../services/dog.service';
import { MatDialog } from '@angular/material';
import { DogDetailsComponent } from '../dog-details/dog-details.component';

@Component({
  selector: 'app-adopt-dog',
  templateUrl: './adopt-dog.component.html',
  styleUrls: ['./adopt-dog.component.css']
})
export class AdoptDogComponent implements OnInit {
  public dogs: IDog[];

  public dogForDelete;
  constructor(private dogService: DogService,public dialog: MatDialog) { 

  }

  ngOnInit() {
    this.dogService.getHomelessDogs().subscribe (
      result => {
        console.log(result);
        this.dogs = result;
      },
      error => console.log(error)
    )
  }

  applyForAdoption(dog: IDog) {
    dog.status = Status.pendingAdoption;
    this.dogService.update(dog.id.toString(), dog).subscribe (
      result => {
        console.log(result);
      },
      error => console.log(error)
    )
  }

  seeMore(dog : IDog):void {
    //console.log(dog.code);
    const dialogRef = this.dialog.open(DogDetailsComponent, {
      data: dog
    });

    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

 }
