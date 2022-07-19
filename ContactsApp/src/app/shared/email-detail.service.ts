import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { EmailDetail } from './email-detail.model';

@Injectable({
  providedIn: 'root'
})
export class EmailDetailService {
  emailData: EmailDetail = new EmailDetail();
  readonly baseURL = "http://localhost:5297/api/EmailDetails"

  constructor(private http: HttpClient) { }


  postEmail(data:EmailDetail){
    return this.http.post(this.baseURL,data);
  }

  deleteEmail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }



}
