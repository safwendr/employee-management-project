import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AddEmployeeModalComponent } from './components/add-employee-modal/add-employee-modal.component';
import { UpdateEmployeeModalComponent } from './components/update-employee-modal/update-employee-modal.component';
import { ListEmployeeComponent } from './pages/list-employee/list-employee.component';

const routes: Routes = [
  { path: '', component: ListEmployeeComponent },
  { path: 'create', component: AddEmployeeModalComponent },
  { path: 'update/:id', component: UpdateEmployeeModalComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class EmployeeRoutingModule { }
