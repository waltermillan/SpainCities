import { Component } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss'] 
})
export class MapComponent {
  regionClick(region: string) {
    window.open('Has seleccionado la región: ' + region);

  }

  getRamdonNumber()
  {
    return Math.floor(Math.random() * 10000001);
  }

  abrirVentana(nroRegion: number) {
   
    const url = window.location.origin + '/extra?NroRegion=' + nroRegion + '&q=' + this.getRamdonNumber(); 
    const nombreVentana = '_blank';

    const width = 1215;
    const height = 740;
    
    const left = (window.screen.width - width) / 2 - 10;
    const top = (window.screen.height - height) / 2 - 10;

    const especificaciones = `width=${width},height=${height},left=${left},top=${top}`;
  
    window.open(url, nombreVentana, especificaciones);
  }

  x: number = 0;
  y: number = 0;
  puntos = [
    { x: 748, y: 522, radio: 14 },//1
    { x: 966, y: 229, radio: 14 },//2
    { x: 471, y: 646, radio: 14 },//3
    { x: 777, y: 95, radio: 14 },//4
    { x: 735, y: 196, radio: 14 },//5
    { x: 863, y: 387, radio: 14 },//6
    { x: 1108, y: 206, radio: 14 },//7
    { x: 797, y: 307, radio: 14 },//8
    { x: 914, y: 129, radio: 14 },//9
    { x: 970, y: 392, radio: 14 },//10
    { x: 661, y: 399, radio: 14 },//11
    { x: 554, y: 126, radio: 14 },//12
    { x: 1188, y: 376, radio: 14 },//13
    { x: 866, y: 166, radio: 14 },//14
    { x: 864, y: 101, radio: 14 },//15
    { x: 667, y: 84, radio: 14 },//16
    { x: 927, y: 494, radio: 14 },//17
    { x: 706, y: 649, radio: 14 },//18
    { x: 846, y: 680, radio: 14 },//19
  ];

  isInsideCircle(x: number, y: number, centroX: number, centroY: number, radio: number): boolean {

    const distanciaCuadrada = Math.pow(x - centroX, 2) + Math.pow(y - centroY, 2);
    return distanciaCuadrada <= Math.pow(radio, 2);
  }

  checkCoordinates(x: number, y: number): void {
    let nroRegion;
    for (const punto of this.puntos) {
      nroRegion = (this.puntos.findIndex(punto => this.isInsideCircle(x, y, punto.x, punto.y, punto.radio))+1);
      if (this.isInsideCircle(x, y, punto.x, punto.y, punto.radio)) {
        this.abrirVentana(nroRegion);
        return; 
      }
    }
  }

  capturarCoordenadas(event: MouseEvent): void {

    this.x = event.clientX;
    this.y = event.clientY;
    console.log('x: ' + this.x + ', y: ' + this.y + ', radio: 14');
    this.checkCoordinates(this.x, this.y);
  }
}
