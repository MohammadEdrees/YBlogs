import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators ,FormBuilder} from '@angular/forms'
import { UserService } from '../Services/user.service';
import { User } from '../Models/User';
import {Router} from '@angular/router'

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  errflag=false;
  loginfailedflag=false;
  constructor(private userServics:UserService,private router:Router) { }
  user = new User();
  loggedInUser = new User();
  ngOnInit(): void {
  }

  loginForm = new FormGroup({
    Email:new FormControl(),
    Password:new FormControl()

  });

  assignUserdata(){
    let email = this.loginForm.controls['Email'].value;
    let pass= this.loginForm.controls['Password'].value;
    if(email!=null&&email!=""&&pass!=null&&pass!=""){
      this.user.Email=email;
      this.user.Password=pass;
      console.log(this.user);
      this.login(email,pass);
      this.errflag=false;
    }else{
      this.errflag=true;
      this.loginfailedflag=false;
    }

  }

  login(email:string,password:string){
    this.userServics.login(email,password).subscribe(success=>{
      console.log(success);
      //user
      console.log(success.id);
      console.log(success.token);
      console.log(success.userName);
      console.log(success.email);
      
      localStorage.setItem('userId',success.id);
      localStorage.setItem('token',success.token);
      localStorage.setItem('username',success.userName);
      localStorage.setItem('Email',success.email);

      this.router.navigate(['blogs']);
      

      //navigate

    },err=>{
      this.loginfailedflag=true;
      console.log(err);
    })
   
  }

  gotoRegister(){
    this.router.navigate(['register']);
  }
}
