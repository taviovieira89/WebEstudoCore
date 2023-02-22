import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoadingService {
  
  HabDesabilitaLoading(visible: boolean) :void {
    const head = document.querySelector<HTMLElement>('#divloading')!;
    head.style.display = visible ? "block" : "none";
  }
}
