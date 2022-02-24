import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AboutDvComponent } from './about-dv.component';

describe('AboutDvComponent', () => {
  let component: AboutDvComponent;
  let fixture: ComponentFixture<AboutDvComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AboutDvComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AboutDvComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
