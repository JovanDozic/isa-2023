import {Component, AfterViewInit, Output, EventEmitter, Input} from '@angular/core';
import { MapService } from './map.service';
import * as L from 'leaflet';
import { Point } from '../model/point.model';

@Component({
  selector: 'app-map',
  templateUrl: './map.component.html',
  styleUrl: './map.component.css'
})
export class MapComponent implements AfterViewInit {
  private map: any;
  searchAddress: string = '';
  startingAddress: string = '';
  endingAddress: string = '';
  @Output() longitude: EventEmitter<number> = new EventEmitter<number>();
  @Output() latitude: EventEmitter<number> = new EventEmitter<number>();
  @Input() points: Point[] = [];

  private markers : L.Marker[] = [];

  constructor(private mapService: MapService) { }

  private initMap(): void {
    this.map = L.map('map', {
      center: [this.points[0].latitude, this.points[0].longitude],
      zoom: 10,
    });

    const tiles = L.tileLayer(
      'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
      {
        maxZoom: 20,
        minZoom: 3,
        attribution:
          '&copy; <a href="http://www.openstreetmap.org/copyright">OpenStreetMap</a>',
      }
    );

    console.log(this.points)
    this.points.forEach((point) => {
      const redIcon = L.icon({
        iconUrl: 'https://icons.veryicon.com/png/System/Small%20%26%20Flat/map%20marker.png',
        iconSize: [31, 41],
        iconAnchor: [13, 41],
      });

      const marker = new L.Marker([point.latitude, point.longitude], { icon: redIcon }).addTo(this.map);
      this.markers.push(marker);
    }); 
    
       tiles.addTo(this.map);
   // this.registerOnClick();
  }

  /*registerOnClick(): void {
    this.map.on('click', (e: any) => {
      const coord = e.latlng;
      const lat = coord.lat;
      const lng = coord.lng;
      this.latitude.emit(coord.lat);
      this.longitude.emit(coord.lng);
      console.log(
        'You clicked the map at latitude: ' + lat + ' and longitude: ' + lng
      );
      new L.Marker([lat, lng]).addTo(this.map);
    });
  }*/

  ngAfterViewInit(): void {
    let DefaultIcon = L.icon({
      iconUrl: 'https://unpkg.com/leaflet@1.6.0/dist/images/marker-icon.png',
      iconAnchor: [13, 41],
    });

    // here

    L.Marker.prototype.options.icon = DefaultIcon;
    this.initMap();
  }
}
