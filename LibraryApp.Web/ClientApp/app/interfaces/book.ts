import { IAuthor } from "./author";
import { IBookCategory } from "./bookCategory";

export interface IBook {
    id: string,
    name: string,
    price: string,
    page: string,
    author: IAuthor,
    bookCategory: IBookCategory,
}