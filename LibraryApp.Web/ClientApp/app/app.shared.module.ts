import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './components/app/app.component';
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { CounterComponent } from './components/counter/counter.component';
import { BookCategoryComponent } from './components/bookcategory/bookcategory.component';
import { AuthorComponent } from './components/author/author.component';
import { EmployeeComponent } from './components/employee/employee-new.component';
import { BookComponent } from './components/book/book.component';
import { AuthorService } from './services/author.service';
import { BookCategoryService } from './services/bookcategory.service';
import { BookService } from './services/book.service';
import { EmployeeService } from './services/employee.service';

@NgModule({
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        BookCategoryComponent,
        AuthorComponent,
        BookComponent,
        EmployeeComponent
    ],
    imports: [
        CommonModule,
        HttpModule,
        FormsModule,
        RouterModule.forRoot([
            { path: '', redirectTo: 'home', pathMatch: 'full' },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: 'book-category', component: BookCategoryComponent },
            { path: 'author', component: AuthorComponent },
            { path: 'book', component: BookComponent },
            { path: 'employee-new', component: EmployeeComponent },
            { path: '**', redirectTo: 'home' }
        ])
    ],
    providers: [
        AuthorService,
        BookCategoryService,
        BookService,
        EmployeeService
    ]
})
export class AppModuleShared {
}
