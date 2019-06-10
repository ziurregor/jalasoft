import { Component, OnInit } from '@angular/core';
import { Hero } from '../roger';

@Component({
  selector: 'app-roger',
  templateUrl: './roger.component.html'
})
export class HeroesComponent implements OnInit {
  hero: Hero = {
    id: 1,
    name: 'Windstorm'
  };

  constructor() { }

  ngOnInit() {
  }

}