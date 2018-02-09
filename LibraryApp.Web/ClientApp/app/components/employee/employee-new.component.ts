import { Component, OnInit, OnDestroy, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Employee } from "../../model/employee.model";
import { EmployeeService } from "../../services/employee.service";

@Component({
    selector: 'employee-new',
    templateUrl: './employee-new.component.html'
})
export class EmployeeComponent implements OnInit, OnDestroy {

    public employeeFirstName: string = '';
    public employeeLastName: string = '';
    public employeeEmail: string = '';
    public employeeBirthDate: Date;
    @ViewChild('employeeForm') authorForm: NgForm;
    public employees: Employee[];

    constructor(private employeeService: EmployeeService) {

    }

    ngOnInit() {
        this.getEmployees();
    }

    ngOnDestroy() {
        //this.saveToDisk();
    }

    onSubmit() {

        let employee = new Employee();
        employee.firstName = this.employeeFirstName;
        employee.lastName = this.employeeLastName;
        employee.birthDate = this.employeeBirthDate;
        employee.email = this.employeeEmail;

        this.employeeService.saveEmployee(employee).subscribe(result => {
                //this.authors = result.json() as IAuthor[];
            },
            error => console.log(error));
        this.authorForm.reset();
    }

    getEmployees() {

        this.employeeService.getEmployees().subscribe(result => {
                this.employees = result.json() as Employee[];
            },
            error => console.log(error)
        );

    }

}