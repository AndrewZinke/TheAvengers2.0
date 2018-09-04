import { Injectable } from '@angular/core';

import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
//import { Http, Response, Headers, RequestOptions, RequestMethod } from '@angular/http';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/catch';
import 'rxjs/add/operator/retry';
import 'rxjs/add/observable/of';
import 'rxjs/Rx';

import {Customer} from '../customer';

@Injectable()
export class CustomerService {

  url:string = "http://localhost:58962/api/Customers";

  customers: Observable<Customer[]>;
  customer: Observable<Customer>;

  constructor(private client: HttpClient) {

  }
 
  //calls the get customer method from the customer api. 
  //Returns one customer
  getCustomer(id) {
    var newUrl = this.url + `/${id}`;
    var customer = this.client.get<Customer>(newUrl);
    return customer;

  }

  //return a list of customers, wont get used in the application
  getCustomers() {
    return this.client.get<Customer[]>(this.url);
  }

  //calls the add customer method from customer api
  addCustomer(newCustomer: Customer) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      FirstName: newCustomer.FirstName,
      LastName: newCustomer.LastName,
      Email: newCustomer.Email,
      WalletId: newCustomer.WalletId,
      IsActive: true
    };
    return this.client.post<Customer>(this.url, body, {
      headers
    });
  }

  //calls edit from the customer api
  editCustomer(editCustomer: Customer) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      Firstname: editCustomer.LastName,
      Lastname: editCustomer.FirstName,
      Id: editCustomer.Id
    };
    return this.client.put<Customer>(this.url + '/' + editCustomer.Id, body, {
      headers
    });
  }

  //calls delete from the customer api
  deleteCustomer(id: number) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    return this.client.delete(this.url + '/' + id);
  }
}

