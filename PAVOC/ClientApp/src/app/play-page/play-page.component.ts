import { Component, OnInit } from "@angular/core";
import { ApiService } from "../shared/api.service";

@Component({
  selector: "app-play-page",
  templateUrl: "./play-page.component.html",
  styleUrls: ["./play-page.component.css"],
})
export class PlayPageComponent implements OnInit {
  public categories;

  constructor(private api: ApiService) {}

  ngOnInit() {
    this.api.getCategories().subscribe((result) => {
      this.categories = result;
    });
  }
}
