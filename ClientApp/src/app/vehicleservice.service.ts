import { Injectable,Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable({
  providedIn: 'root'
})
export class VehicleserviceService {

  constructor( HttpClient, @Inject('BASE_URL') baseUrl: string) { }

}
