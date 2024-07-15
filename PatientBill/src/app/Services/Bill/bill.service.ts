import { Injectable } from '@angular/core';
import { HttpService } from '../Http/http.service';
import { HttpHeaders } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  constructor(private http:HttpService) {  }
  AddPatient(data:any){
    let head={
      headers: new HttpHeaders({
        'content-type':'application/json',
      })
    }
    return this.http.PostMethod('https://localhost:44354/api/HospitalBill/AddPatient', data, false, head);
  }
  AddGrid(data:any){
    let head={
      headers: new HttpHeaders({
        'content-type':'application/json',
      })
    }
    return this.http.PostMethod('https://localhost:44354/api/HospitalBill/AddToGrid?billNo='+data.BillNo+'&InvestId='+data.InvestId, {}, false, head);
  }
  GetAllPatient(){
    let head={
      headers: new HttpHeaders({
        'content-type':'application/json',
      })
    }
    return this.http.GetMethodreset('https://localhost:44354/api/HospitalBill/GetAllPatient',false,head);
  }
  GetById(data:any){
    let head={
      headers: new HttpHeaders({
        'content-type':'application/json',
      })
    }
    return this.http.GetMethodreset('https://localhost:44354/api/HospitalBill/GetByBillNo?id='+data,false,head);
  }
  GetShowGrid(data:any){
    let head={
      headers: new HttpHeaders({
        'content-type':'application/json',
      })
    }
    return this.http.GetMethodreset('https://localhost:44354/api/HospitalBill/ShowGrid?BillNo='+data,false,head);
  }
}
