import { Category } from "./Category";
import { User } from "./User";

export class Article{

    articleId!:Number;
    articleTitle!:string;
    articleBody!:string;
    Author!:User;
    categoryId!:Number;
 
}