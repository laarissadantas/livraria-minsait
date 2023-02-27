/* tslint:disable:no-unused-variable */
import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ListDeleteLivrosComponent } from './list-delete-livros.component';

describe('ListDeleteLivrosComponent', () => {
  let component: ListDeleteLivrosComponent;
  let fixture: ComponentFixture<ListDeleteLivrosComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ListDeleteLivrosComponent],
    }).compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ListDeleteLivrosComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
