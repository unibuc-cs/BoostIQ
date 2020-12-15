import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { map } from 'rxjs/operators'; 

@Injectable({    
    providedIn: 'root'    
  })    
  export class AuthService {    
      
    constructor(private http: HttpClient, private router: Router) { }    
      
    public login(loginRequest) {    
      return this.http.post<any>('/api/login', loginRequest)    
        .pipe(map(response => {    
          localStorage.setItem('authToken', response.token);    
          localStorage.setItem('username', response.userDetails.username);
          localStorage.setItem('userId', response.userDetails.userEntityId);
          return response;    
        }));    
    }    

    public isAuthenticated() {
        return localStorage.getItem('authToken') != null;
    }

    public getUsername() {
        return localStorage.getItem('username');
    }

    public getUserId () {
        return localStorage.getItem('userId');
    }
      
    public logout() {    
      localStorage.removeItem('authToken');    
      localStorage.removeItem('username');  
      localStorage.removeItem('userId');  
      this.router.navigate(['/login']);    
    }    
  }    
