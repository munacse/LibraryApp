import { Component, Inject, OnInit, OnDestroy } from '@angular/core';
import { Http } from '@angular/http';

@Component({
    selector: 'bookcategory',
    templateUrl: './bookcategory.component.html'
})

export class BookCategoryComponent implements OnInit, OnDestroy {

    public bookCategory: BookCategory[];
    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {

        this.baseUrl = baseUrl;

    }

    ngOnInit() {
        this.getBookCategory();
    }

    getBookCategory() {

        this.http.get(this.baseUrl + 'api/BookCategory/GetAllBookCategory').subscribe(result => {
            this.bookCategory = result.json() as BookCategory[];
        }, error => console.log(error))
    }

    ngOnDestroy() {
        //this.saveToDisk();
    }

}

interface BookCategory {
    id: string,
    name: string
}