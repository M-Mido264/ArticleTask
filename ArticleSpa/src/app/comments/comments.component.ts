import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'Shared/article.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-comments',
  templateUrl: './comments.component.html',
  styleUrls: ['./comments.component.css']
})
export class CommentsComponent implements OnInit {

  comments:any;
  comment:string;
  constructor(private articleServic: ArticleService,
    private route: ActivatedRoute) { }

  ngOnInit() {
    this. getArticleComments();
  }

  getArticleComments(){
    this.articleServic.getComment(this.route.snapshot.params.id).subscribe(
      response=>{
        this.comments= response;
      }
    );
  }

  addComment(){
    var body = {
      commentContent: this.comment,
	    articleId: this.route.snapshot.params.id
    }
    this.articleServic.addComment(body).subscribe(response => {
      this.comment = null;
      this.getArticleComments();
    });
  }

}
