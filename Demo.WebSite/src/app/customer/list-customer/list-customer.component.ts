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
    //this.customerId = '';
  }

  customers: Customer[];
  values: string[];
  customer: Customer;
  customerId: number;
  show: boolean;

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

  find(): void {
    if (Number(this.customerId) > 0 || !this.isEmpty(this.customerId)) {
      console.log('starting find customerId:' + this.customerId.toString());
      // this.postService.find(this.postId, this.post);
      this.customerService.getAllCustomers()
        .subscribe(
          (response) => {
            let result = response;
            //console.log(result.length);
            console.log(result);
            var id = this.pad(this.customerId, 5);
            console.log(id);
            if (result.length > 0)
              this.customers = result.filter(p => p.customerId == id);
            else
              this.customers = result;
            console.log(this.customers.length);
            if (this.customers.length > 0) {
              this.customer = this.customers[0];
              this.show = true;
            }
            else { this.show = false; }

          }
        );
    }
    else {
      this.getAllCustomers();
      this.show = false;
    }
  }
  isEmpty(input) {
    return (input.replace(/\s/g, "").length > 0 ? false : true);
  }
  pad(num: number, size: number): string {
    let s = num + "";
    while (s.length < size) s += " ";
    return s;
  }

  delete(customerId: string) {

    console.log('delete Customer start!');

    this.customerService.delete(customerId);
  }
}
