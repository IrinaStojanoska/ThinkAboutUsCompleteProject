import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { AdoptDogComponent } from './adopt-dog.component';

describe('AdoptDogComponent', () => {
  let component: AdoptDogComponent;
  let fixture: ComponentFixture<AdoptDogComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ AdoptDogComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(AdoptDogComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
