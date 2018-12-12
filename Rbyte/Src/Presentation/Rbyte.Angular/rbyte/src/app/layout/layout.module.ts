import { NgModule } from '@angular/core';
import { SideNavComponent } from './side-nav/side-nav.component';
import { SideNavItemComponent } from './side-nav/side-nav-item/side-nav-item.component';

@NgModule({
    imports: [
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
