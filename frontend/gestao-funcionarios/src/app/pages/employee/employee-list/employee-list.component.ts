import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import { isNullOrUndefined } from 'util';

import { EmployeeForRead } from 'src/app/models/employee/employeeForRead';
import { EmployeeService } from 'src/app/services/employee.service';
import { EmployeeCreateUpdateComponent } from '../employee-create-update/employee-create-update.component';
import { EmployeeForCreateUpdate } from 'src/app/models/employee/employeeForCreateUpdate';
import { ConfirmDialogComponent } from 'src/app/shared/confirm/confirm-dialog/confirm-dialog.component';
import { HeaderService } from 'src/app/services/header.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.scss']
})
export class EmployeeListComponent implements OnInit {
  public employees: EmployeeForRead[] = [];
  public displayedColumns: string[] = ['name', 'email', 'department', 'primaryPhone', 'access', 'Actions'];
  public dataSource: MatTableDataSource<EmployeeForRead>;
  @ViewChild(MatPaginator, { static: true }) paginator: MatPaginator;
  @ViewChild(MatSort, { static: true }) sort: MatSort;
  private isDisplayed;

  public constructor(
    private dialog: MatDialog,
    private snackBar: MatSnackBar,
    private headerService: HeaderService,
    private employeeService: EmployeeService
  ) { }

  public ngOnInit(): void {
    this.headerService.get().subscribe(result => this.isDisplayed = result);
    this.dataSource = new MatTableDataSource(this.employees);
    this.dataSource.paginator = this.paginator;
    this.dataSource.sort = this.sort;
    this.getEmployees();
  }

  private getEmployees(): void {
    this.employeeService.getEmployees().subscribe(result => {
      this.dataSource.data = result;
    }, () => {
      this.openSnackBar('A ação falhou', 'Ler Funcionários');
    });
  }

  public newEmployee(): void {
    this.openModalForCreateUpdate('Novo Funcionário', new EmployeeForCreateUpdate());
  }

  private createEmployee(employeeForCreate: EmployeeForCreateUpdate): void {
    this.employeeService.createEmployee(employeeForCreate).subscribe(result => {
      this.openSnackBar('Ação realizada com sucesso', 'Cadastrar Funcionário');
      this.getEmployees();
    }, (error) => {
      this.openSnackBar(error.error.error, 'Cadastrar Funcionário');
    });
  }

  public editEmployee(id: number): void {
    this.employeeService.getEmployee(id).subscribe(result => {
      this.openModalForCreateUpdate('Editar Funcionário', result);
      this.openSnackBar('Ação realizada com sucesso', 'Ler Funcionário');
    }, (error) => {
      this.openSnackBar(error.error.error, 'Ler Funcionário');
    });
  }

  private updateEmployee(employeeForUpdate: EmployeeForCreateUpdate): void {
    this.employeeService.updateEmployee(employeeForUpdate).subscribe(result => {
      this.getEmployees();
      this.openSnackBar('Ação realizada com sucesso', 'Atualizar Funcionário');
    }, (error) => {
      this.openSnackBar(error.error.error, 'Atualizar Funcionário');
    });
  }

  public confirmDeletion(employeeForDelete: EmployeeForRead): void {
    const dialogRef = this.dialog.open(ConfirmDialogComponent, {
      data: { title: 'Excluir Funcionário', message: `Confirma a exclusão de ${employeeForDelete.name}?` }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!isNullOrUndefined(result)) {
        this.deleteEmployee(employeeForDelete.id)
      }
    });
  }

  private deleteEmployee(id: number): void {
    this.employeeService.deleteEmployee(id).subscribe(result => {
      this.openSnackBar('Ação realizada com sucesso', 'Excluir Funcionário');
      this.getEmployees();
    }, () => {
      this.openSnackBar('A ação falhou', 'Excluir Funcionário');
    });
  }

  public showEmployee(employeeForDetails: EmployeeForRead): void {
    this.headerService.setEmployeeForRead(employeeForDetails);
    if (!this.isDisplayed) {
      this.headerService.toggle();
    }
  }

  private openModalForCreateUpdate(modalTitle, employeeForCreateUpdate): void {
    const dialogRef = this.dialog.open(EmployeeCreateUpdateComponent, {
      width: '60%',
      data: {
        description: modalTitle,
        employeeForCreateUpdate: employeeForCreateUpdate
      }
    });

    dialogRef.afterClosed().subscribe(result => {
      if (!isNullOrUndefined(result)) {
        if (!result.id) {
          this.createEmployee(result);
        } else {
          this.updateEmployee(result);
        }
      }
    });
  }

  public applyFilter(event: Event): any {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public mouseOverRow(index: number): any {
    document.getElementById('btnDetails' + index).hidden = false;
    document.getElementById('btnEdit' + index).hidden = false;
    document.getElementById('btnDelete' + index).hidden = false;
  }

  public mouseLeaveRow(index: number): any {
    document.getElementById('btnDetails' + index).hidden = true;
    document.getElementById('btnEdit' + index).hidden = true;
    document.getElementById('btnDelete' + index).hidden = true;
  }

  private openSnackBar(message: string, action: string): void {
    this.snackBar.open(message, action, {
      duration: 3000,
      horizontalPosition: 'right',
      verticalPosition: 'top'
    });
  }
}
