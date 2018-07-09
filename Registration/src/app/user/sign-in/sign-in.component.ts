import { Component, OnInit } from '@angular/core';
import { SignIn } from '../shared/sign.model';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  logIn: SignIn;
  pwdPattern = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}";

  constructor() { }

  ngOnInit() {
    this.logIn={
      UserName:'',
      Password:'',
    }
  }
  onFormSubmit(logIn){
    console.log("onFormSubmit",logIn);
  }

}
