import { ComponentFixture, TestBed } from '@angular/core/testing';

import { HospitalBillComponent } from './hospital-bill.component';

describe('HospitalBillComponent', () => {
  let component: HospitalBillComponent;
  let fixture: ComponentFixture<HospitalBillComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [HospitalBillComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(HospitalBillComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
