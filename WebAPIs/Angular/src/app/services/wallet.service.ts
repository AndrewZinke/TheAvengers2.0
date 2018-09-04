import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Wallet } from '../wallet';
import { Transaction } from '../transaction';
import { Customer } from '../customer';

@Injectable({
  providedIn: 'root'
})
export class WalletService {

  url_w:string = "http://localhost:58962/api/Wallets"; 
  url_t:string = "http://localhost:58962/api/Transactions";
  url_c:string = "http://localhost:58962/api/Customers";

  wallet:Observable<Wallet>;
  transactions:Observable<Transaction[]>;
  customer:Observable<Customer>;
  constructor(private client: HttpClient) { }

  //Wallet Operations
  updateWallet(updateWallet: Wallet){
    this.url_w += `/${updateWallet.Id}`;
    //Update wallet information by wallet Id
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body_w = {
      Id: updateWallet.Id,
      Balance: updateWallet.Balance,
      IsActive: true,
      CustomerId: updateWallet.CustomerId,
    };
    //Call addTransactions
    return this.client.put<Wallet>(this.url_w, body_w, { headers });
  }

  getWallet(id){
    this.url_w += `/${id}`;
    //Get Transactions for current customer
    return this.client.get<Transaction[]>(this.url_t);
  }

  //Transaction Operations
  getTransactions(c_id){
    this.url_t += `/${c_id}`;
    //Get Transactions for current customer
    return this.client.get<Transaction[]>(this.url_t);
  }

  addTransactions(newtransaction:Transaction):Observable<Transaction>{
    //Add transaction for current user
    const headers = new HttpHeaders().set('content-type', 'application/json');
    //headers.set('method','POST');
    var body = {
      CustomerId: newtransaction.CustomerId,
      Amount: newtransaction.Amount,
      Description: newtransaction.Description,
    };
    console.log("Inside addTransactions from Service!");
    console.log(newtransaction.Id);
    console.log(newtransaction.CustomerId);
    console.log(newtransaction.Amount);
    console.log(newtransaction.Description);
    return this.client.post<Transaction>(this.url_t, body, { headers });
  }

  //Customer Operations
  getCustomer(id){
    this.url_c += `/${id}`;
    //Get Transactions for current customer
    return this.client.get<Customer>(this.url_c);
  }

  addCustomer(newCustomer:Customer){
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      Firstname: newCustomer.FirstName,
      Lastname: newCustomer.LastName,
      Id: newCustomer.Id,
      email: newCustomer.Email,
      IsActive:newCustomer.IsActive,
    };
    //alert(newCustomer.Firstname);
    return this.client.post<Customer>(this.url_c, body, {
      headers
    });
  }
}
