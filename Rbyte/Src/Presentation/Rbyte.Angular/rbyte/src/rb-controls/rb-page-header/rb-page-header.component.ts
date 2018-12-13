import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'rb-page-header',
  templateUrl: './rb-page-header.component.html',
  styleUrls: ['./rb-page-header.component.scss']
})
export class RbPageHeaderComponent implements OnInit {
  @Input() title: string;
  constructor() { }

  ngOnInit() {
  }

}
