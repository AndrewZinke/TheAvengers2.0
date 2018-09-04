import { Stocks } from "./stocks";
import { Customer } from "./customer";

export class Share {

  ID: number;
  price: number;
  stockID: number;
  customerID: number;

  stock: Stocks;
  customer: Customer;
}
