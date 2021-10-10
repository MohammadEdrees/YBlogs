import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl } from '@angular/forms';
import { Router } from '@angular/router';
import { Category } from '../Models/Category';
import { CategoryService } from '../Services/category.service';

@Component({
  selector: 'app-create-category',
  templateUrl: './create-category.component.html',
  styleUrls: ['./create-category.component.css']
})
export class CreateCategoryComponent implements OnInit {
  category=new Category();

  constructor(private router:Router,
    private categoryServices:CategoryService) { }

  ngOnInit(): void {
  }
  CreateForm = new FormGroup({
    articleTitle:new FormControl(),
    articleBody:new FormControl(),
    Author:new FormControl(),
    CategoryId:new FormControl(),
    Category:new FormControl()

  })
  CreateCategory(){
    
    this.category.categoryTitle=this.CreateForm.controls['Category'].value;
    console.log(this.category);
    this.categoryServices.createCategory(this.category).subscribe(
      data=>{
        console.log(data);
        this.category=data;
        
      },err=>{
        console.log(err)
      }
    )
  }
  goToHome(){
    this.router.navigate(['blogs'])
   }

}
