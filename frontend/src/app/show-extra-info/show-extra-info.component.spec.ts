import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ShowExtraInfoComponent } from './show-extra-info.component';

describe('ShowExtraInfoComponent', () => {
  let component: ShowExtraInfoComponent;
  let fixture: ComponentFixture<ShowExtraInfoComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ShowExtraInfoComponent]
    })
    .compileComponents();

    fixture = TestBed.createComponent(ShowExtraInfoComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
