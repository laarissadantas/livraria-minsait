import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddEditEditoraComponent } from './add-edit-editora.component';

describe('AddEditEditoraComponent', () => {
  let component: AddEditEditoraComponent;
  let fixture: ComponentFixture<AddEditEditoraComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [AddEditEditoraComponent],
    }).compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddEditEditoraComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
