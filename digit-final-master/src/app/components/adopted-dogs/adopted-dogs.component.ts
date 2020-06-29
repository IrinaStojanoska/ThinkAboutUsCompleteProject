import { Component, OnInit } from '@angular/core';
import { IDog } from 'src/app/models/IDog';
import { DogService } from 'src/app/services/dog.service';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { DogDetailsComponent } from '../dog-details/dog-details.component';
import { MatDialog } from '@angular/material';

@Component({
  selector: 'app-adopted-dogs',
  templateUrl: './adopted-dogs.component.html',
  styleUrls: ['./adopted-dogs.component.css']
})
export class AdoptedDogsComponent implements OnInit {

  public dogs: IDog[]

  constructor(private dogService: DogService, private authService: AuthenticationService, private dialog: MatDialog) { }

  ngOnInit() {
    this.dogService.getAdoptedDogs().subscribe (
      result => {
        console.log(result);
        this.dogs = result;
      },
      error => {
        this.authService.logOut();
      }
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
