import { LoaderService } from './../loader.service';
import { ChangeDetectorRef, Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-loader',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.scss']
})
export class LoaderComponent implements OnInit {

  showSpinner = false;

  constructor(private spinnerService: LoaderService, private cdRef: ChangeDetectorRef) {

  }

  ngOnInit(): void {
    this.init(); 
  }

  init() {

    this.spinnerService.getSpinnerObserver().subscribe((status) => {
      this.showSpinner = (status === 'start');
      // console.log(status);
      this.cdRef.detectChanges();
    });
  }

}
