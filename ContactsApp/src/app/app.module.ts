import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { ContactDetailsComponent } from './contact-details/contact-details.component';
import { ContactDetailsFormComponent } from './contact-details/contact-details-form/contact-details-form.component';
import { ChooseContactComponent } from './contact-details/choose-contact/choose-contact.component';
import { TagFormComponent } from './contact-details/tag-form/tag-form.component';


@NgModule({
  declarations: [
    AppComponent,
    ContactDetailsComponent,
    ContactDetailsFormComponent,
    ChooseContactComponent,
    TagFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'contact', component: ContactDetailsFormComponent},
      {path: '', component: ChooseContactComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
