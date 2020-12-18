import { Component, OnInit, Inject } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';

import { Department } from '../../../models/department/department';
import { DepartmentService } from '../../../services/department.service';

@Component({
  selector: 'app-department-create-update',
  templateUrl: './employee-create-update.component.html',
  styleUrls: ['./employee-create-update.component.scss']
})
export class EmployeeCreateUpdateComponent implements OnInit {
  public departments: Department[] = [];

  public constructor(
    private dialogRef: MatDialogRef<EmployeeCreateUpdateComponent>,
    @Inject(MAT_DIALOG_DATA) public data,
    private departmentService: DepartmentService,
    private snackBar: MatSnackBar
  ) { }

  public ngOnInit(): void {
    this.getDepartments();
  }

  private getDepartments(): void {
    this.departmentService.getDepartments().subscribe(result => {
      this.departments = result;
    }, () => {
      this.openSnackBar('A ação falhou', 'Ler Departamentos');
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
}