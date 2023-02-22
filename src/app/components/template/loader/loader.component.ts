import { Component, OnInit } from '@angular/core';
import { LoadingService } from './loader.service';

@Component({
  selector: 'app-loading',
  templateUrl: './loader.component.html',
  styleUrls: ['./loader.component.css']
})
export class LoadingComponent {
  isLoading: boolean;

  constructor(private loadingService: LoadingService) { }

}
