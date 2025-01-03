import { Component } from '@angular/core';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrls: ['./map.component.scss']  // Corregí el nombre 'styleUrl' por 'styleUrls'
})
export class MapComponent {
  regionClick(region: string) {
    //console.log('Has seleccionado la región: ' + region);
    window.open('Has seleccionado la región: ' + region);
    // Aquí podrías hacer una solicitud a tu API para obtener más información
    // this.apiService.getRegionInfo(region).subscribe(...);
  }

  getRamdonNumber()
  {
    return Math.floor(Math.random() * 10000001); // Genera un número entre 0 y 10,000,000
  }

  abrirVentana(nroRegion: number) {
    // Pasar el parámetro NroRegion en la URL al componente Extra
    const url = window.location.origin + '/extra?NroRegion=' + nroRegion + '&q=' + this.getRamdonNumber(); 
    const nombreVentana = '_blank';  // Nombre de la ventana (abre en una nueva pestaña)

    // Dimensiones de la nueva ventana
    const width = 1215;
    const height = 740;
    
    // Calcular la posición centrada en la pantalla
    const left = (window.screen.width - width) / 2 - 10;
    const top = (window.screen.height - height) / 2 - 10;

    // Especificaciones de la ventana
    const especificaciones = `width=${width},height=${height},left=${left},top=${top}`;
  
    window.open(url, nombreVentana, especificaciones);
  }

  x: number = 0;
  y: number = 0;

  // Lista de puntos con sus coordenadas y radios for all image
  /*
    puntos = [
    { x: 696, y: 575, radio: 14 },//1
    { x: 955, y: 226, radio: 14 },//2
    { x: 261, y: 683, radio: 14 },//3
    { x: 730, y: 80, radio: 14 },//4
    { x: 684, y: 199, radio: 14 },//5
    { x: 831, y: 422, radio: 14 },//6
    { x: 1101, y: 198, radio: 14 },//7
    { x: 754, y: 311, radio: 14 },//8
    { x: 886, y: 120, radio: 14 },//9
    { x: 958, y: 405, radio: 14 },//10
    { x: 593, y: 424, radio: 14 },//11
    { x: 490, y: 108, radio: 14 },//12
    { x: 1204, y: 374, radio: 14 },//13
    { x: 831, y: 159, radio: 14 },//14
    { x: 824, y: 91, radio: 14 },//15
    { x: 614, y: 69, radio: 14 },//16
    { x: 910, y: 536, radio: 14 },//17
    { x: 303, y: 685, radio: 14 },//18
    { x: 334, y: 685, radio: 14 },//19
  ];
  */
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

  // Función que verifica si el punto (x, y) está dentro de un círculo dado su centro y radio
  isInsideCircle(x: number, y: number, centroX: number, centroY: number, radio: number): boolean {
    // Calculamos la distancia al cuadrado desde el punto (x, y) al centro del círculo
    const distanciaCuadrada = Math.pow(x - centroX, 2) + Math.pow(y - centroY, 2);
    
    // Comprobamos si la distancia al cuadrado es menor o igual al radio al cuadrado
    return distanciaCuadrada <= Math.pow(radio, 2);
  }

  // Función que verifica si el clic está dentro de algún círculo de la lista de puntos
  checkCoordinates(x: number, y: number): void {
    let nroRegion;
    for (const punto of this.puntos) {
      nroRegion = (this.puntos.findIndex(punto => this.isInsideCircle(x, y, punto.x, punto.y, punto.radio))+1);
      if (this.isInsideCircle(x, y, punto.x, punto.y, punto.radio)) {
        //console.log('El punto está dentro del círculo en (' + punto.x + ', ' + punto.y + ') indice: ' + nroRegion + '.');
        this.abrirVentana(nroRegion);
        return; // Salimos de la función si encontramos el primer círculo donde está el punto
      }
    }
    //console.log('El punto está fuera de todos los círculos.');
  }

  capturarCoordenadas(event: MouseEvent): void {
    // Obtiene las coordenadas del clic
    this.x = event.clientX;
    this.y = event.clientY;
    console.log('x: ' + this.x + ', y: ' + this.y + ', radio: 14');
    //alert('x: ' + this.x + ', y: ' + this.y + ', radio: 14');
    this.checkCoordinates(this.x, this.y);
  }
}
