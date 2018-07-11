import { Component, OnInit } from '@angular/core';
import { Route } from '@angular/compiler/src/core';
import { Router } from '@angular/router';
import { UserService } from '../user/shared/user.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  email : string;
  constructor(private router : Router, private userService: UserService) {}
  ngOnInit() {
    this.userService.getToken().subscribe((data:any )=>{

      console.log("datatataatat",data);
      //console.log(data.result.succeeded,"data.result.succeeded")
      // // localStorage.getItem("token");
      this.email = data;
      if(data.result.succeeded){
      //  console.log("nda,snd,masnd,amdn,");
       //this.ngOnInit();
      }
  }), error => console.log(error,"   errrrrrrrrrror"); 
  }
  LogOut(){
    console.log("hiiiiii Log OUt");
    localStorage.removeItem('token');
    this.router.navigate(["login"]);
  }
}
