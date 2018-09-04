import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';

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
    FormsModule,
    HttpClientModule
  ],
  providers: [CustomerService],
  bootstrap: [AppComponent]
  
})
export class AppModule { }
