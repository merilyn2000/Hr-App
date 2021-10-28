import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Company } from '../models/company';
import { Employee } from '../models/employee';

@Injectable({
  providedIn: 'root'
})
export class CompanyService {

  private baseUrl = environment.companiesUrl;

  constructor(private httpClient: HttpClient) {}

  getCompanies(): Observable<Company[]> {
    return this.httpClient.get<Company[]>(this.baseUrl);
  }

  getCompany(id: number): Observable<Company> {
    const url = `${this.baseUrl}/${id}`;
    return this.httpClient.get<Company>(url);
  }

  addCompany(company: Company): Observable<Company> {
    return this.httpClient.post<Company>(this.baseUrl, company);
  }

  editCompany(companyId: number, company: Company): Observable<Company> {
    const url = `${this.baseUrl}/${companyId}`;
    return this.httpClient.put<Company>(url, company);
  }

  deleteCompany(companyId: number): Observable<Company> {
    const url = `${this.baseUrl}/${companyId}`;
    return this.httpClient.delete<Company>(url);
  }

  //---------------------------------------------------------

  getEmployee(id: number): Observable<Employee> {
    const url = `${this.baseUrl}/employee/${id}`;
    return this.httpClient.get<Employee>(url);
  }

  getEmployees(id: number): Observable<Employee[]> {
    const url = `${this.baseUrl}/employee/company/${id}`;
    return this.httpClient.get<Employee[]>(url);
  }

  addEmployee(companyId: number, employee: Employee): Observable<Employee> {
    const url = `${this.baseUrl}/employee/${companyId}`;
    return this.httpClient.post<Employee>(url, employee);
  }

  editEmployee(id: number, employee: Employee): Observable<Employee>  {
    const url = `${this.baseUrl}/employee/${id}`
    return this.httpClient.put<Employee>(url, employee);
  }

  deleteEmployee(id: number): Observable<Employee> {
    const url = `${this.baseUrl}/employee/${id}`;
    return this.httpClient.delete<Employee>(url);
  }
}
