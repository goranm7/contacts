import { Component, EventEmitter,  OnInit, Output } from "@angular/core";
import { ContactDetail } from 'src/app/shared/contact-detail.model';
import { ContactDetailService } from 'src/app/shared/contact-detail.service';
import { NgForm } from '@angular/forms';
import { EmailDetailService } from 'src/app/shared/email-detail.service';
import { EmailDetail } from 'src/app/shared/email-detail.model';
import { TelephoneDetailService } from "src/app/shared/telephone-detail.service";
import { TelephoneDetail } from "src/app/shared/telephone-detail.model";
import { Router, ActivatedRoute } from '@angular/router';

declare var window:any;
@Component({
  selector: 'app-contact-details-form',
  templateUrl: './contact-details-form.component.html',
  styles: [
  ]
})
export class ContactDetailsFormComponent implements OnInit {
  formModalMail:any;
  formModalPhone: any;
  formModal:any;
  @Output("openSelectedEditModal") openSelectedEditModal: EventEmitter<any> = new EventEmitter();
  
  constructor(public service: ContactDetailService, public emailService: EmailDetailService,public telephoneService: TelephoneDetailService,private _router: Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.formModalMail = new window.bootstrap.Modal(
      document.getElementById("formModalEmail"));
    this.formModalPhone = new window.bootstrap.Modal(
        document.getElementById("formModalTelephone"));
  }

 

  onDelete(formData: ContactDetail){
    if (formData.id == 0) return;
    this.service.deleteContactDetail(formData.id).subscribe(data=>{
      this.service.formData = new ContactDetail();
      this.service.refreshContacts();
      this._router.navigate(['']);
    });
  }

  openAddMailModal(){
    if (this.service.formData.id > 0){
      this.emailService.emailData = new EmailDetail();
      this.emailService.emailData.contactDetailId = this.service.formData.id;
      this.formModalMail.show()
    }
  }

  closeAddMailModal(){
    this.emailService.emailData = new EmailDetail();
    this.formModalMail.toggle();
  }

  onSubmitMail(form: NgForm){
    
    this.emailService.postEmail(this.emailService.emailData).subscribe(data => {
      this.service.refreshContacts();
    });
    this.closeAddMailModal();
  }

  onDeleteMail(data: EmailDetail){
    if (data.id == 0) return;
    this.emailService.deleteEmail(data.id).subscribe(data=>{
      this.emailService.emailData = new EmailDetail();
      this.service.refreshContacts();
    });
  }


  openAddPhoneModal(){
    if (this.service.formData.id > 0){
      this.telephoneService.telephoneData = new TelephoneDetail();
      this.telephoneService.telephoneData.contactDetailId = this.service.formData.id;
      this.formModalPhone.show()
    }
  }

  closeAddPhoneModal(){
    this.telephoneService.telephoneData = new TelephoneDetail();
    this.formModalPhone.toggle();
  }

  onSubmitPhone(form: NgForm){
    
    this.telephoneService.postPhone(this.telephoneService.telephoneData).subscribe(data => {
      this.service.refreshContacts();
    });
    this.closeAddPhoneModal();
  }

  onDeletePhone(data: TelephoneDetail){
    if (data.id == 0) return;
    this.telephoneService.deletePhone(data.id).subscribe(data=>{
      this.telephoneService.telephoneData = new TelephoneDetail();
      this.service.refreshContacts();
    });
  }

  onEditContact(){
    
    this.service.openSelectedEditModal();
  }

}
