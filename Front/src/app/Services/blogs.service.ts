import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Article } from '../Models/Article';

@Injectable({
  providedIn: 'root'
})
export class BlogsService {

  constructor(private http:HttpClient) { }

  getAllAeticles():Observable<any>{
   return this.http.get("http://localhost:44920/article/GetAllArticles")
  }

  filterArticlesByCategory(name:string):Observable<any>{
    return this.http.get("http://localhost:44920/article/ArticlesByCategory/?category="+name)
  }

  updateArticle(id:Number,article:Article):Observable<any>{
    return this.http.put("http://localhost:44920/article/UpdateArticle/?oldId="+id,article)
  }
  createArticle(article:Article){
    return this.http.post('http://localhost:44920/article/Create',article,{responseType:'json'})
  }
  
  getArticleById(id:Number):Observable<any>{
    return this.http.get("http://localhost:44920/article/GetArticleById/?id="+id);
  }
}
