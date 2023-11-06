import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { RoutingModule } from './routing.module';
import { RootComponent } from './_components/root/root.component';
import { NavComponent } from './_components/nav/nav.component';
import { StuffListComponent } from './_components/stuff-list/stuff-list.component';
import { StuffEditComponent } from './_components/staff-edit/stuff-edit.component';
import { CategoryListComponent } from './_components/category-list/category-list.component';
import { CategoryEditComponent } from './_components/category-edit/category-edit.component';

@NgModule({
  declarations: [
    RootComponent,
    NavComponent,
    StuffListComponent,
    StuffEditComponent,
    CategoryListComponent,
    CategoryEditComponent,
  ],
  imports: [
    BrowserModule,
    RoutingModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [ RootComponent ]
})
export class AppModule { }
