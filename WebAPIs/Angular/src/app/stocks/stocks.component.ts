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
    //this.newStock.PPS = "<<PPS>>" as number;
  }

}
