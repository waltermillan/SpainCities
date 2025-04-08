import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShowExtraInfoComponent } from './show-extra-info/show-extra-info.component';
import { ShowMapComponent } from './show-map/show-map.component';

const routes: Routes = [
  { path: 'show-map', component: ShowMapComponent },
  { path: '', redirectTo: '/show-map', pathMatch: 'full' }, 
  { path: 'show-extra-info', component: ShowExtraInfoComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
