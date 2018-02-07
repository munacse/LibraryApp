import { Injectable, Inject } from '@angular/core';
import { IBookCategory } from "../interfaces/bookCategory";
import { Http } from '@angular/http';

@Injectable()
export class BookCategoryService {

    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getBookCategory() {
        return this.http.get(this.baseUrl + 'api/BookCategory/GetAllBookCategory');
    }

}