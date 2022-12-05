import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeService } from 'src/app/core/services/employee.service';

@Component({
  selector: 'app-update-employee-modal',
  templateUrl: './update-employee-modal.component.html',
  styleUrls: ['./update-employee-modal.component.scss']
})
export class UpdateEmployeeModalComponent implements OnInit {

  form!: FormGroup;
  gender: string[] = ['male', 'female'];
  employeeId: any;

  constructor(
    private _employeeService: EmployeeService,
    private snackbar: MatSnackBar,
    private router: Router,
    private activatedRoute: ActivatedRoute
  ) { }

  ngOnInit(): void {
    this.activatedRoute.paramMap.subscribe(
      param => {
        if (!param.has('id')) {
          this.router.navigateByUrl('/employees');
          return;
        } else {
          this.employeeId = param.get('id') || 0;
        }
      }
    )
    this._employeeService.getSingleEmployee(this.employeeId).subscribe(
      {
        next: res => {
          this.form = new FormGroup({
            firstName: new FormControl(res.firstName, {
              validators: [Validators.required]
            }),
            lastName: new FormControl(res.lastName, {
              validators: [Validators.required]
            }),
            birthdate: new FormControl(res.birthdate, {
              validators: [Validators.required]
            }),
            salary: new FormControl(res.salary, {
              validators: [Validators.required]
            }),
            gender: new FormControl(res.gender, {
              validators: [Validators.required]
            }),
          })
        }
      }
    )

  }

  updateEmployee() {
    console.log('employee to add', this.form.value);
    // this.form.get('salary')
    this._employeeService.updateEmployee(this.employeeId, this.form.value).subscribe(
      {
        next: res => {
          this.snackbar.open('employee updated successfully', 'Ok', {
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
