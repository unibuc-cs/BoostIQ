import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { LearnCategoryComponent } from './learn-category.component';

describe('LearnCategoryComponent', () => {
  let component: LearnCategoryComponent;
  let fixture: ComponentFixture<LearnCategoryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ LearnCategoryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(LearnCategoryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
