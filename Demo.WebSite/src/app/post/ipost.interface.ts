import { Observable } from "rxjs";
import { Post } from "../model/post.model";

export abstract class IPostService {
    abstract getAllPosts(): Observable<Post[]>;
}
