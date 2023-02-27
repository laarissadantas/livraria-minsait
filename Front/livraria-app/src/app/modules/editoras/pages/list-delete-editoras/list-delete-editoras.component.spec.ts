/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDeleteEditorasComponent } from './list-delete-editoras.component';

describe('ListDeleteEditorasComponent', () => {
  let component: ListDeleteEditorasComponent;
  let fixture: ComponentFixture<ListDeleteEditorasComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ListDeleteEditorasComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListDeleteEditorasComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
