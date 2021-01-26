import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';


import { AppComponent } from './app.component';
import { AppRoutingModule, routingComponents } from './app-routing.module';
import {  MatCardModule,
          MatTabsModule,
          MatFormFieldModule,
          MatInputModule,
          MatButtonModule,
          MatCheckboxModule,
          MatIconModule,
          MatToolbarModule,
          MatListModule, 
          //MatSelectionListModule,
          MatSortModule,
          MatTableModule,

        }
           from  '@angular/material';


import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterLoginComponent } from './register-login/register-login.component';
import { CommonModule } from '@angular/common';
import { JwtTokenInterceptorService } from './shared/interceptors/jwt-token-interceptor';
import { AboutUsPageComponent } from './about-us-page/about-us-page.component';



@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    RegisterLoginComponent,
    AboutUsPageComponent,
    AboutUsPageComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    CommonModule,
    FormsModule,    
    ReactiveFormsModule, 
    HttpClientModule,
    MatToolbarModule,
    MatListModule,
    MatButtonModule,
    MatIconModule,
    FormsModule,
    MatCardModule,
    MatTabsModule,
    MatFormFieldModule,
    MatInputModule,
    MatCheckboxModule,
    //MatSelectionListModule,
    MatSortModule,
    MatTableModule,
    AppRoutingModule
  ],
  providers: [{ provide: HTTP_INTERCEPTORS, useClass: JwtTokenInterceptorService, multi: true }], 
  bootstrap: [AppComponent,]
  
})
export class AppModule {
  
 }
