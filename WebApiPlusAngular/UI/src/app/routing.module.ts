import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { HomeComponent } from './_components/home/home.component';
import { CategoryEditComponent } from './_components/category-edit/category-edit.component';
import { CategoryListComponent } from './_components/category-list/category-list.component';
import { StuffEditComponent } from './_components/staff-edit/stuff-edit.component';
import { StuffListComponent } from './_components/stuff-list/stuff-list.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'stuffs', component:  StuffListComponent },
  { path: 'stuff', component: StuffEditComponent },
  { path: 'stuff/:id', component: StuffEditComponent },
  /*{
    path: 'stuff',
    component: StuffEditComponent,
    children: [
      { path: ':id', component: StuffEditComponent }
    ]  
  },*/
  //{ path: 'stuff/:id', component: StuffEditComponent },
  { path: 'categories', component:  CategoryListComponent },
  { path: 'category/:id', component: CategoryEditComponent },
  { path: '**', redirectTo: '', pathMatch: 'full' },
];

@NgModule({
  imports: [ RouterModule.forRoot(routes) ],
  exports: [ RouterModule ]
})

export class RoutingModule { }
