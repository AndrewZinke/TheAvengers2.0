import { Injectable } from '@angular/core';
import { Share } from '../share';
import { Observable } from 'rxjs/Observable';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { share } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class ShareService {
  url: string = "http://localhost:58962/api/Shares";

  shares: Observable<Share[]>;
  share: Observable<Share>;

  constructor(private client: HttpClient) { }

  getShare(id) {
    var newUrl = this.url + `/${id}`;
    var share = this.client.get<Share>(newUrl);
    return share;
  }

  getShares() {
    return this.client.get<Share[]>(this.url);
  }

  addShare(newShare: Share) {
    const headers = new HttpHeaders().set('content-type', 'application/json');
    var body = {
      ID: newShare.ID,
      price: newShare.price,
      customerID: newShare.customerID,
      stockID: newShare.stockID,
      stock: newShare.stock,
      customer: newShare.customer,
    };
    return this.client.post<Share>(this.url, body, { headers });
  }

}
