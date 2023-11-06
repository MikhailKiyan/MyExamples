import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'webng-root',
  templateUrl: './root.component.html',
  styleUrls: ['./root.component.scss']
})
export class RootComponent {
  title = 'WebApi plus Angular';

  constructor(private http: HttpClient) {}

  onClick() {
    confirm('Clicked!');
  }

  onMakeRequest() {
    this.http
      .get('WeatherForecast')
      .subscribe(result => {
        console.dir(result);
        const json = JSON.stringify(result);
        confirm(json)
      });
  }
}
