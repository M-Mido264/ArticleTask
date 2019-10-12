import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from "@angular/common/http";
@Injectable({
  providedIn: 'root'
})
export class ArticleService {
  private readonly baseURL = 'http://localhost:50357/api';
  constructor(private http: HttpClient) { }

  getArticles(){
    return this.http.get(this.baseURL+'/category/articles');
  }
  getArticleCategory(){
    return this.http.get(this.baseURL+'/category');
  }
  getComment(id:number){
    return this.http.get(this.baseURL+`/article/${id}`);
  }
  addComment(body:any){
    return this.http.post(this.baseURL+'/article/AddComment',body);
  }

  login(body:any){
    return this.http.post(this.baseURL+'/user/login',body);
  }

  addNewArticle(body:any){
    var userToken = new HttpHeaders({'Authorization':'Bearer ' + localStorage.getItem('token')});
    return this.http.post(this.baseURL+'/article',body,{headers: userToken});
  }

  removeArticle(id:number){
    var userToken = new HttpHeaders({'Authorization':'Bearer ' + localStorage.getItem('token')});
    return this.http.delete(this.baseURL+`/article/${id}`,{headers: userToken});
  }
  getCategoy(){
    return this.http.get(this.baseURL+'/category/Categories');
  }
}
