import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeService } from 'src/app/core/services/employee.service';

@Component({
  selector: 'app-delete-employee-modal',
  templateUrl: './delete-employee-modal.component.html',
  styleUrls: ['./delete-employee-modal.component.scss']
})
export class DeleteEmployeeModalComponent implements OnInit {

  employeeId!: number;

  constructor(
    public dialogRef: MatDialogRef<DeleteEmployeeModalComponent>,
    @Inject(MAT_DIALOG_DATA) public data: any,
    private _employeeService: EmployeeService,
    private snackbar: MatSnackBar

  ) {
    this.employeeId = data.id;

  }

  ngOnInit(): void {
    console.log('employee to delete', this.employeeId);

  }

  delete() {
    this._employeeService.deleteEmployee(this.employeeId).subscribe(
      {
        next: res => {
          this.snackbar.open('employee added successfully', 'Ok', {
            duration: 5000
          });
          this.dialogRef.close();
        }, error: err => {
          console.log('error occured', err);
        }
      }
    )
  }

}
