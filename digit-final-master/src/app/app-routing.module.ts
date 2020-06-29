import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { FindDogComponent } from './components/find-dog/find-dog.component'
import { HomeComponent } from './components/home/home.component';
import { ReportComponent } from './components/report/report.component';
import { ContactUsComponent } from './components/contact-us/contact-us.component';
import { AdoptDogComponent } from './components/adopt-dog/adopt-dog.component';
import { AboutUsComponent } from './components/about-us/about-us.component';
import { LoginComponent } from './components/login/login.component';
import { AuthGuard } from './services/authguard.service';
import { ReportsListComponent } from './components/reports-list/reports-list.component';
import { AdoptedDogsComponent } from './components/adopted-dogs/adopted-dogs.component';
import { FoundDogsComponent } from './components/found-dogs/found-dogs.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'find', component: FindDogComponent },
  { path: 'adopt', component: AdoptDogComponent },
  { path: 'home', component: HomeComponent},
  { path: 'report', component: ReportComponent},
  { path: 'contact', component: ContactUsComponent},
  { path: 'about', component:AboutUsComponent},
  { path: 'login', component:LoginComponent },
  { path: 'reports', component:ReportsListComponent, canActivate: [AuthGuard]},
  { path: 'adoptedDogs', component:AdoptedDogsComponent, canActivate: [AuthGuard]},
  { path: 'foundDogs', component:FoundDogsComponent, canActivate: [AuthGuard]}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
