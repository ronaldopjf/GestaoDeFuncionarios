import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { NgxMaskModule } from 'ngx-mask';
import { MAT_DATE_LOCALE } from '@angular/material/core';

import { DemoMaterialModule } from '../../shared/material-module/material-module';
import { EmployeeRoutingModule } from './employee.routing';
import { EmployeeListComponent } from './employee-list/employee-list.component';
import { EmployeeCreateUpdateComponent } from './employee-create-update/employee-create-update.component';
import { EmployeeService } from 'src/app/services/employee.service';
import { ConfirmDialogModule } from 'src/app/shared/confirm/confirm-dialog.module';
import { DepartmentService } from 'src/app/services/department.service';

@NgModule({
  declarations: [
    EmployeeListComponent,
    EmployeeCreateUpdateComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    DemoMaterialModule,
    ConfirmDialogModule,
    EmployeeRoutingModule,
    NgxMaskModule.forRoot()
  ],
  providers: [
    EmployeeService,
    DepartmentService,
    { provide: MAT_DATE_LOCALE, useValue: 'pt-BR' }
  ]
})
export class EmployeeModule { }
