import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { first } from 'rxjs/operators';
import { ApiService } from '../shared/api.service';
import { AuthService } from '../shared/services/auth-service';

@Component({
  selector: 'app-register-login',
  templateUrl: './register-login.component.html',
  styleUrls: ['./register-login.component.css']
})
export class RegisterLoginComponent implements OnInit {
  loginForm: FormGroup;
  registerForm: FormGroup;
  constructor(private formBuilder: FormBuilder,    
    private route: ActivatedRoute,    
    private router: Router,    
    private authService: AuthService,
    private apiService: ApiService) { }

  ngOnInit() {
    this.loginForm = this.formBuilder.group({    
      username: ['', Validators.required],    
      password: ['', Validators.required]    
    });    
    this.registerForm = this.formBuilder.group({    
      username: ['', Validators.required],    
      email: ['', Validators.compose([Validators.required,Validators.email])],    
      password: ['', Validators.compose([Validators.required,Validators.minLength(6)])]    
    });    
  }

  onLoginSubmit() {    
    if (this.loginForm.invalid) {    
      return;    
    }    
    const returnUrl = this.route.snapshot.queryParamMap.get('returnUrl') || '/';    
    this.authService.login(this.loginForm.value)    
      .pipe(first())    
      .subscribe(    
        () => {    
          this.router.navigate([returnUrl]);    
        },    
        () => {    
          this.loginForm.reset();    
          this.loginForm.setErrors({    
            invalidLogin: true    
          });    
        });    
  } 

  onRegisterSubmit() {
    if(this.registerForm.invalid) {
      return;
    }

    this.apiService.registerUser(this.registerForm.value).subscribe(result => {
      alert('Success!');
    })

  }

}
