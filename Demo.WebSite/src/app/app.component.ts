import { Component, OnInit } from '@angular/core';
import { Post } from './model/post.model';
import { IPostService } from './post/ipost.interface';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})

export class AppComponent implements OnInit {
  ngOnInit(): void {
    this.getAllPosts();
  }
  posts: Post[];
  title = 'My First test Angular';
  constructor(private postService: IPostService) {
  }
  private getAllPosts() {
    console.log("post service !");
    this.postService.getAllPosts()
      .subscribe(
        value => this.posts = value, 
        error => console.log(error),
        () => console.log('GET completed')
      );
  }
}
