import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import {map} from 'rxjs/operators'

export interface DeviceListModelServerResponse {
  countRecord: number;
  items: any[];
}

@Injectable({
  providedIn: 'root'
})

export class AppService {
  readonly baseUrl: string = 'https://localhost:5001';
  constructor(private http: HttpClient) { }

  getListDevice():Observable<any[]> {
    return this.http.get<DeviceListModelServerResponse>(this.baseUrl + '/api/Device/1/my-devices')
    .pipe(map(response => response.items));
  }

  aboutDevice(){
    return this.http.get(this.baseUrl + '/api/Device/1');
  }

  createDevice(val: any) {
    return this.http.post(this.baseUrl + '/api/Device', val)
  }
}
