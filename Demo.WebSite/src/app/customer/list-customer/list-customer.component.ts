import { Component, OnInit } from '@angular/core';
import { Customer } from "../../model/customer.model";
import { ICustomerService } from '../icustomer.interface';

@Component({
  selector: 'app-list-customer',
  templateUrl: './list-customer.component.html',
  styleUrls: ['./list-customer.component.css']
})
export class ListCustomerComponent implements OnInit {

  ngOnInit(): void {
    this.getAllCustomers();
    //this.getAllString();
  }

  customers: Customer[];
  values: string[];

  constructor(private customerService: ICustomerService) {
  }

  private getAllCustomers() {

    console.log('getAllCustomers() GET start!');

    this.customerService.getAllCustomers()
      .subscribe(
        value => this.customers = value,
        error => console.log(error),
        () => console.log('getAllCustomers() GET completed!')
      );
  }

  delete(customerId: string) {

    console.log('delete Customer start!');

    this.customerService.delete(customerId);
  }
}
