import { Component, OnInit } from '@angular/core';
import { Contact} from '../shared/contact.model';
import { ContactService } from '../shared/contact.service';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TagService } from '../shared/tag.service';
import { ContactFilter } from '../shared/contact-filter.model';

declare var window:any;

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styles: [
  ]
})
export class ContactComponent implements OnInit {

  formModal:any;
  formModalMail:any;
  formModalFilter: any;
  tempFilter: ContactFilter;
  constructor(public service: ContactService,private _router: Router,private route:ActivatedRoute, public tagService:TagService) { }

  ngOnInit(): void {
    this.service.refreshContacts()
    this.tagService.refreshTags();
    this.service.formModal = new window.bootstrap.Modal(
      document.getElementById("formModalEdit"));

    this.tagService.tagModal = new window.bootstrap.Modal(
      document.getElementById("tagModal"));

    this.tagService.addTagModal = new window.bootstrap.Modal(
      document.getElementById("addTagModal"));

    this.formModalFilter = new window.bootstrap.Modal(
      document.getElementById("filterModal"));

      

    this.route.queryParams.subscribe(params=>{
      if (params['id'] > 0){
        this.service.getContact(params['id']).subscribe(data=>{
          this.service.formData = data;
        })
      }
    });
    
  }

  updateContactData(selectedData: Contact){
    this._router.navigate(['contact'],{ queryParams: { id: selectedData.id } });
  }


  openEditModal(selectedData: Contact){
    this.service.openEditModal(selectedData);
  }

  openAddModal(){
    this.service.openAddModal();
  }

  closeModal(){
    this.service.closeModal();
  }

  openSelectedEditModal(){
    this.service.openSelectedEditModal();
  }

  public saveModal(){
    //byapass selection 0
    if (this.service.editFormData.tagId == 0){
      this.service.editFormData.tagId = null!; 
    }
    //continue
    if (this.service.editFormData.id == 0){
      this.service.postContact(this.service.editFormData).subscribe(
        data => {
          console.log(data);
          
          this.service.refreshContacts()
        },err=>{
            console.log(err);
          }
        );
      
      this.closeModal();
    }
    else{
      this.service.putContact(this.service.editFormData,this.service.editFormData.id).subscribe(
        data => {
          this.service.refreshContacts()
        },err=>{
            console.log(err);
        }
        );
      
      
      this.closeModal();
    }
  }

  onSubmitEditContact(form:NgForm){
    this.saveModal();
  }

  onDeleteContact(contactData: Contact){
    if (contactData.id == 0) return;
    this.service.deleteContact(contactData.id).subscribe(data=>{
      if (contactData.id == this.service.formData.id){
        this.service.formData = new Contact();
        this._router.navigate(['']);
      }
      this.service.refreshContacts();
    });
  }

  closeTagModal(){
    this.tagService.closeTagModal();
  }

  openTagModal(){
    this.tagService.openTagModal();
  }

  openAddTagModal(){
    this.tagService.openAddTagModal(); 
  }

  editContactTagChange(value:any){
    if (value == 0){
      this.service.editFormData.tagId = null!;
      this.service.editFormData.tag = null!;
      console.log(this.service.editFormData.tag)
    }
    this.service.editFormData.tagId = value;
  }

  closeFilterModal(){
    this.service.contactFilters = this.tempFilter;
    this.formModalFilter.toggle();
  }

  saveFilterModal(){
    this.service.refreshContacts();
    this.formModalFilter.toggle();
  }

  openFilterModal(){
    this.tempFilter = this.service.contactFilters;
    this.formModalFilter.show();
  }

  filterTagChange(value:any){
    this.service.contactFilters.tagId = value;
  }





}
