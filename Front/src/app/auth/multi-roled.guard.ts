import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class MultiRoledGuard implements CanActivate {
  canActivate(){

    let role = localStorage.getItem('role');
    if(role==null){
     alert('Login First Please')
      return false;
    }
    if(role=='admin'||role=='moderator'){
      return true;
    }
    alert('You Must Be Admin or moderator')
     return false;
   }
   
}
