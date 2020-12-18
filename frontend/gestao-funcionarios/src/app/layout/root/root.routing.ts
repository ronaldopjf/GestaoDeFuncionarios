import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';

import { RootComponent } from './root/root.component';

const employeeModule = () => import('../../pages/employee/employee.module').then(x => x.EmployeeModule);

const routes: Routes = [
  {
    path: '', component: RootComponent, children:
      [
        { path: '', loadChildren: employeeModule },
        { path: 'employee', loadChildren: employeeModule }
      ]
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RootRoutingModule { }
