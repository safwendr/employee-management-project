import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { Router } from '@angular/router';
import { Employee } from 'src/app/core/models/employee.model';
import { EmployeeService } from 'src/app/core/services/employee.service';
import { DeleteEmployeeModalComponent } from '../../components/delete-employee-modal/delete-employee-modal.component';


@Component({
  selector: 'app-list-employee',
  templateUrl: './list-employee.component.html',
  styleUrls: ['./list-employee.component.scss']
})
export class ListEmployeeComponent implements OnInit {

  listEmployee!: Employee[];
  displayedColumns: string[] = ['firstName', 'lastName', 'birthdate', 'salary', 'gender', 'operations'];
  dataSource: MatTableDataSource<Employee>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(
    private _employeeService: EmployeeService,
    private router: Router,
    private dialog: MatDialog
  ) {
    this.dataSource = new MatTableDataSource(this.listEmployee);

  }

  ngOnInit(): void {
    this._employeeService.listEmployee$.subscribe({
      next: res => {
        this.listEmployee = res;
        this.dataSource = new MatTableDataSource(this.listEmployee);
        this.setPaginationAndSort();
      }
    })
    this.getListEmployee();
  }

  getListEmployee() {
    this._employeeService.getListEmployee().subscribe(
      {
        next: res => {
          console.log('liste employee fetched', res);
        }
      }
    )
  }

  ngAfterViewInit() {
    this.setPaginationAndSort();
  }


  setPaginationAndSort() {
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  addEmployee() {
    this.router.navigateByUrl('/employees/create')
  }

  updateEmployee(id: number) {
    this.router.navigateByUrl(`/employees/update/${id}`)
  }

  deleteEmployee(_id: number) {
    this.dialog.open(DeleteEmployeeModalComponent, {
      data: {
        id: _id
      }
    })
  }
}


