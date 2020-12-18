import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { DemoMaterialModule } from '../material-module/material-module';
import { RouterModule } from '@angular/router';
import { FormsModule } from '@angular/forms';

import { SideNavComponent } from './side-nav/side-nav.component';

@NgModule({
  declarations: [SideNavComponent],
  imports: [
    CommonModule,
    FormsModule,
    DemoMaterialModule,
    RouterModule
  ],
  exports: [SideNavComponent]
})
export class SideNavModule { }
