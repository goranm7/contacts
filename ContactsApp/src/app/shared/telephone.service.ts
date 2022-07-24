import { Injectable } from '@angular/core';
import { Telephone } from './telephone.model';
import { HttpClient } from "@angular/common/http";

@Injectable({
  providedIn: 'root'
})
export class TelephoneService {
  telephoneData: Telephone = new Telephone();

  constructor(private http: HttpClient) { }

  readonly baseURL = "http://localhost:5297/api/Telephone"


  postPhone(data:Telephone){
    return this.http.post(this.baseURL,data);
  }

  deletePhone(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }
}
