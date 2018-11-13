import { Component, OnInit } from '@angular/core';
import { Post } from '../../model/post.model';
import { IPostService } from '../ipost.interface';

@Component({
  selector: 'app-list-post',
  templateUrl: './list-post.component.html',
  styleUrls: ['./list-post.component.css']
})
export class ListPostComponent implements OnInit {
  ngOnInit(): void {
    this.getAllPosts();
  }
  posts: Post[];
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
