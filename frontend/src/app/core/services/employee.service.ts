import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Employee } from '../models/employee.model';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {

  private listEmployee = new BehaviorSubject<Employee[]>([]);
  public listEmployee$ = this.listEmployee.asObservable();

  private url = `${environment.baseUrl}/employee`;

  constructor(
    private http: HttpClient
  ) { }

  getListEmployee() {
    return this.http.get<Employee[]>(this.url).pipe(
      tap(
        {
          next: res => {
            console.log('list employee', res);
            this.listEmployee.next(res);
          },
          error: err => {
            console.log('error occured', err);
          }
        }
      )
    )
  }


  deleteEmployee(employeeId: number) {
    return this.http.delete(`${this.url}/${employeeId}`).pipe(
      tap({
        next: res => {
          this.getListEmployee();
        },
        error: err => {
          console.log('error occured', err);
        }
      })
    );
  }

  updateEmployee(employeeId: number, employee: Employee) {
    return this.http.put(`${this.url}/${employeeId}`, employee).pipe(
      tap({
        next: res => {
          this.getListEmployee();
        },
        error: err => {
          console.log('error occured', err);
        }
      })
    );
  }

  getSingleEmployee(employeeId: number) {
    return this.http.get<Employee>(`${this.url}/${employeeId}`).pipe(
      tap({
        next: res => {
          console.log('single employee', res);
        },
        error: err => {
          console.log('error occured', err);
        }
      })
    );
  }

  createEmployee(employee: Employee) {
    return this.http.post(`${this.url}`, employee).pipe(
      tap({
        next: res => {
          console.log('single employee', res);
        },
        error: err => {
          console.log('error occured', err);
        }
      })
    );
  }
}
