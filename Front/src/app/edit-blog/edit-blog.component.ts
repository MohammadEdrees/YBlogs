import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Article } from '../Models/Article';
import { BlogsService } from '../Services/blogs.service';

@Component({
  selector: 'app-edit-blog',
  templateUrl: './edit-blog.component.html',
  styleUrls: ['./edit-blog.component.css']
})
export class EditBlogComponent implements OnInit {
  id!:Number;
  Article = new  Article();
  constructor(private router:ActivatedRoute,private blogServices:BlogsService,private rout:Router) { }

  ngOnInit(): void {
    this.getArticle();
  }
  getArticle(){
    let id =this.router.snapshot.params['id'];
    this.blogServices.getArticleById(id).subscribe(data=>{
      console.log(data)
      this.EditForm.controls['articleTitle'].setValue(data.articleTitle)
      this.EditForm.controls['articleBody'].setValue(data.articleBody)
      this.id=data.articleId;
      
    },err=>{
      console.log(err)
    })
  }
  EditForm = new FormGroup({
    articleTitle:new FormControl(),
    articleBody:new FormControl()

  })
  updateArticle(){
    this.Article.articleTitle=this.EditForm.controls['articleTitle'].value;
    this.Article.articleBody=this.EditForm.controls['articleBody'].value;
    this.blogServices.updateArticle(this.id,this.Article).subscribe(data=>{
      console.log(data);
    },err=>{
      console.log(err)
    })
  }
  back(){
    this.rout.navigate(['blogs'])
  }

}
