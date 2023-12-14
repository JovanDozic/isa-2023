import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SystemAdminsManagementComponent } from './system-admins-management.component';

describe('SystemAdminsManagementComponent', () => {
  let component: SystemAdminsManagementComponent;
  let fixture: ComponentFixture<SystemAdminsManagementComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [SystemAdminsManagementComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(SystemAdminsManagementComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
