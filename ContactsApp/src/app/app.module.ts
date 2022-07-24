import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from "@angular/forms";
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';


import { AppComponent } from './app.component';
import { ContactComponent } from './contact-details/contact.component';
import { ContactFormComponent } from './contact-details/contact-details-form/contact-form.component';
import { ChooseContactComponent } from './contact-details/choose-contact/choose-contact.component';
import { TagFormComponent } from './contact-details/tag-form/tag-form.component';


@NgModule({
  declarations: [
    AppComponent,
    ContactComponent,
    ContactFormComponent,
    ChooseContactComponent,
    TagFormComponent
  ],
  imports: [
    BrowserModule,
    FormsModule,
    HttpClientModule,
    RouterModule.forRoot([
      {path: 'contact', component: ContactFormComponent},
      {path: '', component: ChooseContactComponent}
    ])
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
