import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CustomerComponent } from './customer/customer.component';
import { WalletComponent } from './wallet/wallet.component';
import { StocksComponent } from './stocks/stocks.component';
import { ShareComponent } from './share/share.component';
import { TransactionComponent } from './transaction/transaction.component';

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
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
