import { Component, OnInit } from '@angular/core';
import { ContactDetail } from '../shared/contact-detail.model';
import { ContactDetailService } from '../shared/contact-detail.service';
import { NgForm } from '@angular/forms';
import { Router, ActivatedRoute } from '@angular/router';
import { TagDetailService } from '../shared/tag-detail.service';
import { ContactFilter } from '../shared/contact-filter.model';

declare var window:any;

@Component({
  selector: 'app-contact-details',
  templateUrl: './contact-details.component.html',
  styles: [
  ]
})
export class ContactDetailsComponent implements OnInit {

  formModal:any;
  formModalMail:any;
  formModalFilter: any;
  tempFilter: ContactFilter;
  constructor(public service: ContactDetailService,private _router: Router,private route:ActivatedRoute, public tagService:TagDetailService) { }

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
        this.service.getContactDetail(params['id']).subscribe(data=>{
          this.service.formData = data;
        })
      }
    });
    
  }

  updateContactData(selectedData: ContactDetail){
    this._router.navigate(['contact'],{ queryParams: { id: selectedData.id } });
  }


  openEditModal(selectedData: ContactDetail){
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
    if (this.service.editFormData.tagDetailId == 0){
      this.service.editFormData.tagDetailId = null!; 
    }
    //continue
    if (this.service.editFormData.id == 0){
      this.service.postContactDetail(this.service.editFormData).subscribe(
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
      this.service.putContactDetail(this.service.editFormData,this.service.editFormData.id).subscribe(
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

  onDeleteContact(contactData: ContactDetail){
    if (contactData.id == 0) return;
    this.service.deleteContactDetail(contactData.id).subscribe(data=>{
      if (contactData.id == this.service.formData.id){
        this.service.formData = new ContactDetail();
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
      this.service.editFormData.tagDetailId = null!;
      this.service.editFormData.tagDetail = null!;
      console.log("TagDetail");
      console.log(this.service.editFormData.tagDetail)
    }
    this.service.editFormData.tagDetailId = value;
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
