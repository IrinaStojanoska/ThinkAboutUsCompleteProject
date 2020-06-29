import { Component, OnInit } from '@angular/core';
import { DogService } from '../../services/dog.service';
import { IDog, Status } from '../../models/IDog';
import {MatDialog} from '@angular/material';
import { DogDetailsComponent } from '../dog-details/dog-details.component';

@Component({
  selector: 'app-find-dog',
  templateUrl: './find-dog.component.html',
  styleUrls: ['./find-dog.component.css']
})
export class FindDogComponent implements OnInit {

  public dogs: IDog[];

  public dogForDelete;
  constructor(private dogService: DogService,public dialog: MatDialog) { 

  }

  ngOnInit() {
    this.dogService.getLostDogs().subscribe (
      result => {
        console.log(result);
        this.dogs = result;
      },
      error => console.log(error)
    )
  }

  reportFoundDog(dog) {
    dog.status = Status.pendingFound;
    this.dogService.update(dog.id+"", dog).subscribe (
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
