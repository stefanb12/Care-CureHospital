import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Offer } from './models/Offer';
import { Tender } from './models/Tender';
import { Observable, throwError } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class TenderServiceService {
 readonly APIUrl = "http://localhost:51492/api";
 //readonly APIUrl = "http://localhost:60370/gateway";

  constructor(private http:HttpClient) {
     this.getOfferListActive() ,
     this.getOfferListInactive()
  }

  getOfferListActive():Observable<Offer[]>{
    return this.http.get<Offer[]>(this.APIUrl+'/offer/activeTender');
  }

  getOfferListInactive():Observable<Offer[]>{
    return this.http.get<Offer[]>(this.APIUrl+'/offer/inactiveTender');
  }

  getActiveTender():Observable<Tender[]>{
    return this.http.get<Tender[]>(this.APIUrl+'/tender/getActiveTender');
  }

  chooseTender(){
    return this.http.get<any[]>(this.APIUrl+'/offer/winner');
  }

  closeTender(id:number):Observable<Tender>{
    return this.http.put<Tender>(this.APIUrl+ '/tender/closeTender/{tenderId}', id); //'offer/notWinner
  }
}
