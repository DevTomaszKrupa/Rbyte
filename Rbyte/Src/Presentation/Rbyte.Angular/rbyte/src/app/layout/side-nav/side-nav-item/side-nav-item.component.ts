import { RouterModule } from '@angular/router';
import { Component, OnInit, Input } from '@angular/core';
import { SideNavItem } from '../../models/side-nav-item';

@Component({
  selector: 'side-nav-item',
  templateUrl: './side-nav-item.component.html',
  styleUrls: ['./side-nav-item.component.scss']
})
export class SideNavItemComponent implements OnInit {
  @Input() item: SideNavItem;
  constructor(private router: RouterModule) {
  }

  ngOnInit() {
  }

}
