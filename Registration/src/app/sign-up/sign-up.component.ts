import { Component, OnInit } from '@angular/core';
import { User } from '../shared/user.model';
// import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  registration:User;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
  pwdPattern = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}";
  constructor() { }

  ngOnInit() {
this.registration={
  UserName:'',
  Email:'',
  FirstName:'',
  LastName:'',
  Psaaword:'',
  confirmPassword:''
}

  }
  onFormSubmit(registration){
      console.log("registration",registration);
  }


}
