import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { StocksComponent } from './stocks/stocks.component';
import { CustomerComponent} from './customer/customer.component'

const routes: Routes = [
  { path: 'stocks', component: StocksComponent},
  { path: 'customer', component: CustomerComponent}];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
