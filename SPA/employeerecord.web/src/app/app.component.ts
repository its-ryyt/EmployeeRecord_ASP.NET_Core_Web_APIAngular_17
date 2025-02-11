import { HttpClient, HttpClientModule } from '@angular/common/http';
import { Component, inject } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { map, Observable } from 'rxjs';
import { Employee } from '../models/employee.model';
import { AsyncPipe } from '@angular/common';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule } from '@angular/forms';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, HttpClientModule, AsyncPipe, FormsModule, ReactiveFormsModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  http = inject(HttpClient);
  public employeeList: Array<any> = [];

  employeesForm = new FormGroup({
    firstname: new FormControl<string>(''),
    lastname: new FormControl<string>(''),
    middlename: new FormControl<string>(''),
    gender: new FormControl<string>(''),
    dateofBirth: new FormControl<Date>(new Date('01/01/1990')),
    email: new FormControl<string | null>(null),
    phoneNumber: new FormControl<string | null>(null),
    homeAddress: new FormControl<string | null>(null),
    isActive: new FormControl<boolean>(false)
  })

  onFormSubmit() {
    const addEmployeeRequest = {
      firstname: this.employeesForm.value.firstname,
      middlename: this.employeesForm.value.middlename,
      lastname: this.employeesForm.value.lastname,
      gender: this.employeesForm.value.gender,
      dateofBirth: this.employeesForm.value.dateofBirth,
      email: this.employeesForm.value.email,
      phoneNumber: this.employeesForm.value.phoneNumber,
      homeAddress: this.employeesForm.value.homeAddress,
      isActive: this.employeesForm.value.isActive
    }

    this.http.post('https://localhost:7157/api/Employees', addEmployeeRequest)
    .subscribe({
      next: (data) => {
        console.log(data);
        this.ngOnInit();
        this.employeesForm.reset();
      }
    });
  }

  onDelete(id: string){
    this.http.delete(`https://localhost:7157/api/Employees/${id}`)
    .subscribe({
      next: (value) => {
        alert('Item Deleted.');
        this.ngOnInit();
      }
    });
  }

  ngOnInit() {
    this.http.get('https://localhost:7157/api/Employees')
      .subscribe({
        next: (data: any) => {
          console.log(data);
          this.employeeList = data;
        }, error: (err) => console.log(err)
      });
  }
}
