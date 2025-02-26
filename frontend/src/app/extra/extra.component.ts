import { Component, OnInit, Inject, PLATFORM_ID } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { CityService } from '../services/city.service';  
import { ProvinceService } from '../services/province.service';  
import { RegionService } from '../services/region.service';
import { Region } from '../models/region.model';
import { Province } from '../models/province.model';
import { City } from '../models/city.model';
import { PictureService } from '../services/picture.service';
import { isPlatformBrowser } from '@angular/common';

@Component({
  selector: 'app-extra',
  templateUrl: './extra.component.html',
  styleUrls: ['./extra.component.scss']
})
export class ExtraComponent implements OnInit {

  pictures: string[] = [];
  currentIndex: number = 0;
  province: string = '';
  cities: string = ''; 
  region: string = '';
  population: number = 0;
  surface: number = 0;
  capital: string = '';
  picture: string = '';
  provinces: Province[] = [];
  provincesString: string = ''; 

  constructor(
    private route: ActivatedRoute,
    private regionService: RegionService,
    private cityService:CityService,
    private provinceService:ProvinceService,
    private pictureService: PictureService,
    @Inject(PLATFORM_ID) private platformId: Object,
  ) {}

  ngOnInit(): void {
    // Obtener el ID de la región desde la URL
    const regionId = this.route.snapshot.queryParamMap.get('NroRegion');
    if (regionId) {
      this.getRegionInfo(Number(regionId)); 
      this.loadPictures(Number(regionId));

      this.loadProvinces(Number(regionId));

      this.loadCities(Number(regionId));

      // Solo se ejecuta en el navegador
      if (isPlatformBrowser(this.platformId)) {
        setInterval(() => this.nextPicture(), 5000);
      }
    }
  }

  closeWindow(): void {
    window.close();
  }

  // Método para cargar todas las provincias
  loadProvinces(regionId: number): void {
    this.provinceService.getProvincesByRegion(regionId).subscribe((response: any) => {
      this.provinces = response.provinces;
      // Concatenar las provincias con "/"
      this.provincesString = this.provinces.map(province => province.name).join(' / ');
    });
  }

  // Método para obtener la información de la región
  getRegionInfo(regionId: number): void {
    this.regionService.getRegion(regionId).subscribe((data: Region) => {
      this.region = data.name;
      this.population = data.population;
      this.capital = data.capital;
      this.surface = data.surface;
    });

    this.provinceService.getProvince(regionId).subscribe((data: Province) => {
      this.province = data.name;
    });

    this.cityService.getCity(regionId).subscribe((data: City) => {
      this.cities = data.name;
    });
  }

  // Método para cargar las ciudades y formatearlas como una cadena separada por "/"
  loadCities(regionId: number): void {
    this.cityService.getCitiesByRegion(regionId).subscribe((cities: City[]) => {
      // Unir todas las ciudades con un "/"
      this.cities = cities.map(city => city.name).join(' / ');
    });
  }

  loadPictures(regionId: number): void {
    const ids = this.getPictureIdsForRegion(regionId);
    ids.forEach(id => {
      this.pictureService.getPicture(id).subscribe({
        next: (data) => {
          this.pictures.push(data.imageBase64);
        },
        error: (error) => {
          console.error('Error al cargar la imagen:', error);
        },
        complete: () => {
          console.log('Carga de imágenes completada.');
        }
      });
    });
  }

  getPictureIdsForRegion(regionId: number): number[] {

    switch (regionId) {
      case 1:
        return [59, 1, 2, 3, 38];  // Carga imágenes para la región 1
      case 2:
        return [66, 65, 4, 5];  // Carga imágenes para la región 2
      case 3:
        return [78, 7, 6, 8, 9];  // Carga imágenes para la región 3
      case 4:
          return [75, 10, 11, 12];  // Carga imágenes para la región 4
      case 5:
            return [68, 13, 14, 15, 16, 17];  // Carga imágenes para la región 5
      case 6:
              return [64, 18, 19, 20];  // Carga imágenes para la región 6
      case 7:
              return [67, 21, 22, 23];  // Carga imágenes para la región 7
      case 8:
              return [60, 24, 25, 26];  // Carga imágenes para la región 8
      case 9:
              return [73, 27, 28, 72];  // Carga imágenes para la región 9
      case 10:
              return [63, 29, 30, 31];  // Carga imágenes para la región 10
      case 11:
            return [61, 32, 33, 34];  // Carga imágenes para la región 11
      case 12:
            return [77, 35, 36, 37];  // Carga imágenes para la región 12
      case 13:
            return [70, 39, 40, 69];  // Carga imágenes para la región 13
      case 14:
            return [71, 41, 42, 43];  // Carga imágenes para la región 14
      case 15:
            return [74, 44, 45, 46];  // Carga imágenes para la región 15
      case 16:
            return [76, 47, 48, 49];  // Carga imágenes para la región 16
      case 17:
            return [62, 50, 51, 52];  // Carga imágenes para la región 17
      case 18:
            return [79, 53, 54, 55];  // Carga imágenes para la región 18
      case 19:
            return [ 80, 56, 57, 58];  // Carga imágenes para la región 19
      default:
        return [1, 2, 3];  // Por defecto, carga las imágenes de la región 1
    }
  }

  // Cambia a la siguiente imagen
  nextPicture(): void {
    this.currentIndex = (this.currentIndex + 1) % this.pictures.length;
  }

  // Cambia a la imagen anterior
  prevPicture(): void {
    this.currentIndex = (this.currentIndex - 1 + this.pictures.length) % this.pictures.length;
  }
}
