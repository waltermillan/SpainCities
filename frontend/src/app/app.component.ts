import { Component, OnInit } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { InformationDialogComponent } from './modals/information-dialog/information-dialog.component';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.scss'
})
export class AppComponent implements OnInit {
  title = 'SpainCities';

  constructor(private dialog: MatDialog) {
    
  }

  ngOnInit(): void {
    this.openDialog();
  }

  openDialog(): void {
    this.dialog.open(InformationDialogComponent, {
      data: {
        message: 'Click on the circles of each region to display information about the region.'
      }
    });
  }
}
