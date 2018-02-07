import { Component, Inject, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';
import { IBook } from "../../interfaces/book";
import { IAuthor } from "../../interfaces/author";
import { IBookCategory } from "../../interfaces/bookCategory";
import { AuthorService } from "../../services/author.service";
import { BookCategoryService } from "../../services/bookcategory.service";
import { BookService } from "../../services/book.service";

@Component({
    selector: 'book',
    templateUrl: './book.component.html'
})

export class BookComponent implements OnInit, OnDestroy {

    public baseUrl: string;
    public books: IBook[];
    public authors: IAuthor[];
    public bookCategorys: IBookCategory[];
    @ViewChild('bookForm') bookForm: NgForm;

    public bookName: string = '';
    public bookPrize: string = '';
    public bookPage: string = '';
    public authorId: string = '';
    public bookCategoryId: string = '';

    constructor(
        private http: Http,
        @Inject('BASE_URL') baseUrl: string,
        private authorService: AuthorService,
        private bookCategoryService: BookCategoryService,
        private bookService: BookService)
    {

        this.baseUrl = baseUrl;

    }

    ngOnInit() {

        this.getAuthors();
        this.getBookCategory();
        this.getBooks();

    }

    getBooks() {

        this.bookService.getBook().subscribe(result => {
                this.books = result.json() as IBook[];
            },
            error => console.log(error));

    }

    getAuthors() {

        this.authorService.getAuthors().subscribe(result => {
                this.authors = result.json() as IAuthor[];
            },
            error => console.log(error)
        );

    }

    getBookCategory() {

        this.bookCategoryService.getBookCategory().subscribe(result => {
                this.bookCategorys = result.json() as IBookCategory[];
            },
            error => console.log(error));
    }

    ngOnDestroy() {
        //this.saveToDisk();
    }

    onSubmit() {

        this.http.post(this.baseUrl + 'api/Book',
            {
                name: this.bookName,
                price: this.bookPrize,
                page: this.bookPage,
                authorId: this.authorId,
                BookCategoryId: this.bookCategoryId
            }).subscribe(result => {
                this.books = result.json() as IBook[];
            },
            error => console.log(error));
        this.bookForm.reset();

    }

}

//interface IBook {
//    id: string,
//    name: string,
//    price: string,
//    page: string,
//    author: IAuthor,
//    bookCategory: IBookCategory,
//}

//interface IAuthor {
//    id: string,
//    name: string,
//    email: string,
//    address: string,
//    phone: string,
//}

//interface IBookCategory {
//    id: string,
//    name: string,
//}