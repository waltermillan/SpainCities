import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { MapComponent } from './map/map.component';
import { ExtraComponent } from './extra/extra.component';

const routes: Routes = [
  { path: 'map', component: MapComponent }, 
  { path: '', redirectTo: '/map', pathMatch: 'full' },  
  { path: 'extra', component: ExtraComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
