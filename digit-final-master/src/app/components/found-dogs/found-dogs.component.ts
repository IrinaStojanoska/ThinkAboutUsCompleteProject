import { Component, OnInit } from '@angular/core';
import { DogService } from 'src/app/services/dog.service';
import { IDog } from 'src/app/models/IDog';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { MatDialog } from '@angular/material';
import { DogDetailsComponent } from '../dog-details/dog-details.component';

@Component({
  selector: 'app-found-dogs',
  templateUrl: './found-dogs.component.html',
  styleUrls: ['./found-dogs.component.css']
})
export class FoundDogsComponent implements OnInit {

  public dogs: IDog[]

  constructor(private dogService: DogService, private authService: AuthenticationService, private dialog: MatDialog) { }

  ngOnInit() {
    this.dogService.getAdoptedAndFoundDogs().subscribe (
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

  deleteDog(dog: IDog){
    this.dogService.deleteDog(dog).subscribe(res => {
      this.dogService.getAdoptedAndFoundDogs().subscribe (
        result => {
          console.log(result);
          this.dogs = result;
        },
        error => {
          this.authService.logOut();
        }
      )
    })
  }

}

