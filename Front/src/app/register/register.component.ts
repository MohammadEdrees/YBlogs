import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators ,FormBuilder} from '@angular/forms'
import { UserService } from '../Services/user.service';
import { User } from '../Models/User';
import {Router} from '@angular/router'
@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  
  constructor(private userServices:UserService,private router:Router) { }
  
  user = new User();
  role!:string;
  errflag = false;
  successflag=false;

  ngOnInit(): void {
    
    
  }

  registerForm = new FormGroup({
    UserName:new FormControl(),
    Email:new FormControl(),
    Password:new FormControl(),
    Role:new FormControl()

  })

  onSubmit() {
    let userControl=this.registerForm.controls["UserName"].value;
    let emailControl=this.registerForm.controls["Email"].value;
    let passwordControl=this.registerForm.controls["Password"].value;
    let roleControl=this.registerForm.controls["Role"].value;

    if(userControl!=null && emailControl!=null &&passwordControl!=null &&
       roleControl!=null && userControl!="" && emailControl!=""
        && passwordControl!="" && roleControl!="" ){
      this.errflag=false;
      this.registerUser();
     }
    else{
      this.errflag=true;
      console.log('complete your values plz',this.errflag);
      
    }
  }
  
  registerUser(){
    this.user.UserName=this.registerForm.controls["UserName"].value;
    this.user.Email=this.registerForm.controls["Email"].value;
    this.user.Password=this.registerForm.controls["Password"].value;
    this.role=this.registerForm.controls["Role"].value;

    console.log(this.user,this.role);
    
    this.userServices.CreateUser(this.user,this.role).subscribe(success=>{
      console.log(success);
      this.successflag=true;
      this.goTologin();
    },
    error=>{
      console.log(error);
    })
 
  }

  goTologin(){
    this.router.navigate(['login']);
  }
  

}
