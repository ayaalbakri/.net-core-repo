import { UserComponent } from "./user/user.component";
import { SignInComponent } from "./user/sign-in/sign-in.component";
import { HomeComponent } from "./home/home.component";
import { SignUpComponent } from "./user/sign-up/sign-up.component";
import { Routes } from "@angular/router";
import { AuthGuard } from "./Auth/auth.guard";

export const routes: Routes = [
    {path:'home',component:HomeComponent,canActivate:[AuthGuard]},
    {path:'signup',component:UserComponent,
    children:[{path:'',component:SignUpComponent}]},
    {path:'login',component:UserComponent,
    children:[{path:'',component:SignInComponent}]},
    {path:'',redirectTo:'login',pathMatch:'full'},
    ];