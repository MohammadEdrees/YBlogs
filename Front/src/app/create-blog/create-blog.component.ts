import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators ,FormBuilder} from '@angular/forms'
import { Router } from '@angular/router';
import { Article } from '../Models/Article';
import { Category } from '../Models/Category';
import { BlogsService } from '../Services/blogs.service';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-create-blog',
  templateUrl: './create-blog.component.html',
  styleUrls: ['./create-blog.component.css']
})

export class CreateBlogComponent implements OnInit {

  allCategories!:Category[];
  errflag=false;
  category=new Category();
  article=new Article();
  categoryId!:Number;

  constructor(private router:Router,
    private categoryServices:CategoryService,
    private blogsServices:BlogsService) { }

  ngOnInit(): void {
    this.getAllCategries();
  }
  
  CreateForm = new FormGroup({
    articleTitle:new FormControl(),
    articleBody:new FormControl(),
    Author:new FormControl(),
    CategoryId:new FormControl(),
    Category:new FormControl()

  })

  CreateBlog(){
    this.createArticle()
  }

 

  createArticle(){
    this.article.articleTitle= this.CreateForm.controls['articleTitle'].value;
    this.article.articleBody= this.CreateForm.controls['articleBody'].value;
    this.article.categoryId=this.CreateForm.controls['Category'].value;
    


    this.blogsServices.createArticle(this.article).subscribe(
      data=>{
        console.log(data)
        this.goToHome();
      },err=>{
        console.log(err)
      }
    )
  }
  
  goToHome(){
   this.router.navigate(['blogs'])
  }

  getAllCategries(){
    this.categoryServices.GetAllCategories().subscribe(success=>{
      this.allCategories=success;
    },err=>{
      console.log(err);
    })
  }


  

}
