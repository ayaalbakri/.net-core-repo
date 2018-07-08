import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  logIn: { UserName: string; Password: string; };
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
