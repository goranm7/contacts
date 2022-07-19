import { Injectable } from '@angular/core';
import { TelephoneDetail } from './telephone-detail.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TelephoneDetailService {
  telephoneData: TelephoneDetail = new TelephoneDetail();

  constructor(private http: HttpClient) { }

  readonly baseURL = "http://localhost:5297/api/TelephoneDetails"


  postPhone(data:TelephoneDetail){
    return this.http.post(this.baseURL,data);
  }

  deletePhone(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
