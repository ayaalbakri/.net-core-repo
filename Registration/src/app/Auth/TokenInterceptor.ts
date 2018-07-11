import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Router } from '@angular/router';
//import { AuthService } from '';
import { Observable } from 'rxjs/Observable';   
import { error } from '@angular/compiler/src/util';
import { map, filter, tap } from 'rxjs/operators';
import { UserService } from '../user/shared/user.service';

@Injectable()
export class TokenInterceptor implements HttpInterceptor {
  //  inj: any;
  constructor(private router: Router) {}
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
   // const auth = this.inj.get(UserService);
   
    if (request.headers.get('No-Auth')=="true") {
        console.log("NOOOOTTTOOOJKKKEEEn")
        return next.handle(request.clone());
    }
        if(localStorage.getItem('token')!=null){
         const tokenreq=   request.clone({headers:request.headers.set("Authorization","Bearer "+localStorage.getItem('token'))
        });
       // return next.handle(tokenreq);
        return next.handle(tokenreq).pipe(
            tap(event => {
              console.log("hiiii");
            } ,error => {
                if(error.status == 401){
                    this.router.navigate(['/login'])
                }
                this.router.navigate(['/login'])
              })
            );
        }
        else{
            console.log("kdjladjdladlk")
            this.router.navigate(['/login']);
        }
    }
}
