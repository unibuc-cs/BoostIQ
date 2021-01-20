import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { ApiService } from 'src/app/shared/api.service';
import { AuthService } from 'src/app/shared/services/auth-service';

@Component({
  selector: 'app-learn-category',
  templateUrl: './learn-category.component.html',
  styleUrls: ['./learn-category.component.css']
})
export class LearnCategoryComponent implements OnInit {

  public learnLevel;

  constructor(private activatedRoute: ActivatedRoute, private authService: AuthService, private api: ApiService) { }

  ngOnInit() {
    let categoryId = this.activatedRoute.snapshot.paramMap.get("id");
    let userId = this.authService.getUserId();

    this.api.getUserLearnLevelByCategoryId(userId, categoryId).subscribe(learnLevel => {
      this.learnLevel = learnLevel;
    })
  }

}
