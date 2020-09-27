import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html'
})
export class RegisterComponent {
  public registerUser: RegisterUser;

  constructor(private http: HttpClient, @Inject('BASE_URL') private baseUrl: string, private route: ActivatedRoute) {
    this.registerUser = { username: '', password: '', email: '', confirmpassword: '' };
  }

  submit(): void {
    console.log(this.registerUser, this.baseUrl);
    this.http.post<RegisterUser>(this.baseUrl + 'api/accounts/register', this.registerUser).subscribe();
  }
}

interface RegisterUser {
  email: string;
  username: string;
  password: string;
  confirmpassword: string;
}
