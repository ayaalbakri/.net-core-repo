import { Component, OnInit } from '@angular/core';
import { SignIn } from '../shared/sign.model';
import { UserService } from '../shared/user.service';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-sign-in',
  templateUrl: './sign-in.component.html',
  styleUrls: ['./sign-in.component.css']
})
export class SignInComponent implements OnInit {
  logIn: SignIn;
  pwdPattern = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}";

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.logIn = {
      Email: '',
      Password: '',
    }
  }
  onlogInSubmit(logIn) {
    console.log("onFormSubmit", logIn);
    //this.userService.userAuthentication(logIn)
      this.userService.userAuthentication(logIn).subscribe((data:any )=>{

        console.log("datatataatat",data);
        console.log(data.result.succeeded,"data.result.succeeded")
        if(data.result.succeeded){
          console.log("nda,snd,masnd,amdn,");
         this.ngOnInit();
        }
    }), error => console.log(error,"   errrrrrrrrrror"); 
  }

}
