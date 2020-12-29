import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { EmployeeForCreateUpdate } from 'src/app/models/employee/employeeForCreateUpdate';
import { EmployeeService } from 'src/app/services/employee.service';

import { Department } from '../../../models/department/department';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-department-create-update',
  templateUrl: './employee-create-update.component.html',
  styleUrls: ['./employee-create-update.component.scss']
})
export class EmployeeCreateUpdateComponent implements OnInit {
  private canAccess: boolean;
  public departments: Department[] = [];

  public constructor(
    private dialogRef: MatDialogRef<EmployeeCreateUpdateComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private employeeService: EmployeeService,
    private departmentService: DepartmentService,
    private snackBar: MatSnackBar
  ) { }

  public ngOnInit(): void {
    this.getDepartments();
    this.dialogRef.disableClose = true;
  }

  private getDepartments(): void {
    this.departmentService.getDepartments().subscribe(result => {
      this.departments = result;
    }, (error) => {
      this.openSnackBar(error.error.error, 'Ler Departamentos');
    });
  }

  public openSnackBar(message: string, action: string): void {
    this.snackBar.open(message, action, {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top'
    });
  }

  public onNoClick(): void {
    this.dialogRef.close();
  }

  public async save(): Promise<void> {
    this.canAccess = true;

    if (this.data.employeeForCreateUpdate.access) {
      this.canAccess = await new Promise<boolean>(resolve => {
        this.employeeService.canAccess().subscribe(result => {
          resolve(result.object);
          this.openSnackBar(result.message, 'Cadastrar Funcionário');
        });
      });
    }

    if (this.canAccess) {
      this.dialogRef.close(this.data.employeeForCreateUpdate);
    }

    return;
  }
}