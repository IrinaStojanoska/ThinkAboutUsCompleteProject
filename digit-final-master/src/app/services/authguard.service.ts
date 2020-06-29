import { Injectable } from '@angular/core';
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthenticationService } from '../services/authentication.service';


@Injectable({
  providedIn: 'root'
})

export class AuthGuard implements CanActivate {

  constructor(
    private authenticationService: AuthenticationService,
    private router: Router) {}

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {

        // handle any redirects if a user isn't authenticated
        if (!this.authenticationService.isAdminLoggedIn()) {
          // redirect the user
          console.log("Not authorized for that site without a login");
          this.router.navigate(['/login']);
          return false;
        }
    return true;
  }
}
