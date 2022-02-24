import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-devices',
  templateUrl: './devices.component.html',
  styleUrls: ['./devices.component.scss']
})
export class DevicesComponent implements OnInit {

  constructor(private appService: AppService) { }

  listDevice: any=[];

  ngOnInit(): void { 
    this.refreshDeviceList();
  }

  refreshDeviceList() {
    this.appService.getListDevice().subscribe(data => {
      this.listDevice=data;
      console.log(this.listDevice);
      console.log(this.listDevice.device_name);
    })
  }

}
