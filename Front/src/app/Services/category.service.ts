import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Category } from '../Models/Category';

@Injectable({
  providedIn: 'root'
})
export class CategoryService {

  constructor(private http:HttpClient) { }

  GetAllCategories():Observable<any>{
    return this.http.get("http://localhost:44920/category/GetAllCategories",{responseType:'json'})
   }

   createCategory(category:Category):Observable<any>{
   
     return this.http.post('http://localhost:44920/category/create',category)
   }
}
