import { Injectable } from '@angular/core';    
import { CanActivate, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree, Router } from '@angular/router';    
import { Observable } from 'rxjs';    
import { AuthService } from '../services/auth-service';
    
@Injectable({    
  providedIn: 'root'    
})    
export class AuthGuard implements CanActivate {    
  userDataSubscription: any;    
  constructor(private router: Router, private authService: AuthService) {  
  }    
  canActivate(    
    next: ActivatedRouteSnapshot,    
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {    
    
    if (this.authService.isAuthenticated()) {    
      return true;    
    }    
    
    this.router.navigate(['/login-register'], { queryParams: { returnUrl: state.url } });    
    return false;    
  }    
}    