import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { throwError } from 'rxjs';
import { retry, catchError } from 'rxjs/operators';
import { Vehicle } from './models/vehicle.model'
import { Customer } from './models/customer.model'
import { ServiceResponse } from './models/serviceresponse.model'

@Injectable({ providedIn: 'root' })
export class VehicleStoreService {

    private baseUrl: string;
    constructor(private http: HttpClient, @Inject('BASE_URL') baseUrl: string) {

        this.baseUrl = baseUrl;
    }

    getAllVehicles() {
        return this.http
            .get<ServiceResponse>(this.baseUrl + 'api/vehicle/getall')
            .pipe(retry(1), catchError(this.errorHandl));
    }

    getAllCustomers() {
      return  this.http.get<ServiceResponse>(this.baseUrl + 'api/customer/getall')
        .pipe(retry(1), catchError(this.errorHandl));
    }

    updateVehicleStatus() {
       return this.http.post(this.baseUrl + 'api/vehicle/updatestatus', null)
        .pipe(retry(1), catchError(this.errorHandl));
    }

    private errorHandl(error) {
        let errorMessage = '';
        if (error.error instanceof ErrorEvent) {
            errorMessage = error.error.message;
        } else {
            errorMessage = `Error Code: ${error.status}\nMessage: ${error.message}`;
        }
        console.log(errorMessage);
        return throwError(errorMessage);
    }
}