import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PickupUsingQrComponent } from './pickup-using-qr.component';

describe('PickupUsingQrComponent', () => {
  let component: PickupUsingQrComponent;
  let fixture: ComponentFixture<PickupUsingQrComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [PickupUsingQrComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(PickupUsingQrComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
