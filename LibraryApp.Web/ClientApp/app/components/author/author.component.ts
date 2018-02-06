import { Component, Inject, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'author',
    templateUrl: './author.component.html'
})
export class AuthorComponent implements OnInit, OnDestroy {

    public baseUrl: string;
    public authors: IAuthor[];
    @ViewChild('authorForm') authorForm: NgForm;

    public authorName: string = '';
    public authorPhone: string = '';
    public authorEmail: string = '';
    public authorAddress: string = '';

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {

        this.baseUrl = baseUrl;

    }

    ngOnInit() {

        this.getAuthors();

    }

    ngOnDestroy() {
        //this.saveToDisk();
    }

    getAuthors() {

        this.http.get(this.baseUrl + 'api/Author/GetAllAuthor').subscribe(result => {
            this.authors = result.json() as IAuthor[];
            },
            error => console.log(error));

    }

    onSubmit() {

        this.http.post(this.baseUrl + 'api/Author',
            {
                name: this.authorName,
                email: this.authorEmail,
                phone: this.authorPhone,
                address: this.authorAddress
            }).subscribe(result => {
                this.authors = result.json() as IAuthor[];
            },
            error => console.log(error));
        this.authorForm.reset();

    }

}

interface IAuthor {
    id: string,
    name: string,
    email: string,
    address: string,
    phone: string,
}