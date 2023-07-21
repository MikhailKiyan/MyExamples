import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'english-world';

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
