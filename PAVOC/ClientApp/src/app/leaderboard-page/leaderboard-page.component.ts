import { Component, OnInit, ViewChild, AfterViewInit } from '@angular/core';
import {MatSort} from '@angular/material/sort';
import {MatTableDataSource} from '@angular/material/table';


export interface Learn {
  position_learn: number;
  username_learn: string;
  score_learn: number;

}

export interface Play{
  position_play: number;
  username_play: string;
  score_play: number;
}

const ELEMENT_DATA: Learn[] = [
  {position_learn: 1, username_learn: 'Snake', score_learn: 1250},
  {position_learn: 2, username_learn: 'Ghost', score_learn: 940},
  {position_learn: 3, username_learn: 'Raven', score_learn: 780},
  {position_learn: 4, username_learn: 'Predator', score_learn: 660},
  {position_learn: 5, username_learn: 'Nightmare', score_learn: 610},
  {position_learn: 6, username_learn: 'Zero', score_learn: 590},
  {position_learn: 7, username_learn: 'Nemesis', score_learn: 420},
  {position_learn: 8, username_learn: 'Joker', score_learn: 330},
  {position_learn: 9, username_learn: 'Phoenix', score_learn: 230},
  {position_learn: 10, username_learn: 'Storm', score_learn: 110}
];

const ELEMENT_DATA_PLAY: Play[] = [
  {position_play: 1, username_play: 'Snake', score_play: 4244},
  {position_play: 2, username_play: 'Ghost', score_play: 2341},
  {position_play: 3, username_play: 'Raven', score_play: 2198},
  {position_play: 4, username_play: 'Predator', score_play: 1771},
  {position_play: 5, username_play: 'Nightmare', score_play: 1253},
  {position_play: 6, username_play: 'Zero', score_play: 1053},
  {position_play: 7, username_play: 'Nemesis', score_play: 972},
  {position_play: 8, username_play: 'Joker', score_play: 731},
  {position_play: 9, username_play: 'Phoenix', score_play: 491},
  {position_play: 10, username_play: 'Storm', score_play: 159}
];




@Component({
  selector: 'app-leaderboard-page',
  templateUrl: './leaderboard-page.component.html',
  styleUrls: ['./leaderboard-page.component.css']
})


export class LeaderboardPageComponent implements OnInit {
  displayedColumnsPlay: string[] = ['position_play', 'username_play', 'score_play'];
  dataSourcePlay = new MatTableDataSource(ELEMENT_DATA_PLAY);
  
  displayedColumnsLearn: string[] = ['position_learn', 'username_learn', 'score_learn'];
  dataSourceLearn = new MatTableDataSource(ELEMENT_DATA);

  @ViewChild(MatSort, {static:false}) sort: MatSort;
  
  
  ngAfterViewInit() {
    this.dataSourceLearn.sort = this.sort;
    this.dataSourcePlay.sort = this.sort;
  }
  ngOnInit(){
    
  }
}