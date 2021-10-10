import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { BlogsComponent } from './blogs/blogs.component';
import { CreateBlogComponent } from './create-blog/create-blog.component'; 
import { EditBlogComponent } from './edit-blog/edit-blog.component';
import { AuthGuard } from './auth/auth.guard';
import { RoleGuard } from './auth/role.guard';
import { MultiRoledGuard } from './auth/multi-roled.guard';
import { CreateCategoryComponent } from './create-category/create-category.component';


const routes: Routes = [
  {path:"",redirectTo:"login",pathMatch:'full'},
  {path:"register",component:RegisterComponent},
  {path:"login",component:LoginComponent},

  {path:"blogs",component:BlogsComponent,canActivate:[AuthGuard]},

  {path:"createblog",component:CreateBlogComponent,canActivate:[RoleGuard]},
  {path:"managecategs",component:CreateCategoryComponent,canActivate:[RoleGuard]},
  {path:"edit/:id",component:EditBlogComponent,canActivate:[MultiRoledGuard]}
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
