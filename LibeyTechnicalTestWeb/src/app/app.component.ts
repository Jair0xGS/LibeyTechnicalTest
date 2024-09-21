import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  constructor(
    private router:Router,
  ){}

  title = 'LibeyTechnicalTest';
  search=""
  doSearch(){
    console.log('search',this.search)
    this.router.navigate([`/user/maintenance`],{queryParams:{documentNumber:this.search}}); 
  }
}
