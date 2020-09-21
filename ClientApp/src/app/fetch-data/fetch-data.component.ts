import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './fetch-data.component.html'
})
export class FetchDataComponent {
  public quizzes: Quiz[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Quiz[]>(baseUrl + 'api/quizzes/all').subscribe(result => {
      this.quizzes = result;
    }, error => console.error(error));
  }
}

interface Quiz {
  id: string;
  title: string;
  ownerId: string;
}
