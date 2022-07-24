import { Injectable } from '@angular/core';
import { Contact } from './contact.model';
import { HttpClient, HttpParams } from "@angular/common/http";
import { ContactFilter } from './contact-filter.model';


declare var window:any;
@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }
  formData: Contact = new Contact();
  editFormData: Contact = new Contact();
  list: Contact[];
  formModal:any;
  contactFilters: ContactFilter = new ContactFilter();


  readonly baseURL = "http://localhost:5297/api/Contact"

  getContact(id:number){
    return this.http.get<Contact>(`${this.baseURL}/${id}`);
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

    return this.http.get<Contact[]>(this.baseURL,{params});
  }

  postContact(data: Contact){
 
    return this.http.post(this.baseURL,data);
  }

  putContact(data: Contact, id:number){
    console.log(`${this.baseURL}/${id}`);
    return this.http.put(`${this.baseURL}/${id}`,data);
  }

  deleteContact(id:number){
    return this.http.delete(`${this.baseURL}/${id}`);
  }

  refreshContacts(){
    this.getContacts().subscribe((data:Contact[])=> {
      this.list = data;
    });
    if (this.formData.id > 0){
      this.getContact(this.formData.id).subscribe((data:Contact)=>this.formData = data);
    }
    
  }



  updateEditFormData(selectedData: Contact){
    this.editFormData = Object.assign({},selectedData);
  }

  openEditModal(selectedData: Contact){
    this.updateEditFormData(selectedData);
    this.formModal.show();
  }

  openAddModal(){
    this.editFormData = new Contact();
    this.formModal.show();
  }

  closeModal(){
    this.editFormData = new Contact();
    this.formModal.toggle();
  }

  openSelectedEditModal(){
    if (this.formData.id == 0) return;
    this.updateEditFormData(this.formData);
    this.formModal.show();
  }





}
