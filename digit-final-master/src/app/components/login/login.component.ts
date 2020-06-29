import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { Router } from "@angular/router";
import { AuthenticationService } from "../../services/authentication.service";
import { User } from '../../models/user';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  
  loginForm: FormGroup;
  submitted: boolean = false;
  

  constructor(
    private formBuilder: FormBuilder, 
    private router: Router, 
    private authService: AuthenticationService) { }

  onSubmit() {
   
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    }
    let user = {
      username: this.loginForm.controls.userName.value,
      password: this.loginForm.controls.password.value,
    }

    this.authService.createToken(user);
  }
  

  ngOnInit() {
    if(this.authService.isAdminLoggedIn()){
      this.router.navigate(["/"]);
    }
    this.loginForm = this.formBuilder.group({
      userName: ['', Validators.required],
      password: ['', Validators.required]
    });
  }
}