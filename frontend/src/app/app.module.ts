import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { provideHttpClient, withInterceptorsFromDi, withFetch   } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatDialogModule } from '@angular/material/dialog';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { registerLocaleData } from '@angular/common';
import localeEs from '@angular/common/locales/es';
import { LOCALE_ID } from '@angular/core';
import { ShowMapComponent } from './show-map/show-map.component';
import { ShowExtraInfoComponent } from './show-extra-info/show-extra-info.component';
import { InformationDialogComponent } from './modals/information-dialog/information-dialog.component';

// Register localization in Spanish (Spain)
registerLocaleData(localeEs, 'es');

@NgModule({
  declarations: [
    AppComponent,
    ShowMapComponent,
    ShowExtraInfoComponent,
    InformationDialogComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatDialogModule,
    AppRoutingModule
  ],
  providers: [
    provideHttpClient(withInterceptorsFromDi(), withFetch()),
    {provide: LOCALE_ID, useValue: 'es' } // Set the locale to 'es' (Spain)
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
