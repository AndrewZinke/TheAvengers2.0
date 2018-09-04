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

  Stocks: Stocks[];
  Stock: Stocks;
  newStock: Stocks;

  constructor(private stockService: StocksService) { }

  ngOnInit() {
    this.newStock = new Stocks();
    this.newStock.id = 0;
    this.newStock.name = "<<name>>";
    this.newStock.symbol = "<<symbol>>";
    this.newStock.PPS = 0.0;
    this.newStock.change = 0;
    this.newStock.high = 0.0;
    this.newStock.low = 0.0;
    this.newStock.perChange = 0.0;
    this.newStock.shares = 0;
  }

  getStock(id) {
    this.stockService.getStock(id).subscribe(s => this.Stock = s);
  }

  getStocks() {
    this.stockService.getStocks().subscribe(s => this.Stocks = s);
  }


  addStock() {
    this.stockService.addStock(this.newStock).subscribe(hi => this.getStocks());
  }
}
