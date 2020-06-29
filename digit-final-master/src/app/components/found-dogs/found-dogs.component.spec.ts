import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { FoundDogsComponent } from './found-dogs.component';

describe('FoundDogsComponent', () => {
  let component: FoundDogsComponent;
  let fixture: ComponentFixture<FoundDogsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ FoundDogsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(FoundDogsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
