import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class RoleGuard implements CanActivate {
  canActivate(){

   let role = localStorage.getItem('role');
   if(role==null){
    alert('Login First Please')
     return false;
   }
   if(role=='admin'){
     return true;
   }
   alert('You Must Be Admin')
    return false;
  }
  
  
}
