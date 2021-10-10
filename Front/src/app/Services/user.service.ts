import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { User } from '../Models/User';
import { Observable } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class UserService {
  
  constructor(private http:HttpClient) { }

  CreateUser(user:User,role:string){
    return this.http.post('http://localhost:44920/user/register/?role='+role,user,{responseType:'text'})
  }

  login(email:string,password:string):Observable<any>{
    const httpOptions = {
      headers: new HttpHeaders({'Content-Type': 'application/json'})
    }
    return this.http.post('http://localhost:44920/user/login/?mail='+email+'&password='+password,null, httpOptions);
  }
  getRoleByMail(mail:string):Observable<any>{
    return this.http.get('http://localhost:44920/user/GetRoleByMail/?mail='+mail,{responseType:'text'});

  }

}
