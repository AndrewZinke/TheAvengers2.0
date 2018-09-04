import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs/Rx';
import { CustomerService } from '../services/customer.service';
import { Customer } from '../customer';

@Component({
  selector: 'app-customer',
  templateUrl: './customer.component.html',
  styleUrls: ['./customer.component.scss']
})
export class CustomerComponent implements OnInit {

  customers: Customer[];
  customer:Customer;
  customerToAdd: Customer;

  constructor(private customerService: CustomerService) {

  }

  ngOnInit() {
    this.customerToAdd = new Customer();
    this.customerToAdd.FirstName = "firstname";
    this.customerToAdd.LastName = "lastname";
    this.customerToAdd.Email = "Email"
    
    // this.getCustomer();
    // this.getCustomers();
  }

  getCustomer() {
    // Get one customer data.
    this.customerService.getCustomer(101)
      .subscribe(c => {
        this.customer = c;
        console.log(this.customer);
      });
  }

  getCustomers() {
    this.customerService.getCustomers()
      .subscribe(c => {
        console.log(c);
        this.customers = c;
        console.log(this.customers);
      });
  }

  addCustomer() {
    this.customerService.addCustomer(this.customerToAdd)
      .subscribe(res => {
        this.getCustomers();
        alert('Customer added successfully!');
      }),
      err => {
        console.log("Error occurred: " + err);
      };
    }

  updateCustomer() {
    this.customerService.editCustomer(this.customer)
      .subscribe(res => {
        this.getCustomers();
        alert("Customer data Updated successfully !!")
      });
  }

  deleteCustomer(id) {
    //alert('Deleting Customer with id: ' + id);
    this.customerService.deleteCustomer(id)
      .subscribe(res => {
        this.getCustomers();
        alert(`Customer with Id ${id}  Deleted successfully !!`)
      });
  }
}
