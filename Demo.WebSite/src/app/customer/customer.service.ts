import { Injectable } from '@angular/core';
import { ICustomerService } from './icustomer.interface';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { map, catchError, tap } from 'rxjs/operators'
import { Customer } from '../model/customer.model';

@Injectable({
  providedIn: 'root'
})

export class CustomerService implements ICustomerService {

  constructor(private httpClient: HttpClient) { }

  delete(customerId: string): void {
    console.log('CustomerService delete Customer start!');

    this.httpClient.delete('http://localhost:5000/api/Customers/9000').pipe(
      tap(_ => console.log('deleted Customer id:.')),
      catchError(this.handleError<any>('delete Customer'))
    );;
  }

  getAllCustomers(): Observable<Customer[]> {
    console.log('getAllCustomers() GET starting!')
    // return this.httpClient.get<Customer[]>('https://dotnetcoredemo-217516.appspot.com/api/Customers');

    return this.httpClient.get<Customer[]>('http://localhost:5000/api/Customers/GetAllCustomers');
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      console.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
}
