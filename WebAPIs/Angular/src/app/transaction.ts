import { Customer } from "./customer";

export class Transaction {
    Id:number;
    CustomerId:number;
    Customer:Customer;
    Amount:number;
    Description:string;

    constructor(){
        this.Customer = new Customer();
    }
}

