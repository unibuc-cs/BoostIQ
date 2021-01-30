import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';
import { ApiService } from '../shared/api.service';


export interface Score{
  position: number;
  username: string;
  score: number;
}

@Component({
  selector: 'app-leaderboard-page',
  templateUrl: './leaderboard-page.component.html',
  styleUrls: ['./leaderboard-page.component.css']
})


export class LeaderboardPageComponent implements OnInit {
  
  displayedColumns: string[] = ['position', 'username', 'score'];
  dataSourceLearn;
  dataSourceTest;

  @ViewChild(MatSort, {static:false}) sort: MatSort;
  
  constructor(private apiService:ApiService) {

  }
  ngOnInit(){
    this.apiService.getLearnScores().subscribe((scores: Score[])=> {
      this.dataSourceLearn = new MatTableDataSource(scores);
      this.dataSourceLearn.sort = this.sort;
    })

    this.apiService.getTestScores().subscribe((scorestest: Score[])=> {
      this.dataSourceTest = new MatTableDataSource(scorestest);
      this.dataSourceTest.sort = this.sort;
    })

  }

  
}