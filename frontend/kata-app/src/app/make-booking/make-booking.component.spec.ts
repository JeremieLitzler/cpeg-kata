import { ComponentFixture, TestBed } from '@angular/core/testing';

import { MakingBookingComponent } from './make-booking.component';

describe('MakingBookingComponent', () => {
  let component: MakingBookingComponent;
  let fixture: ComponentFixture<MakingBookingComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [MakingBookingComponent],
    }).compileComponents();

    fixture = TestBed.createComponent(MakingBookingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
