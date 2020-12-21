import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';



@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    'Content-Type': 'application/json',
  });
  baseUrl = 'api/';
 
  getLevels() {
    return this.http.get<any>(this.baseUrl + 'LearnLevel');
  }

  getCategory(){
    return this.http.get<any>(this.baseUrl + 'Categories');
  }
  
}

