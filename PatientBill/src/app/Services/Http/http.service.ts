import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class HttpService {
  constructor(private http:HttpClient) { }
  PostMethod(reqUrl: string,payload:any, token:boolean=false,httpoptions: any={})
  {
    return  this.http.post(reqUrl,payload,token && httpoptions);
  }
  GetMethodreset(url:string,token:boolean=false,httpoptions:any={}){
    return this.http.get(url,token && httpoptions);
  }
}
