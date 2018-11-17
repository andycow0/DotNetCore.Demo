import { Observable } from "rxjs";
import { Post } from "../model/post.model";

export abstract class IPostService {
    // abstract post: Post;
    abstract getAllPosts(): Observable<Post[]>;
    abstract find(postId: number, post: Post): void;
}
