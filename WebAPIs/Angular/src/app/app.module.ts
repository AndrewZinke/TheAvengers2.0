import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';
<<<<<<< HEAD
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
=======
import { FormsModule } from '@angular/forms';
>>>>>>> dfc1b0274a4800c85bbe0a110a28eb40fb033b62

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { WalletComponent } from './wallet/wallet.component';
import { StocksComponent } from './stocks/stocks.component';
import { ShareComponent } from './share/share.component';
import { TransactionComponent } from './transaction/transaction.component';
import { CustomerService } from './services/customer.service';

@NgModule({
  declarations: [
    AppComponent,
    CustomerComponent,
    WalletComponent,
    StocksComponent,
    ShareComponent,
    TransactionComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
<<<<<<< HEAD
    FormsModule,
    HttpClientModule
=======
    HttpClientModule,
    FormsModule
>>>>>>> dfc1b0274a4800c85bbe0a110a28eb40fb033b62
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
