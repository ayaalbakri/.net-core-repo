import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user.model';
import { Observable } from 'rxjs';
import { SignIn } from './sign.model';

HttpClient
@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = "http://localhost:51833";

  constructor(private http: HttpClient) { }

  registerUser(user: User) {


    return this.http.post(this.rootUrl + '/api/Account', user);
  }
  userAuthentication(model: SignIn) {
    console.log(model)
    return this.http.post(this.rootUrl+'/api/Account/login',model);
  }
}
