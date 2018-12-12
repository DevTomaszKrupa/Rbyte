import { Component, OnInit } from '@angular/core';
import { SideNavItem } from '../models/side-nav-item';

@Component({
  selector: 'side-nav',
  templateUrl: './side-nav.component.html',
  styleUrls: ['./side-nav.component.sass']
})
export class SideNavComponent implements OnInit {
  items: SideNavItem[] = [];
  
  constructor() {
    this.items.push(new SideNavItem("Produkty", 1));
    this.items.push(new SideNavItem("Magazyn", 2));
    this.items.push(new SideNavItem("Kategorie", 3));
  }

  ngOnInit() {
  }

}
