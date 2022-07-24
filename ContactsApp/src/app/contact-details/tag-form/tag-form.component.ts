import { Component, OnInit } from '@angular/core';
import { Tag } from 'src/app/shared/tag.model';
import { TagService } from 'src/app/shared/tag.service';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-tag-form',
  templateUrl: './tag-form.component.html',
  styles: [
  ]
})
export class TagFormComponent implements OnInit {

  constructor(public tagService: TagService) { }

  ngOnInit(): void {
  }

  onDelete(tagSelected: Tag){
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
