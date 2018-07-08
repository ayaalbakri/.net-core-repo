import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { User } from './user.model';
import { Observable } from 'rxjs';

HttpClient
@Injectable({
  providedIn: 'root'
})
export class UserService {
  readonly rootUrl = "http://localhost:51833";

  constructor(private http:HttpClient) { }

  registerUser(user : User){
    const body : User ={
      UserName : user.UserName,
     Email:user.Email,
     FirstName:user.FirstName,
     LastName:user.LastName,
     Password:user.Password,
     confirmPassword:user.confirmPassword
    }
   
    return this.http.post(this.rootUrl+'/api/Account',body);
  }
}
