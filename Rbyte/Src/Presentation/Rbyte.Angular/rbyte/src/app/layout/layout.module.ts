import { RouterModule } from '@angular/router';
import { NgModule } from '@angular/core';
import { SideNavComponent } from './side-nav/side-nav.component';
import { SideNavItemComponent } from './side-nav/side-nav-item/side-nav-item.component';
import { CommonModule } from '@angular/common';

@NgModule({
    imports: [
        CommonModule,
        RouterModule
    ],
    declarations: [
        SideNavComponent,
        SideNavItemComponent
    ],
    providers: [
    ],
    exports: [
        SideNavComponent,
        SideNavItemComponent
    ]
})
export class LayoutModule { }
