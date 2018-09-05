import { Injectable } from '@angular/core';

import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { Stocks } from '../stocks';
import { Share } from '../share';

@Injectable({
  providedIn: 'root'
})
export class StocksService {

  url: string = "http://localhost:58962/api/Stocks";

  stocks: Observable<Stocks[]>;
  stock: Observable<Stocks>;

  constructor(private client: HttpClient) { }

  getStock(id) {
    var newUrl = this.url + `/${id}`;
    var stock = this.client.get<Stocks>(newUrl);
    return stock;
  }

  getStocks() {
    return this.client.get<Stocks[]>(this.url);
  }

  addStock(newStock: Stocks) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      id: newStock.id,
      name: newStock.name,
      symbol: newStock.symbol,
      PPS: newStock.PPS,
      low: newStock.low,
      high: newStock.high,
      shares: newStock.shares
    };
    return this.client.post<Stocks>(this.url, body, { headers });
  }

  editStock(stock: Stocks) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      id: stock.id,
      name: stock.name,
      symbol: stock.symbol,
      PPS: stock.PPS,
      low: stock.low,
      high: stock.high,
      shares: stock.shares
    };
    return this.client.put<Stocks>(this.url + '/' + stock.id, body, { headers });
  }

}
