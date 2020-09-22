import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html'
})
export class QuizComponent {
  public quiz: Quiz;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    this.getQuiz();
    
  }

  getQuiz(): void {
    const id : string   = this.route.snapshot.paramMap.get('id');
    this.http.get<Quiz>(this.baseUrl + 'api/quizzes/'+id).subscribe(result => {
      this.quiz = result;
    }, error => console.error(error));
  }
}



interface Quiz {
  id: string;
  title: string;
  ownerId: string;
}
