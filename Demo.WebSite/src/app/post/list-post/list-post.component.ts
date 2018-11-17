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
  post: Post;
  posts: Post[];
  postId: number;
  constructor(private postService: IPostService) {
  }

  find(): void {
    if (Number(this.postId) > 0) {
      console.log('starting find postId:' + this.postId.toString());
      this.postService.find(this.postId, this.post);
      // console.log(this.postService.post.title);
    }
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
