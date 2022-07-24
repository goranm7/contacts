import { Component, EventEmitter,  OnInit, Output } from "@angular/core";
import { Contact } from 'src/app/shared/contact.model';
import { ContactService } from 'src/app/shared/contact.service';
import { NgForm } from '@angular/forms';
import { EmailService } from 'src/app/shared/email.service';
import { Email } from 'src/app/shared/email.model';
import { TelephoneService } from "src/app/shared/telephone.service";
import { Telephone } from "src/app/shared/telephone.model";
import { Router, ActivatedRoute } from '@angular/router';

declare var window:any;
@Component({
  selector: 'app-contact-details-form',
  templateUrl: './contact-form.component.html',
  styles: [
  ]
})
export class ContactFormComponent implements OnInit {
  formModalMail:any;
  formModalPhone: any;
  formModal:any;
  @Output("openSelectedEditModal") openSelectedEditModal: EventEmitter<any> = new EventEmitter();
  
  constructor(public service: ContactService, public emailService: EmailService,public telephoneService: TelephoneService,private _router: Router,private route:ActivatedRoute) { }

  ngOnInit(): void {
    this.formModalMail = new window.bootstrap.Modal(
      document.getElementById("formModalEmail"));
    this.formModalPhone = new window.bootstrap.Modal(
        document.getElementById("formModalTelephone"));
  }

 

  onDelete(formData: Contact){
    if (formData.id == 0) return;
    this.service.deleteContact(formData.id).subscribe(data=>{
      this.service.formData = new Contact();
      this.service.refreshContacts();
      this._router.navigate(['']);
    });
  }

  openAddMailModal(){
    if (this.service.formData.id > 0){
      this.emailService.emailData = new Email();
      this.emailService.emailData.contactId = this.service.formData.id;
      this.formModalMail.show()
    }
  }

  closeAddMailModal(){
    this.emailService.emailData = new Email();
    this.formModalMail.toggle();
  }

  onSubmitMail(form: NgForm){
    
    this.emailService.postEmail(this.emailService.emailData).subscribe(data => {
      this.service.refreshContacts();
    });
    this.closeAddMailModal();
  }

  onDeleteMail(data: Email){
    if (data.id == 0) return;
    this.emailService.deleteEmail(data.id).subscribe(data=>{
      this.emailService.emailData = new Email();
      this.service.refreshContacts();
    });
  }


  openAddPhoneModal(){
    if (this.service.formData.id > 0){
      this.telephoneService.telephoneData = new Telephone();
      this.telephoneService.telephoneData.contactId = this.service.formData.id;
      this.formModalPhone.show()
    }
  }

  closeAddPhoneModal(){
    this.telephoneService.telephoneData = new Telephone();
    this.formModalPhone.toggle();
  }

  onSubmitPhone(form: NgForm){
    
    this.telephoneService.postPhone(this.telephoneService.telephoneData).subscribe(data => {
      this.service.refreshContacts();
    });
    this.closeAddPhoneModal();
  }

  onDeletePhone(data: Telephone){
    if (data.id == 0) return;
    this.telephoneService.deletePhone(data.id).subscribe(data=>{
      this.telephoneService.telephoneData = new Telephone();
      this.service.refreshContacts();
    });
  }

  onEditContact(){
    
    this.service.openSelectedEditModal();
  }

}
