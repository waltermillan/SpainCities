import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient, withInterceptorsFromDi, withFetch   } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { MapComponent } from './map/map.component';
import { ExtraComponent } from './extra/extra.component';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import { LOCALE_ID } from '@angular/core';

// Register localization in Spanish (Spain)
registerLocaleData(localeEs, 'es');

@NgModule({
  declarations: [
    AppComponent,
    MapComponent,
    ExtraComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi(), withFetch()),
    {provide: LOCALE_ID, useValue: 'es' } // Set the locale to 'es' (Spain)
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
