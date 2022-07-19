import { Component, OnInit } from '@angular/core';
import { TagDetail } from 'src/app/shared/tag-detail.model';
import { TagDetailService } from 'src/app/shared/tag-detail.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-tag-form',
  templateUrl: './tag-form.component.html',
  styles: [
  ]
})
export class TagFormComponent implements OnInit {

  constructor(public tagService: TagDetailService) { }

  ngOnInit(): void {
  }

  onDelete(tagSelected: TagDetail){
    this.tagService.deleteTag(tagSelected.id).subscribe(data => {
      this.tagService.refreshTags();
    })
  }

  closeAddTagModal(){
    this.tagService.closeAddTagModal();
  }

  openAddTagModal(){
    this.tagService.openAddTagModal();
  }

  onSubmitAddTag(form: NgForm){
    this.tagService.postTag(this.tagService.tagModel).subscribe(data=>{
      this.tagService.refreshTags();
      this.closeAddTagModal();
    })
  }


}
