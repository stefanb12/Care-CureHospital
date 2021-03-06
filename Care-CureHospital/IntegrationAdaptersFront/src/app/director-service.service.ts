import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http'; 
import { Observable, throwError } from 'rxjs';
import { Report } from './models/Report';
import { map, catchError } from 'rxjs/operators';
import { Offer } from './models/Offer';

@Injectable({
  providedIn: 'root'
})

export class DirectorServiceService {

  readonly APIUrl = "http://localhost:61793/gateway";

  constructor(private http:HttpClient) { this.getReportList() }

  getReportList():Observable<Report[]>{
    return this.http.get<Report[]>(this.APIUrl+'/report').
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  addReports(val:Report):Observable<Report>{
    return this.http.post<Report>(this.APIUrl+'/report', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  addOffers(val:Offer):Observable<Offer>{
    return this.http.post<Offer>(this.APIUrl+'/offer', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }
  
  updateReport(val:any){
    return this.http.put(this.APIUrl+'/report', val);
  }

  generate(val:any){
    return this.http.post<any[]>(this.APIUrl+'/report', val).
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Server is not responding!' );
      })
    )
  }

  publishTender(){
    return this.http.get<any[]>(this.APIUrl+'/tender').
    pipe(
      map((data: any) => {
        return data;
      }), catchError( error => {
        return throwError( 'Tender error!' );
      })
    )
  }
}
