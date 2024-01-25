import { Component } from '@angular/core';
import { BrowserQRCodeReader } from '@zxing/browser';

@Component({
  selector: 'app-pickup-using-qr',
  templateUrl: './pickup-using-qr.component.html',
  styleUrl: './pickup-using-qr.component.css'
})
export class PickupUsingQrComponent {



  qrCodeReader = new BrowserQRCodeReader();

  onFileChange(event: Event) {
    const input = event.target as HTMLInputElement;
    if (input.files && input.files.length) {
      const file = input.files[0];
      this.scanQRCode(file);
    }
  }

  async scanQRCode(file: File) {
    try {
      const imageElement = new Image();
      const reader = new FileReader();
      reader.onload = () => {
        imageElement.src = reader.result as string;
        this.qrCodeReader.decodeFromImageElement(imageElement).then(result => {
          console.log('QR Code result: ', result);
          console.log(result.getText());
          this.handleQrCodeResult(result.getText());
        }).catch(err => {
          console.error('Error decoding QR Code:', err);
        });
      };
      reader.readAsDataURL(file);
    } catch (err) {
      console.error('Error decoding QR Code:', err);
    }
  }

  handleQrCodeResult(result: string) {

    const appointmentId = result.split('appointment-details/')[1];
    console.log('Appointment ID:', appointmentId);
  }



  
}
