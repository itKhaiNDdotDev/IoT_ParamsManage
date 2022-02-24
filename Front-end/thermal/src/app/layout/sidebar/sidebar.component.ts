import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {

  listDevice: any=[];

  constructor(private appService: AppService) { }

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
