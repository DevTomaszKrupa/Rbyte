import { RbControlsModule } from './../../rb-controls/rb-controls.module';
import { NgModule } from '@angular/core';
import { ProductDashboardComponent } from './product-dashboard/product-dashboard.component';

@NgModule({
    imports: [
        RbControlsModule
    ],
    declarations: [
        ProductDashboardComponent
    ],
    providers: [
    ],
    exports: [
        ProductDashboardComponent
    ]
})
export class ProductModule { }
