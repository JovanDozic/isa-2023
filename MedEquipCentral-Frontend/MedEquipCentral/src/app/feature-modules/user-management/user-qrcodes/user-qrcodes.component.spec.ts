import { ComponentFixture, TestBed } from '@angular/core/testing';

import { UserQrcodesComponent } from './user-qrcodes.component';

describe('UserQrcodesComponent', () => {
  let component: UserQrcodesComponent;
  let fixture: ComponentFixture<UserQrcodesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [UserQrcodesComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(UserQrcodesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
