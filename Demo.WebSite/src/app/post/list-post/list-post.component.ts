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
    this.post = { id: 0, title: '', author: '' };
  }
  post: Post;
  posts: Post[];
  postId: number;

  constructor(private postService: IPostService) {
  }

  find(): void {
    if (Number(this.postId) > 0) {
      console.log('starting find postId:' + this.postId.toString());
      // this.postService.find(this.postId, this.post);
      this.postService.getAllPosts()
        .subscribe(
          (response) => {
            let result = response;
            console.log(result.length);
            if (result.length > 0)
              this.posts = result.filter(p => p.id == this.postId);
            else
              this.posts = result;
            this.post = result[this.postId - 1];
            // console.log(this.post.title);
          }
        );
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
