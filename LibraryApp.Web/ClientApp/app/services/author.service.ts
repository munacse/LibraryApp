import { Injectable, Inject } from '@angular/core';
import { IAuthor } from "../interfaces/author";
import { Author } from "../model/author.model";
import { Http } from '@angular/http';

@Injectable()
export class AuthorService {

    public authors: IAuthor[];
    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    getAuthors() {
        return this.http.get(this.baseUrl + 'api/Author/GetAllAuthor');
    }

    saveAuthor(author: Author) {
        return this.http.post(this.baseUrl + 'api/Author',author);
    }

}

