import { Observable } from "rxjs";
import { Customer } from "../model/customer.model";

export abstract class ICustomerService {
    abstract getAllCustomers(): Observable<Customer[]>
}