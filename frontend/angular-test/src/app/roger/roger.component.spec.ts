import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RogerComponent } from './roger.component';

describe('RogerComponent', () => {
  let component: RogerComponent;
  let fixture: ComponentFixture<RogerComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RogerComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RogerComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
