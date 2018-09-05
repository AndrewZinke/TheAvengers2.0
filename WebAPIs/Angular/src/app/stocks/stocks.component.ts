import { Component, OnInit } from '@angular/core';
//import { Observable } from '@rxjs/Rx';
import { StocksService } from '../services/stocks.service';
import { Stocks } from '../stocks';

@Component({
  selector: 'app-stocks',
  templateUrl: './stocks.component.html',
  styleUrls: ['./stocks.component.scss']
})
export class StocksComponent implements OnInit {

  stocks: Stocks[];
  stock: Stocks;
  newStock: Stocks;

  constructor(private stockService: StocksService) { }

  ngOnInit() {
    this.newStock = new Stocks();
    this.newStock.id = 0;
    this.newStock.name = "";
    this.newStock.symbol = "";
    this.newStock.PPS = 0.0;
    this.newStock.high = 0.0;
    this.newStock.low = 0.0;
    this.newStock.shares = 0;
  }

  getStock(id) {
    this.stockService.getStock(id).subscribe(s => this.stock = s);
  }

  getStocks() {
    this.stockService.getStocks().subscribe(s => this.stocks = s);
  }


  addStock() {
    this.stockService.addStock(this.newStock).subscribe(hi => this.getStocks());
  }
}
