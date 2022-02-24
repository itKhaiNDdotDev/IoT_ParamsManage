import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { SettingComponent } from './setting/setting.component';
import { ProfileComponent } from './profile/profile.component';
import { CreateComponent } from './create/create.component';
import { DevicesComponent } from './devices/devices.component';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { AboutDvComponent } from './about-dv/about-dv.component';
import { AttributeComponent } from './attribute/attribute.component';
import { ApiInfoComponent } from './api-info/api-info.component';
import { RouterModule } from '@angular/router';



@NgModule({
  declarations: [
    SettingComponent,
    ProfileComponent,
    CreateComponent,
    DevicesComponent,
    AboutDvComponent,
    AttributeComponent,
    ApiInfoComponent,
  ],
  imports: [
    CommonModule,
    ReactiveFormsModule,
    FormsModule,
    RouterModule
  ]
})
export class PagesModule { }
