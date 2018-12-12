import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductDashboardComponentComponent } from './product-dashboard-component.component';

describe('ProductDashboardComponentComponent', () => {
  let component: ProductDashboardComponentComponent;
  let fixture: ComponentFixture<ProductDashboardComponentComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ProductDashboardComponentComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ProductDashboardComponentComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
