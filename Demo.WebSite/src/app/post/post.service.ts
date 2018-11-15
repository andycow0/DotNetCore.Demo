import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { IPostService } from './ipost.interface';
import { Post } from '../model/post.model';

@Injectable({
  providedIn: 'root'
})

export class PostService implements IPostService {
  constructor(private httpClient: HttpClient) { }

  getAllPosts(): Observable<Post[]> {
    console.log("getAllPosts!");
    return this.httpClient.get<Post[]>('api/posts');
  }
}
