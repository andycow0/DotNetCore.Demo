import { Injectable } from '@angular/core';
import { ICustomerService } from './icustomer.interface';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Customer } from '../model/customer.model';

@Injectable({
  providedIn: 'root'
})

export class CustomerService implements ICustomerService {

  constructor(private httpClient: HttpClient) { }

  delete(customerId: string): void {
    console.log('CustomerService delete Customer start!');
    
    this.httpClient.delete('http://localhost:5000/api/Customers/' + customerId);
  }

  getAllCustomers(): Observable<Customer[]> {
    console.log('getAllCustomers() GET starting!')
    // return this.httpClient.get<Customer[]>('https://dotnetcoredemo-217516.appspot.com/api/Customers');

    return this.httpClient.get<Customer[]>('http://localhost:5000/api/Customers/GetAllCustomers');
  }
}
