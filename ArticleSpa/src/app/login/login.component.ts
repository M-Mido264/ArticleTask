import { Component, OnInit } from '@angular/core';
import { ArticleService } from 'Shared/article.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
userName:string;
password:string;
  constructor(private articleService: ArticleService,private route:Router,private toastr: ToastrService) { }

  ngOnInit() {
  }

  onSubmit() {
    var userData={
      username: this.userName,
      password: this.password
    };
    this.articleService.login(userData).subscribe(
      (res: any) => {
        localStorage.setItem('token', res.token);
        this.route.navigateByUrl('/home');
      },
      err=>{
        if (err.status == 400) {
          this.toastr.error('Incorrect username or password');
        }
      }
    );
  }
}
