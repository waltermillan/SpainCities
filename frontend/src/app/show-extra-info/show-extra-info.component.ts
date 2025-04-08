import { Component, Input, OnInit, OnChanges, SimpleChanges, OnDestroy } from '@angular/core';
import { CityService } from '../services/city.service';
import { ProvinceService } from '../services/province.service';
import { RegionService } from '../services/region.service';
import { City } from '../models/city.model';
import { Province } from '../models/province.model';
import { PictureService } from '../services/picture.service';

@Component({
  selector: 'app-show-extra-info',
  templateUrl: './show-extra-info.component.html',
  styleUrls: ['./show-extra-info.component.scss']
})
export class ShowExtraInfoComponent implements OnInit, OnChanges, OnDestroy {
  @Input() region: any; // Receive the selected region as input

  pictures: string[] = []; 
  currentIndex: number = 0; 
  population: number = 0;
  surface: number = 0; 
  capital: string = ''; 
  cities: string = ''; 
  provincesString: string = ''; 

  private pictureInterval: any;
  private imagesLoaded: boolean = false;

  constructor(
    private regionService: RegionService,
    private cityService: CityService,
    private provinceService: ProvinceService,
    private pictureService: PictureService
  ) {}

  // ngOnInit is used to initialize the component when it is first loaded
  ngOnInit(): void {
    if (this.region) {
      this.loadData(this.region.id); // Load the data for the selected region
    }
  }

  // ngOnChanges is called whenever an input property (in this case, 'region') changes
  ngOnChanges(changes: SimpleChanges): void {
    if (changes['region'] && this.region) {
      this.loadData(this.region.id); // Reload the data when the region changes
    }
  }

  // ngOnDestroy is called when the component is destroyed (e.g., when navigating away from the component)
  ngOnDestroy(): void {
    // Clear the image change interval when the component is destroyed
    if (this.pictureInterval) {
      clearInterval(this.pictureInterval);
    }
  }

  // loadData is used to initialize all the data for the region
  loadData(id: number) {
    // Clear previous images
    this.pictures = [];
    this.imagesLoaded = false;

    // Load the region info, pictures, provinces, and cities
    this.loadRegionInfo(id);
    this.loadPictures(id);
    this.loadProvinces(id);
    this.loadCities(id);
  }

  // loadRegionInfo loads information about the region such as population, surface, and capital
  loadRegionInfo(regionId: number): void {
    this.regionService.getRegion(regionId).subscribe((data: any) => {
      this.population = data.population;
      this.surface = data.surface;
      this.capital = data.capital;
    });
  }

  // loadProvinces loads the provinces for the given region and combines them into a string
  loadProvinces(regionId: number): void {
    this.provinceService.getProvincesByRegion(regionId).subscribe((response: any) => {
      this.provincesString = response.provinces.map((province: Province) => province.name).join(' / ');
    });
  }

  // loadCities loads the cities for the given region and combines them into a string
  loadCities(regionId: number): void {
    this.cityService.getCitiesByRegion(regionId).subscribe((cities: City[]) => {
      this.cities = cities.map(city => city.name).join(' / ');
    });
  }

  // loadPictures loads the pictures for the given region by calling the PictureService
  loadPictures(regionId: number): void {
    this.pictureService.getByRegionId(regionId).subscribe(
      (response) => {
  
        // Make sure the response is an array of objects
        if (response && Array.isArray(response)) {
          let picturesCount = 0;
  
          // Iterate through the array and extract the base64 images
          response.forEach((imageData: any) => {
            this.pictures.push(imageData.imageBase64); // Add the base64 image data to the pictures array
  
            picturesCount++;
  
            // Once all images have been loaded, start the image change interval
            if (picturesCount === response.length) {
              this.imagesLoaded = true;
              this.startImageChangeInterval();
            }
          });
        } else {
          console.error('The response is not an array or does not contain expected images.');
        }
      },
      (error) => {
        console.error('Error loading images for the region:', error);
      }
    );
  }

  // startImageChangeInterval starts the interval for changing the image every 5 seconds
  startImageChangeInterval() {
    if (this.imagesLoaded && this.pictures.length > 0) {
      // If an interval is already running, clear it before starting a new one
      if (this.pictureInterval) {
        clearInterval(this.pictureInterval);
      }

      // Start a new interval to change images every 5 seconds
      this.pictureInterval = setInterval(() => {
        this.nextPicture();
      }, 5000); // Change image every 5 seconds
    }
  }

  // nextPicture changes to the next image in the array
  nextPicture(): void {
    if (this.pictures.length > 0) {
      this.currentIndex = (this.currentIndex + 1) % this.pictures.length;
    }
  }

  // prevPicture changes to the previous image in the array
  prevPicture(): void {
    if (this.pictures.length > 0) {
      this.currentIndex = (this.currentIndex - 1 + this.pictures.length) % this.pictures.length;
    }
  }
}
