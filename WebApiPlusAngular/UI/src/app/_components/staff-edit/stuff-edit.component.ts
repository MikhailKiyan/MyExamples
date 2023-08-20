import { Component, OnDestroy, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'webng-stuff-edit',
  templateUrl: './stuff-edit.component.html',
  styleUrls: ['./stuff-edit.component.scss']
})
export class StuffEditComponent implements OnInit, OnDestroy {
  id: string = "default";

  constructor(private route: ActivatedRoute) { }

  ngOnInit() {
    this.id = this.route.snapshot.paramMap.get('id') ?? "new";
  }

  ngOnDestroy() {
  }

}