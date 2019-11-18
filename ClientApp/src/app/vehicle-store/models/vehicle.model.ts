import { Customer } from "./customer.model";

export interface Vehicle {
    id: number,
    vin: string,
    regNo:string,
    isConnected: boolean,
    customerId: number,
    customer:Customer
  }