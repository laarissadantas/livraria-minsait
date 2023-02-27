import { ChangeDetectorRef, Component, OnInit } from '@angular/core';
import { LoaderService } from './core/services/loader.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
})
export class AppComponent implements OnInit {
  isLoading = false;

  constructor(
    public loaderService: LoaderService,
    public cd: ChangeDetectorRef
  ) {}

  ngOnInit() {
    this.loaderService.isLoading.subscribe((isLoading) => {
      this.isLoading = isLoading;
      this.cd.detectChanges();
    });
  }
}
