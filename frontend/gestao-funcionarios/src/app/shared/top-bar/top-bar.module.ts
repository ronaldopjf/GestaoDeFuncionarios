import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { TopBarComponent } from './top-bar/top-bar.component';
import { DemoMaterialModule } from '../material-module/material-module';

@NgModule({
  declarations: [TopBarComponent],
  imports: [
    CommonModule,
    DemoMaterialModule
  ],
  exports: [TopBarComponent]
})
export class TopBarModule { }
