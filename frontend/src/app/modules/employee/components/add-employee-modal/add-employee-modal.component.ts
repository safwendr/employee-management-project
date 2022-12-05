import { Component, OnInit } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { EmployeeService } from 'src/app/core/services/employee.service';

@Component({
  selector: 'app-add-employee-modal',
  templateUrl: './add-employee-modal.component.html',
  styleUrls: ['./add-employee-modal.component.scss']
})
export class AddEmployeeModalComponent implements OnInit {


  form!: FormGroup;
  gender: string[] = ['male', 'female'];


  constructor(
    private _employeeService: EmployeeService,
    private snackbar: MatSnackBar,
    private router: Router
  ) { }

  ngOnInit(): void {
    this.form = new FormGroup({
      firstName: new FormControl(null, {
        validators: [Validators.required]
      }),
      lastName: new FormControl(null, {
        validators: [Validators.required]
      }),
      birthdate: new FormControl(null, {
        validators: [Validators.required]
      }),
      salary: new FormControl(null, {
        validators: [Validators.required]
      }),
      gender: new FormControl(null, {
        validators: [Validators.required]
      }),
    })
  }

  addEmployee() {
    console.log('employee to add', this.form.value);
    // this.form.get('salary')
    this._employeeService.createEmployee(this.form.value).subscribe(
      {
        next: res => {
          this.snackbar.open('employee added successfully', 'Ok', {
            duration: 5000
          });
          this.router.navigateByUrl('/employees');
        }, error: err => {
          console.log('error occured', err);
        }
      }
    )
  }

}
