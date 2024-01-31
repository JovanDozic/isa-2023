import { Component, OnInit } from '@angular/core';
import { EquipmentService } from '../equipment.service';
import { Point } from '../../../shared/model/point.model';

@Component({
  selector: 'app-delivery',
  templateUrl: './delivery.component.html',
  styleUrl: './delivery.component.css',
})
export class DeliveryComponent implements  OnInit {
points: Point[] = [];

  constructor(private equipmentService: EquipmentService){}
  ngOnInit(): void {
    this.points.push({ longitude: 19.8369, latitude: 45.2517}, {longitude: 20.3091, latitude:44.8184})
  }

  startDelivery() {
    this.equipmentService.startDelivery().subscribe(
      (data) => console.log('Start delivery success!'),
      (err) => console.error('Error starting delivery: ', err),
    )
  }
}
