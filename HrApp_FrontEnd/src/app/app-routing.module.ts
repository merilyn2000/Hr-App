import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { CompanyEditComponent } from './companies/company-edit/company-edit.component';
import { CompanyListComponent } from './companies/company-list/company-list.component';
import { EmployeeEditComponent } from './companies/employees/employee-edit/employee-edit.component';
import { EmployeeListComponent } from './companies/employees/employee-list/employee-list.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { TestErrorsComponent } from './test-errors/test-errors.component';

const routes: Routes = [
  { path:'company-list', component:CompanyListComponent},
  { path:'company-edit/:companyId', component:CompanyEditComponent},
  { path:'employee-list/:companyId', component:EmployeeListComponent},
  { path:'employee-edit/:id', component:EmployeeEditComponent},
  { path:'register', component:RegisterComponent},
  { path:'login', component:LoginComponent},
  { path:'server-error', component:ServerErrorComponent},
  { path:'test-errors', component:TestErrorsComponent},
  { path:'not-found', component:NotFoundComponent},

  { path: '', redirectTo: '/company-list', pathMatch: 'full' },
  //always the last
  // { path:'**', component:NotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
