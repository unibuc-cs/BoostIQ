import { Component, OnInit } from "@angular/core";
import { ApiService } from "../shared/api.service";

@Component({
  selector: "app-learn-page",
  templateUrl: "./learn-page.component.html",
  styleUrls: ["./learn-page.component.css"],
})
export class LearnPageComponent implements OnInit {
  public categories;

  constructor(private api: ApiService) {}

  ngOnInit() {
    this.api.getCategories().subscribe((result) => {
      this.categories = result;
    });
  }
}
