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

  getCategories(){
    return this.http.get<any>(this.baseUrl + 'Categories');
  }

  getUserLearnLevelByCategoryId(userId: string, categoryId: string){
    return this.http.get<any>(this.baseUrl + 'UserLearnLevel/user/' + userId + "/category/" + categoryId);
  }
  
}

