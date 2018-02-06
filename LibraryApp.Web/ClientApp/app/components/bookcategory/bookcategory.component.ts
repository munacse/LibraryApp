import { Component, Inject, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { Http } from '@angular/http';
import { NgForm } from '@angular/forms';

@Component({
    selector: 'bookcategory',
    templateUrl: './bookcategory.component.html'
})

export class BookCategoryComponent implements OnInit, OnDestroy {

    public bookCategorys: IBookCategory[];
    public bookCategoryModel: IBookCategory;
    public baseUrl: string;
    public bookCategoryName: string = '';
    @ViewChild('bookCategoryForm') bookCategoryForm: NgForm;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {

        this.baseUrl = baseUrl;

    }

    ngOnInit() {

        this.getBookCategory();

    }

    getBookCategory() {

        this.http.get(this.baseUrl + 'api/BookCategory/GetAllBookCategory').subscribe(result => {
                this.bookCategorys = result.json() as IBookCategory[];
            },
            error => console.log(error));
    }

    ngOnDestroy() {
        //this.saveToDisk();
    }

    onSubmit() {
        
        this.http.post(this.baseUrl + 'api/BookCategory', { name: this.bookCategoryName }).subscribe(result => {
                this.bookCategorys = result.json() as IBookCategory[];
            },
            error => console.log(error));
        this.bookCategoryForm.reset();
    }

}

interface IBookCategory {
    id: string,
    name: string,
}