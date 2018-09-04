import { Transaction } from "./transaction";
import { Customer } from "./customer";

export class Wallet {
    //Wallet Id
    Id:number;

    //Customer Id who owns this wallet 
    CustomerId:number;

    //Customer object who owns this wallet 
    Customer: Customer;
    
    //Amount of Money available in this wallet
    Balance:number;

    //State of Wallet {Active Wallet/Inactive Wallet}
    IsActive:boolean;

    //Transactions that occured for this wallet
    Transactions:Transaction[];
}

