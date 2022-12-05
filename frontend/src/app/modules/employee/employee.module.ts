import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { EmployeeRoutingModule } from './employee-routing.module';
import { AddEmployeeModalComponent } from './components/add-employee-modal/add-employee-modal.component';
import { UpdateEmployeeModalComponent } from './components/update-employee-modal/update-employee-modal.component';
import { DeleteEmployeeModalComponent } from './components/delete-employee-modal/delete-employee-modal.component';
import { ListEmployeeComponent } from './pages/list-employee/list-employee.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { MaterialModule } from 'src/app/shared/material.module';


@NgModule({
  declarations: [
    AddEmployeeModalComponent,
    UpdateEmployeeModalComponent,
    DeleteEmployeeModalComponent,
    ListEmployeeComponent
  ],
  imports: [
    CommonModule,
    EmployeeRoutingModule,
    ReactiveFormsModule,
    FormsModule,
    MaterialModule
  ]
})
export class EmployeeModule { }
