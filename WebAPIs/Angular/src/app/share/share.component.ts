import { Component, OnInit } from '@angular/core';
import { Share } from '../share';
import { ShareService } from '../services/share.service';

@Component({
  selector: 'app-share',
  templateUrl: './share.component.html',
  styleUrls: ['./share.component.scss']
})
export class ShareComponent implements OnInit {

  shares: Share[];
  share: Share;
  newShare: Share;

  constructor(private shareService: ShareService) { }

  ngOnInit() {
    this.newShare.ID = 0;
    this.newShare.price = 0.0;
    this.newShare.stockID = 0;
    this.newShare.customerID = 0;
  }

  getShare(id) {
    this.shareService.getShare(id).subscribe(s => this.share = s);
  }

  getShares() {
    this.shareService.getShares().subscribe(s => this.shares = s);
  }

  addShare() {
    this.shareService.addShare(this.newShare).subscribe(hi => this.getShares());
  }
}
