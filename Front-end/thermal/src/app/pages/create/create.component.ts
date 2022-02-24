import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AppService } from 'src/app/services/app.service';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent implements OnInit {

  constructor(private appService: AppService, public router: Router) { }

  public formModel:any={
    device_name:"",
    device_description:"",
    img_url:""
  };

  ngOnInit(): void {
  }

  public createDevice() {
    this.appService.createDevice(this.formModel).subscribe(data => {
      alert("Add Success!");
      this.router.navigate(["device"])
    }, err => { 
      alert('Add Failed!');
      this.router.navigate(["create"])
    });
  }

}
