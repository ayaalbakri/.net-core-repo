import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from './user.model';
import { Observable } from 'rxjs';
import { SignIn } from './sign.model';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = "http://localhost:51833";

  constructor(private http: HttpClient) { }

  registerUser(user: User) {
    //var reqHeader = new HttpHeaders({'No-Auth': 'true'})
    const headers = new HttpHeaders().set('No-Auth', 'true');


    return this.http.post(this.rootUrl + '/api/Account', user,{headers: headers});
  }
  userAuthentication(model: SignIn) {
    // var reqHeader = new HttpHeaders({'No-Auth': 'True'})
    const headers = new HttpHeaders().set('No-Auth', 'true');
    console.log(headers,"reqHeaderreqHeaderreqHeaderreqHeader")
    return this.http.post(this.rootUrl+'/api/Account/login',model,{headers:headers});
  }

  getToken(){
    return this.http.get(this.rootUrl+'/api/Account');
  }
}
