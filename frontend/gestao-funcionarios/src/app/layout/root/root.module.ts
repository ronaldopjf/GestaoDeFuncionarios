import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { RootComponent } from './root/root.component';
import { RootRoutingModule } from './root.routing';
import { EmployeeModule } from 'src/app/pages/employee/employee.module';
import { TopBarModule } from 'src/app/shared/top-bar/top-bar.module';
import { SideNavModule } from 'src/app/shared/side-nav/side-nav.module';
import { HeaderService } from 'src/app/services/header.service';

@NgModule({
  declarations: [RootComponent],
  imports: [
    CommonModule,
    RootRoutingModule,
    EmployeeModule,
    TopBarModule,
    SideNavModule
  ],
  providers: [
    HeaderService
  ]
})
export class RootModule { }
