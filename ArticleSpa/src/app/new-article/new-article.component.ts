import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'Shared/article.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-new-article',
  templateUrl: './new-article.component.html',
  styleUrls: ['./new-article.component.css']
})
export class NewArticleComponent implements OnInit {
  category:any;
  content:string;
  selectedCategory:number;
  constructor(private articleService:ArticleService,private route:Router) { }

  ngOnInit() {
    this.articleService.getCategoy().subscribe(response=>{
        this.category = response;
    })
  }

  addArticle(){
    var body={
      content:this.content,
      categoryId:this.selectedCategory
    }
    this.articleService.addNewArticle(body).subscribe(response=>{
      this.route.navigateByUrl('/home');
    });
  }
}
