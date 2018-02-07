import { Component, Inject, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';
import { IAuthor } from "../../interfaces/author";
import { AuthorService } from "../../services/author.service";
import { Author } from "../../model/author.model";
import { Observable } from 'rxjs/Observable';

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

    constructor(
        private http: Http,
        @Inject('BASE_URL') baseUrl: string,
        private authorService: AuthorService
    ) {

        this.baseUrl = baseUrl;

    }

    ngOnInit() {

        this.getAuthors();

    }

    ngOnDestroy() {
        //this.saveToDisk();
    }

    getAuthors() {

        this.authorService.getAuthors().subscribe(result => {
            this.authors = result.json() as IAuthor[];
            },
            error => console.log(error)
        );

    }

    onSubmit() {
        
        let author = {
            name: this.authorName,
            email: this.authorEmail,
            phone: this.authorPhone,
            address: this.authorAddress
        };

        this.authorService.saveAuthor(author).subscribe(result => {
                this.authors = result.json() as IAuthor[];
            },
            error => console.log(error));
        this.authorForm.reset();

    }

}
