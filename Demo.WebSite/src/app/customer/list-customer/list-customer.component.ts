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
  }

  customers: Customer[];
  constructor(private customerService: ICustomerService) {
  }

  private getAllCustomers() {
    this.customerService.getAllCustomers()
      .subscribe(
        value => this.customers = value,
        error => console.log(error),
        () => console.log('getAllCustomers() GET completed!')
      );
  }

}
