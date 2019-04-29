import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ViewSantaComponent } from './view-santa.component';

describe('ViewSantaComponent', () => {
  let component: ViewSantaComponent;
  let fixture: ComponentFixture<ViewSantaComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ViewSantaComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ViewSantaComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
