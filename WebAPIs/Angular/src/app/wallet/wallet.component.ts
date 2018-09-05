import { Component, OnInit } from '@angular/core';
import { Wallet } from '../wallet';
import { WalletService } from '../services/wallet.service';
import { Transaction } from '../transaction';
import { Customer } from '../customer';

@Component({
  selector: 'app-wallet',
  templateUrl: './wallet.component.html',
  styleUrls: ['./wallet.component.scss']
})

export class WalletComponent implements OnInit {

  wallet:Wallet;
  transactions:Transaction[];
  transaction: Transaction;
  active: boolean = false;
  //customer: Customer;
  signedcredit: string;
  constructor(private walletService: WalletService) { }

  ngOnInit() {
    this.wallet = new Wallet();
    this.transaction = new Transaction();
    this.signedcredit = "0";
    //if user is logged in AND has an activated wallet, get data and instantiate wallet object with his/her info
    this.wallet = <Wallet>{
      Id: 1,
      Balance: 200,
      CustomerId: 8,
      Customer: {Id: 8,FirstName: "Jeremy",LastName: "Ariche",Email: "jeariche@gmail.com",IsActive: true},
      IsActive: this.active};
    //this.getTransactions()
  }

  getWallet(){
    this.walletService.getWallet(this.wallet.Id).subscribe((res)=>{
      
    });
  }

  updateWallet() {
    this.wallet.Balance = (parseFloat(this.signedcredit) > this.wallet.Balance) ? 0 : this.wallet.Balance + parseFloat(this.signedcredit);
    console.log(this.wallet.Balance);
    this.walletService.updateWallet(this.wallet).subscribe((res) => {
      //this.getTransactions();
      //Create transaction object
      alert("Wallet Updated successfully !!")
    });
  }

  updateWalletBalance(){
    
    this.wallet.Balance = (parseFloat(this.signedcredit) > this.wallet.Balance)? 0 : this.wallet.Balance + parseFloat(this.signedcredit);
    console.log(this.wallet.Balance);
    this.walletService.updateWalletBalance(this.wallet).subscribe((res)=>{
    //this.getTransactions();
    //Create transaction object
    alert("Wallet Updated successfully !!")
    });
  }

  updateWalletActive(){
    this.active = true;
    this.walletService.updateWalletActive(this.wallet).subscribe((res)=>{
    //this.getTransactions();
    console.log(this.wallet.IsActive);
    alert("Wallet updated successfully !!")
    });
  }

  updateWalletDeactive(){
    this.active = false;
    this.walletService.updateWalletDeactive(this.wallet).subscribe((res)=>{
    //this.getTransactions();
    console.log(this.wallet.IsActive);
    alert("Wallet updated successfully !!")
    });
  }

  getTransactions(){
    this.walletService.getTransactions().subscribe((t)=>{
    console.log(t);
    this.transactions = t;
    console.log(this.transactions);
    });
  }

  addTransactions(){
    this.walletService.addTransactions(this.transaction).subscribe((res)=>{
   // this.getTransactions();
    alert('Transaction added successfully!');
    });
  }

  // getCustomer(){
  //   this.walletService.getCustomer(this.customer.Id).subscribe((c)=>{
  //   console.log(c);
  //   this.customer = c;
  //   console.log(this.customer);
  //   });
  // }

  // addCustomer(){
  //   this.walletService.addCustomer(this.customer).subscribe((res)=>{
  //     //this.getCustomer();
  //     alert('Customer added successfully!');
  //   });
  // }

}

