import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CommentsComponent } from './comments/comments.component';
import { LoginComponent } from './login/login.component';
import { NewArticleComponent } from './new-article/new-article.component';


const routes: Routes = [];

@NgModule({
  imports: [RouterModule.forRoot([
    {path:'' , redirectTo:'home',pathMatch:'full'},
    {path:'home' ,component:HomeComponent},
    {path:'comments/:id',component:CommentsComponent},
    {path:'login',component:LoginComponent},
    {path:'newArticle',component:NewArticleComponent}
  ])],
  exports: [RouterModule]
})
export class AppRoutingModule { }
