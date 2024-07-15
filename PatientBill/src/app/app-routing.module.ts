import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HospitalBillComponent } from './Component/hospital-bill/hospital-bill.component';

const routes: Routes = [
  {path:'',redirectTo:'/Home',pathMatch:'full'},
  {path:'Home',component:HospitalBillComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
  
})
export class AppRoutingModule { }
