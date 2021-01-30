import { Injectable } from "@angular/core";
import { HttpClient, HttpHeaders } from "@angular/common/http";

@Injectable({
  providedIn: "root",
})
export class ApiService {
  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    "Content-Type": "application/json",
  });
  baseUrl = "api/";

  getLevels() {
    return this.http.get<any>(this.baseUrl + "LearnLevel");
  }
  getLevelsT() {
    return this.http.get<any>(this.baseUrl + "TestLevel");
  }

  getCategories() {
    return this.http.get<any>(this.baseUrl + "Categories");
  }

  getUserLearnLevelByCategoryId(userId: string, categoryId: string) {
    return this.http.get<any>(
      this.baseUrl + "UserLearnLevel/user/" + userId + "/category/" + categoryId
    );
  }

  getLearnScores() {
    return this.http.get<any>(this.baseUrl + "UserLearnLevel/scores");
  }

  passLearnLevel(userId: string, learnLevelId: string) {
    return this.http.get<any>(
      this.baseUrl +
        "User/passLearn/user/" +
        userId +
        "/learnLevel/" +
        learnLevelId
    );
  }

  getUserTestLevelByCategoryId(userId: string, categoryId: string) {
    return this.http.get<any>(
      this.baseUrl + "UserTestLevel/user/" + userId + "/category/" + categoryId
    );
  }

  getTestScores() {
    return this.http.get<any>(this.baseUrl + "UserTestLevel/scorestest");
  }

  passTestLevel(userId: string, testLevelId: string) {
    return this.http.get<any>(
      this.baseUrl +
        "User/passTest/user/" +
        userId +
        "/testLevel/" +
        testLevelId
    );
  }

  registerUser(user) {
    return this.http.post<any>('/api/User/register', user);
  }
}
