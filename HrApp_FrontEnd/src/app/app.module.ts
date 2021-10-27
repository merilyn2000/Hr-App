import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppComponent } from './app.component';
import { CompanyCardComponent } from './companies/company-card/company-card.component';
import { CompanyListComponent } from './companies/company-list/company-list.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MaterialModule } from './shared/material.module';
import { AppRoutingModule } from './app-routing.module';
import { EmployeeListComponent } from './companies/employees/employee-list/employee-list.component';
import { EmployeeCardComponent } from './companies/employees/employee-card/employee-card.component';
import { CompanyEditComponent } from './companies/company-edit/company-edit.component';
import { EmployeeEditComponent } from './companies/employees/employee-edit/employee-edit.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import {NgbPaginationModule, NgbAlertModule} from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { CompanyService } from './services/company.service';
import { AccountService } from './services/account.service';
import { RegisterComponent } from './account/register/register.component';
import { LoginComponent } from './account/login/login.component';
import { ToolbarComponent } from './toolbar/toolbar.component';
import { NotFoundComponent } from './not-found/not-found.component';
import { ServerErrorComponent } from './server-error/server-error.component';
import { TestErrorsComponent } from './test-errors/test-errors.component';
import { JwtInterceptor } from './interceptors/jwt.interceptor';

@NgModule({
  declarations: [
    AppComponent,
    CompanyCardComponent,
    CompanyListComponent,
    CompanyEditComponent,
    EmployeeListComponent,
    EmployeeCardComponent,
    EmployeeEditComponent,
    ToolbarComponent,
    RegisterComponent,
    LoginComponent,
    ToolbarComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorsComponent
   ],
  imports: [
    BrowserModule,
    HttpClientModule,
    BrowserAnimationsModule,
    MaterialModule,
    AppRoutingModule,
    NgbModule,
    NgbPaginationModule,
    NgbAlertModule,
    FormsModule,
    ReactiveFormsModule
  ],
  providers: [
    CompanyService,
    AccountService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: JwtInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
