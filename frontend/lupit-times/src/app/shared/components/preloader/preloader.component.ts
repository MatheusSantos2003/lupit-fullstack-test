import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-ui-preloader',
  templateUrl: './preloader.component.html',
  styleUrls: ['./preloader.component.css']
})
export class PreloaderComponent implements OnInit {

  @Input() display = false;
  @Input() fullscreen = false;
  constructor() { }

  ngOnInit() {
  }

  /**
   * Shows the loader
   */
  show() {
    this.display = true;
  }

  /**
   * Hides the loader
   */
  hide() {
    this.display = false;
  }

}
