import { Component, OnInit } from "@angular/core";
import { ActivatedRoute } from "@angular/router";
import { ApiService } from "src/app/shared/api.service";
import { AuthService } from "src/app/shared/services/auth-service";

@Component({
  selector: "app-play-category",
  templateUrl: "./play-category.component.html",
  styleUrls: ["./play-category.component.css"],
})
export class PlayCategoryComponent implements OnInit {
  public testLevel;

  public textDisplayed: boolean = false;
  public questionsDisplayed: boolean = false;
  public resultDisplayed: boolean = false;
  public finishedAllLevels: boolean = false;

  public question;
  public questionOrder: number;

  public answers = {};

  public passedLevel: boolean;

  constructor(
    private activatedRoute: ActivatedRoute,
    private authService: AuthService,
    private api: ApiService
  ) {}

  ngOnInit() {
    let categoryId = this.activatedRoute.snapshot.paramMap.get("id");
    let userId = this.authService.getUserId();

    this.api
      .getUserTestLevelByCategoryId(userId, categoryId)
      .subscribe((testLevel) => {
        if (testLevel) {
          this.textDisplayed = true;
          this.testLevel = testLevel;
        } else {
          this.finishedAllLevels = true;
        }
      });
  }

  selectAnswer(answerId) {
    var alreadySelected = this.answers[this.questionOrder];
    if (alreadySelected) {
      document.getElementById("answer" + alreadySelected).style.background =
        "none"; // clear old selection
    }

    this.answers[this.questionOrder] = answerId;
  }

  getBackgroundColor(answerId) {
    var answer = this.answers[this.questionOrder];
    if (answer == answerId) {
      return "green";
    } else {
      return "none";
    }
  }

  goToQuestions() {
    this.textDisplayed = false;
    this.questionsDisplayed = true;
    this.questionOrder = 1;
    this.question = this.testLevel.testQuestions.find(
      (p) => p.order == this.questionOrder
    );
  }

  previousQuestion() {
    this.questionOrder--;
    this.question = this.testLevel.testQuestions.find(
      (p) => p.order == this.questionOrder
    );
  }

  nextQuestion() {
    this.questionOrder++;
    this.question = this.testLevel.testQuestions.find(
      (p) => p.order == this.questionOrder
    );
  }

  finish() {
    this.questionsDisplayed = false;
    this.resultDisplayed = true;

    let totalQuestions = this.testLevel.testQuestions.length;
    let correctAnswers = 0.0;

    this.testLevel.learnQuestions.forEach((testQuestion) => {
      let answer = this.answers[testQuestion.order];
      if (answer) {
        let correctAnswer = testQuestion.testQuestionAnswers.find(
          (p) => p.isCorrect
        );
        if (correctAnswer.testQuestionAnswerEntityId == answer) {
          correctAnswers++;
        }
      }
    });

    let score = correctAnswers / totalQuestions;
    if (score >= 0.5) {
      this.passedLevel = true;
      this.api
        .passLearnLevel(
          this.authService.getUserId(),
          this.testLevel.testLevelEntityId
        )
        .subscribe((result) => {});
    } else {
      this.passedLevel = false;
    }
  }

  reloadPage() {
    window.location.reload();
  }
}
