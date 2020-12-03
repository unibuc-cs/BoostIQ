import { BrowserModule } from '@angular/platform-browser';
import { NgModule, NO_ERRORS_SCHEMA } from '@angular/core';
import { FormsModule } from '@angular/forms';
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
          MatTableModule
        }
           from  '@angular/material';



import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RegisterLoginComponent } from './register-login/register-login.component';
import { CommonModule } from '@angular/common';


@NgModule({
  declarations: [
    AppComponent,
    routingComponents,
    RegisterLoginComponent,
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    BrowserAnimationsModule,
    CommonModule,
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
  providers: [],
  bootstrap: [AppComponent,]
  
})
export class AppModule {
  
 }
