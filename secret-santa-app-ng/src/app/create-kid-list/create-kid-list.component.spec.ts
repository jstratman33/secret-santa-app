import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { CreateKidListComponent } from './create-kid-list.component';

describe('CreateKidListComponent', () => {
  let component: CreateKidListComponent;
  let fixture: ComponentFixture<CreateKidListComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ CreateKidListComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreateKidListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
