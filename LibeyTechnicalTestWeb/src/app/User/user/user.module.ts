import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { UsercardsComponent } from './usercards/usercards.component';
import { UsermaintenanceComponent } from './usermaintenance/usermaintenance.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { NgSelectModule } from "@ng-select/ng-select";
import { ErrorMessageComponent } from './reusable/error-message.component';
import { UsertableComponent } from './usertable/usertable.component';
import { FullNamePipe } from '../pipes/full-name.pipe';
@NgModule({
  declarations: [   
    FullNamePipe,
    ErrorMessageComponent,
    UsercardsComponent,
    UsertableComponent,
    UsermaintenanceComponent
  ],
  imports: [
    CommonModule,
    FormsModule,
    ReactiveFormsModule,
    NgSelectModule 
  ]
})
export class UserModule { }