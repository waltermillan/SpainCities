import { Component, OnInit } from '@angular/core';
import { RegionService } from '../services/region.service'; // Ensure the import is correct

@Component({
  selector: 'app-show-map',
  templateUrl: './show-map.component.html',
  styleUrls: ['./show-map.component.scss']
})
export class ShowMapComponent implements OnInit {
  public selectedRegion: any = null; // Here we will store the selected region
  public showMessage: boolean = true; // Flag to control the visibility of the message

  x: number = 0; // X coordinate for the mouse click
  y: number = 0; // Y coordinate for the mouse click

  points = [
    // The points for the regions that you already have
    { x: 346, y: 526, radius: 14 }, // 1
    { x: 577, y: 214, radius: 14 }, // 2
    { x: 70, y: 648, radius: 14 }, // 3
    { x: 375, y: 73, radius: 14 }, // 4
    { x: 316, y: 177, radius: 14 }, // 5
    { x: 458, y: 378, radius: 14 }, // 6
    { x: 717, y: 196, radius: 14 }, // 7
    { x: 390, y: 295, radius: 14 }, // 8
    { x: 516, y: 115, radius: 14 }, // 9
    { x: 580, y: 383, radius: 14 }, // 10
    { x: 249, y: 390, radius: 14 }, // 11
    { x: 139, y: 102, radius: 14 }, // 12
    { x: 766, y: 369, radius: 14 }, // 13
    { x: 468, y: 147, radius: 14 }, // 14
    { x: 459, y: 77, radius: 14 }, // 15
    { x: 264, y: 61, radius: 14 }, // 16
    { x: 528, y: 490, radius: 14 }, // 17
    { x: 303, y: 645, radius: 14 }, // 18
    { x: 442, y: 675, radius: 14 }, // 19
  ];

  constructor(private regionService: RegionService) {}

  ngOnInit(): void {
    // Set a delay to hide the message after a brief period to simulate an initial user message
    setTimeout(() => {
      this.showMessage = false; // Hide the message after a few seconds
    }, 3000); // The message will disappear after 3 seconds
  }

  // This function checks if the mouse click (x, y) is inside a given circle
  isInsideCircle(x: number, y: number, centerX: number, centerY: number, radius: number): boolean {
    const distanceSquared = Math.pow(x - centerX, 2) + Math.pow(y - centerY, 2);
    return distanceSquared <= Math.pow(radius, 2);
  }

  // This function checks which region is clicked based on coordinates and loads its info
  checkCoordinates(x: number, y: number): void {
    for (const point of this.points) {
      const regionNumber = this.points.findIndex(point => this.isInsideCircle(x, y, point.x, point.y, point.radius)) + 1;
      if (this.isInsideCircle(x, y, point.x, point.y, point.radius)) {
        this.loadRegionInfo(regionNumber); // Load the information of the selected region
        return;
      }
    }
  }

  // This function captures the coordinates when a user clicks on the map
  captureCoordinates(event: MouseEvent): void {
    this.x = event.clientX; // Get X coordinate of the click
    this.y = event.clientY; // Get Y coordinate of the click

    this.checkCoordinates(this.x, this.y); // Check which region was clicked based on coordinates
  }

  // This function loads information about the selected region using the RegionService
  loadRegionInfo(regionId: number): void {
    // Use the service to get the region's information
    this.regionService.getRegion(regionId).subscribe((data: any) => {
      this.selectedRegion = data; // Set the selected region
    });
  }
}
