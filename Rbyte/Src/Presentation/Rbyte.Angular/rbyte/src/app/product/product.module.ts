import { FormsModule } from '@angular/forms';
import { RouterModule } from '@angular/router';
import { RbControlsModule } from './../../rb-controls/rb-controls.module';
import { NgModule } from '@angular/core';
import { ProductDashboardComponent } from './dashboard/product-dashboard.component';
import { ProductListComponent } from './list/product-list.component';
import { CommonModule } from '@angular/common';
import { ProductCreateComponent } from './create/product-create.component';
import { ProductUpdateComponent } from './update/product-update.component';

@NgModule({
    imports: [
        RbControlsModule,
        CommonModule,
        RouterModule,
        FormsModule
    ],
    declarations: [
        ProductDashboardComponent,
        ProductListComponent,
        ProductCreateComponent,
        ProductUpdateComponent
    ],
    providers: [
    ],
    exports: [
        ProductDashboardComponent,
        ProductListComponent
    ]
})
export class ProductModule { }
