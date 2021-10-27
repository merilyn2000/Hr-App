import { Employee } from "./employee";

export interface Company {
  id: number;
  companyName: string;
  dateOfEstablishment: Date;
  companyInformation: string;
  companyAddress: string;
  companyLogo: string;
  employees: Employee[];
}
