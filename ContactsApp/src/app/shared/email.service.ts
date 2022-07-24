import { Injectable } from '@angular/core';
import { HttpClient } from "@angular/common/http";
import { Email } from './email.model';

@Injectable({
  providedIn: 'root'
})
export class EmailService {
  emailData: Email = new Email();
  readonly baseURL = "http://localhost:5297/api/Email"

  constructor(private http: HttpClient) { }


  postEmail(data:Email){
    return this.http.post(this.baseURL,data);
  }

  deleteEmail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }



}
