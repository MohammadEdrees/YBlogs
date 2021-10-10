import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Article } from '../Models/Article';
import { Category } from '../Models/Category';
import { BlogsService } from '../Services/blogs.service';
import { CategoryService } from '../Services/category.service';
import { UserService } from '../Services/user.service';

@Component({
  selector: 'app-blogs',
  templateUrl: './blogs.component.html',
  styleUrls: ['./blogs.component.css']
})
export class BlogsComponent implements OnInit {

  constructor(private router:Router,private blogsServices:BlogsService,
    private categoryServices:CategoryService,
    private userServices:UserService,
    ) { }
  visiblefiltered=false;
  visibleAll=true;
  email!:any;
  articles!: Article[] ;
  filteredarticles!: Article[] ;
  categories!: Category[] ;
  role!:string;


  ngOnInit(): void {
  
     this.getAllBlogs();
     this.getAllCategories();
     let userId = localStorage.getItem('userId');
     let token= localStorage.getItem('token');
     let username = localStorage.getItem('username');
     this.email = localStorage.getItem('Email');
     console.log(userId,token,username);
     this.getRole(this.email);
  }

  FilterForm = new FormGroup({
    Category:new FormControl()
  })

  getAllCategories(){
    this.categoryServices.GetAllCategories().subscribe(
      data=>{
        console.log(data)
        this.categories=data;
      },
      err=>{
        console.log(err)

      }
    )
  }

  getAllBlogs(){
    this.blogsServices.getAllAeticles().subscribe(success=>{

      console.log(success);      
      this.articles=success;
      console.log(this.articles)
    },error=>{
      console.log(error);      

    })
  }

  getRole(email:string){
    this.userServices.getRoleByMail(email).subscribe(
      data=>{
        console.log(data)
        this.role=data;
        localStorage.setItem('role',data);
      },err=>{
        console.log(err)
      }
    )
  }

  filterByCategory(){
    let cat = this.FilterForm.controls['Category'].value;
    console.log(cat);
    this.blogsServices.filterArticlesByCategory(cat).subscribe(data=>{
      console.log(data)
      this.filteredarticles=data;
      console.log(this.filteredarticles);
      this.visiblefiltered=true;
      this.visibleAll=false;
    },err=>{
      console.log(err)
    })
  }

  goCreateblog(){
    this.router.navigate(['createblog']);
  }
  
  reset(){
    this.FilterForm.controls['Category'].setValue('');
    this.visiblefiltered=false;
    this.visibleAll=true;
  }
  logOut(){
    localStorage.clear();
    this.router.navigate(['login']);
  }

  editBlog(id:Number){
    console.log(id);
    this.router.navigate(['edit',id])
  }
  createCategory(){
    this.router.navigate(['managecategs'])
  }
}
