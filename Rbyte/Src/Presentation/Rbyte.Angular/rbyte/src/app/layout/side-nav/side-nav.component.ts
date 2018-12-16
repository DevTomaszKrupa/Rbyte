import { Component, OnInit } from '@angular/core';
import { SideNavItem } from '../models/side-nav-item';

@Component({
  selector: 'side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.scss']
})
export class SideNavComponent implements OnInit {
  items: SideNavItem[] = [];

  constructor() {
    this.items.push(new SideNavItem('Produkty', 1, 'products'));
    this.items.push(new SideNavItem('Magazyn', 2, 'storehouses'));
    this.items.push(new SideNavItem('Promocje', 3, 'discounts'));
    this.items.push(new SideNavItem('Kategorie', 4, 'categories'));
  }

  ngOnInit() {
  }

}
