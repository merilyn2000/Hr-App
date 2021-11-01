import { Company } from "./company";
import { EmployeeAddresses } from "./employeeAddresses";
import { EmployeeBankData } from "./employeeBankData";
import { EmployeeContacts } from "./employeeContacts";
import { EmployeeContracts } from "./employeeContracts";
import { EmployeeDependents } from "./employeeDependents";
import { EmployeeIdentityDocuments } from "./employeeIdentityDocuments";
import { EmployeePersonalDatas } from "./employeePersonalDatas";

export interface Employee {
  employeeId: number;
  firstName: string;
  lastName: string;
  PersonalIdentificationNumber: string;
  BirthDate: Date;
  BirthPlace: string;
  photo: string;
  employeePersonalDatas: EmployeePersonalDatas;
  employeeAddresses: EmployeeAddresses[];
  employeeContacts: EmployeeContacts[];
  employeeIdentityDocuments: EmployeeIdentityDocuments[];
  employeeBankData: EmployeeBankData[];
  employeeDependents: EmployeeDependents;
  employeeContracts: EmployeeContracts[];
  employeeCompany: Company;
}
