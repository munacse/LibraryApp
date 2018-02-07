import { Injectable, Inject } from '@angular/core';
import { IBook } from "../interfaces/book";
import { Http } from '@angular/http';

@Injectable()
export class BookService {

    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getBook() {
        return this.http.get(this.baseUrl + 'api/Book/GetAllBook');
    }

}