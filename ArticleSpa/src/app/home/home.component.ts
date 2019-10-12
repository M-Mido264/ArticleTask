import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'Shared/article.service';
import { Router } from '@angular/router';
import { Variable } from '@angular/compiler/src/render3/r3_ast';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  article: any;
  categories: any;
  news: any = {};
  loginStatus: boolean = false;
  selectedCategory:Variable;
  constructor(private articleService: ArticleService, private route: Router) { }

  ngOnInit() {
    this.loginStatus = localStorage.getItem('token') ? true : false;
    this.articleService.getArticleCategory().subscribe(
      (category) => {
        this.categories = category;
      }
    );
    this.loadAllArticles();
  }

  onCategoryChange() {
    if (this.news.category === 'All') {
      this.loadAllArticles();
    }
    var selectedCategory = this.categories.find(c => c.id == this.news.category);
    this.article = selectedCategory ? selectedCategory.articles : [];
  }

  loadAllArticles() {
    this.articleService.getArticles().subscribe(
      (article) => {
        this.article = article
      }
    );
  }

  LoginButton() {
    this.route.navigateByUrl('/login');
  }

  onLogout() {
    localStorage.removeItem('token');
    this.loginStatus = false;
  }

  removeArticle(id: number) {
    this.articleService.removeArticle(id).subscribe(response => {
      this.loadAllArticles();
    })
  }
}
