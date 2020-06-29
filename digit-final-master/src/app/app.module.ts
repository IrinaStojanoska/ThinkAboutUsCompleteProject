import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import {BrowserAnimationsModule} from '@angular/platform-browser/animations';

import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CarouselComponent } from './components/carousel/carousel.component';
import { HomeTileComponent } from './components/home-tile/home-tile.component';
import { HomeComponent } from './components/home/home.component';
import {  MatTheme } from './theme-lib';
import { FindDogComponent } from './components/find-dog/find-dog.component';
import { MatDialogModule} from '@angular/material/dialog';
import { DogDetailsComponent } from './components/dog-details/dog-details.component';
import { ReportComponent } from './components/report/report.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FooterComponent } from './components/footer/footer.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { AdoptDogComponent } from './components/adopt-dog/adopt-dog.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { LoginComponent } from './components/login/login.component';
import { NavbarComponent } from './components/navbar/navbar.component';
import { ReportsListComponent } from './components/reports-list/reports-list.component';
import { AdoptedDogsComponent } from './components/adopted-dogs/adopted-dogs.component';
import { FoundDogsComponent } from './components/found-dogs/found-dogs.component';

@NgModule({
  declarations: [
    AppComponent,
    CarouselComponent,
    HomeTileComponent,
    HomeComponent,
    FindDogComponent,
    DogDetailsComponent,
    ReportComponent,
    FooterComponent,
    ContactUsComponent,
    AdoptDogComponent,
    AboutUsComponent,
    LoginComponent,
    NavbarComponent,
    ReportsListComponent,
    AdoptedDogsComponent,
    FoundDogsComponent
  ],
  entryComponents: [
    //za poopup dialogot mora vie entryComponents da se dodadat
    DogDetailsComponent
  ],
  imports: [
    MatTheme,
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MatDialogModule,
    FormsModule,
    ReactiveFormsModule
    ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
