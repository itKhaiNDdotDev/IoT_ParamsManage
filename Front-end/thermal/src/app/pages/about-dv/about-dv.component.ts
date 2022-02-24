import { Component, OnInit } from '@angular/core';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-about-dv',
  templateUrl: './about-dv.component.html',
  styleUrls: ['./about-dv.component.scss']
})
export class AboutDvComponent implements OnInit {
  

  constructor(private appService: AppService) { }

  deviceDetail: any=[];

  ngOnInit(): void {
  }

  refreshDeviceDetail() {
    this.appService.aboutDevice().subscribe(data => {
      this.deviceDetail=data;
      console.log(this.deviceDetail);
      console.log(this.deviceDetail.device_name);
    })
  }

}
