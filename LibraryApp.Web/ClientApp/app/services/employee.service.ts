import { Injectable, Inject } from '@angular/core';
import { Employee } from "../model/employee.model";
import { Http } from '@angular/http';

@Injectable()
export class EmployeeService {

    public baseUrl: string;

    constructor(private http: Http, @Inject('BASE_URL') baseUrl: string) {
        this.baseUrl = baseUrl;
    }

    saveEmployee(employee: Employee) {
        return this.http.post(this.baseUrl + 'api/Employee', employee);
    }

    getEmployees() {
        return this.http.get(this.baseUrl + 'api/Employee');
    }

}