import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MainComponent } from './layout/main/main.component';
import { LoginComponent } from './login/login.component';
import { AboutDvComponent } from './pages/about-dv/about-dv.component';
import { ApiInfoComponent } from './pages/api-info/api-info.component';
import { AttributeComponent } from './pages/attribute/attribute.component';
import { CreateComponent } from './pages/create/create.component';
import { DevicesComponent } from './pages/devices/devices.component';
import { ProfileComponent } from './pages/profile/profile.component';
import { SettingComponent } from './pages/setting/setting.component';
import { SignupComponent } from './signup/signup.component';

const routes: Routes = [
  {path: '', redirectTo:'login', pathMatch:'full'},
  {path: 'login', component: LoginComponent},
  {path: 'register', component: SignupComponent},
  {path: 'home', component: DevicesComponent},
  {path: '', component: DevicesComponent},
  {path: 'device',
    children: [
      {path: '', component: DevicesComponent},
      {path: 'device', component: DevicesComponent},
      {path: 'about-dv', component: AboutDvComponent},
      {path: 'attributes', component: AttributeComponent},
      {path: 'api-info', component: ApiInfoComponent},
    ]
  },
  {path: 'create', component: CreateComponent},
  {path: 'profile', component: ProfileComponent},
  {path: 'setting', component: SettingComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
