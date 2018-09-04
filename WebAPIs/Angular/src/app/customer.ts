import {Wallet} from './wallet'

export class Customer {
    Id:number;
    FirstName:string;
    LastName:string;
    Email:string;
    IsActive:boolean;
    WalletId:number;
    Wallet:Wallet;
    
}
