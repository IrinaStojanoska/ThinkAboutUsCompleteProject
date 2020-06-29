import { Component, OnInit } from '@angular/core';
import { AuthenticationService } from 'src/app/services/authentication.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.sass']
})
export class NavbarComponent implements OnInit {

  isAuthenticated: boolean;

  constructor(private authSrevice: AuthenticationService, private router: Router) { }

  ngOnInit() {
    this.isAuthenticated = this.authSrevice.isAdminLoggedIn();
  }

  login(){
    this.router.navigate(['/login']);
  }

  logout(){
    this.authSrevice.logOut();
  }
}
