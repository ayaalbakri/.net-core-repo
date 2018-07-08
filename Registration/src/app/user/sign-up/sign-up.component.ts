import { Component, OnInit } from '@angular/core';
import { User } from '../shared/user.model';
import { UserService } from '../shared/user.service';
// import { FormsModule } from '@angular/forms';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-sign-up',
  templateUrl: './sign-up.component.html',
  styleUrls: ['./sign-up.component.css']
})
export class SignUpComponent implements OnInit {
  registration:User;
  emailPattern = "^[a-z0-9._%+-]+@[a-z0-9.-]+\.[a-z]{2,3}$";
  pwdPattern = "(?=.*[a-z])(?=.*[A-Z])(?=.*[0-9])(?=.*[$@$!%*?&])[A-Za-z\d$@$!%*?&].{8,}";
  constructor(private userService : UserService) { }

  ngOnInit() {
this.registration={
  UserName:'',
  Email:'',
  FirstName:'',
  LastName:'',
  Password:'',
  confirmPassword:''
}

  }
  onFormSubmit(registration){
      console.log("registration",this.userService.registerUser(registration));
      this.userService.registerUser(registration).subscribe((data:any )=>{
     
          console.log("datatataatat",data);
          console.log(data.result.succeeded,"data.result.succeeded")
          if(data.result.succeeded){
            console.log("nda,snd,masnd,amdn,");
           this.ngOnInit();
          }
      }), error => console.log(error,"   errrrrrrrrrror");
  }


}
