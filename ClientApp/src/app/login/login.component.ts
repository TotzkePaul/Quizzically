import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  public login: Login;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    this.login = { username: '', password: '' };
  }

  submit(): void {
    console.log(this.login, this.baseUrl);
    this.http.post<Login>(this.baseUrl + 'api/accounts/login', this.login).subscribe();
  }
}

interface Login {
  username: string;
  password: string;
}
