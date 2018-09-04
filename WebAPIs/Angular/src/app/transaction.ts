import {Customer} from "./customer"

export class Transaction {
    customerId:number;
    id:number;
    amount:number;
    description:string;

    customer:Customer;
}
