import { Injectable } from '@angular/core';
import { ContactDetail } from './contact-detail.model';
import { HttpClient, HttpParams } from "@angular/common/http";
import { ContactFilter } from './contact-filter.model';


declare var window:any;
@Injectable({
  providedIn: 'root'
})
export class ContactDetailService {

  constructor(private http: HttpClient) { }
  formData: ContactDetail = new ContactDetail();
  editFormData: ContactDetail = new ContactDetail();
  list: ContactDetail[];
  formModal:any;
  contactFilters: ContactFilter = new ContactFilter();


  readonly baseURL = "http://localhost:5297/api/ContactDetails"

  getContactDetail(id:number){
    return this.http.get<ContactDetail>(`${this.baseURL}/${id}`);
  }

  getContacts(){
    //provjera filtera
    let params = new HttpParams();
  
    if(this.contactFilters.name != ""){
      params = params.set('name',this.contactFilters.name);
    }
    if(this.contactFilters.surname != ""){
      params = params.set("surname",this.contactFilters.surname);
    }
    if(this.contactFilters.tagId > 0){
      params = params.set("tagId",this.contactFilters.tagId);
    }

    return this.http.get<ContactDetail[]>(this.baseURL,{params});
  }

  postContactDetail(data: ContactDetail){
 
    return this.http.post(this.baseURL,data);
  }

  putContactDetail(data: ContactDetail, id:number){
    console.log(`${this.baseURL}/${id}`);
    return this.http.put(`${this.baseURL}/${id}`,data);
  }

  deleteContactDetail(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshContacts(){
    this.getContacts().subscribe((data:ContactDetail[])=> {
      this.list = data;
    });
    if (this.formData.id > 0){
      this.getContactDetail(this.formData.id).subscribe((data:ContactDetail)=>this.formData = data);
    }
    
  }



  updateEditFormData(selectedData: ContactDetail){
    this.editFormData = Object.assign({},selectedData);
  }

  openEditModal(selectedData: ContactDetail){
    this.updateEditFormData(selectedData);
    this.formModal.show();
  }

  openAddModal(){
    this.editFormData = new ContactDetail();
    this.formModal.show();
  }

  closeModal(){
    this.editFormData = new ContactDetail();
    this.formModal.toggle();
  }

  openSelectedEditModal(){
    if (this.formData.id == 0) return;
    this.updateEditFormData(this.formData);
    this.formModal.show();
  }





}
