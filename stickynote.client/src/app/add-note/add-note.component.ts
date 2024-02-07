import {Component, Inject, Input, input, OnInit} from '@angular/core';
import {QueryService} from "../query.service";
import {StickyNote} from "../StickyNote";

@Component({
  selector: 'app-add-note',
  templateUrl: './add-note.component.html',
  styleUrls: ['./add-note.component.css']
})
export class AddNoteComponent implements OnInit {

  showDesc: boolean = false;
  descriptionState: string = 'hidden';
  titleplaceHolder: string ="Take note.."
  constructor(private queryManager: QueryService) {

  }


  ngOnInit(): void {
  }

  submitForm(form: any) {
    if (form.valid) {
      const formData = form.value;
     const note : StickyNote = {
        title: formData.title,
        description: formData.description,
        id:"",
       lastModifiedDate:""
      }
      this.queryManager.Create(note)
      form.resetForm();
     this.showDesc = false
    } else {
      console.log('Form is invalid');
    }
  }

  showDescription(event: any) {

    if (event.target.value.trim() == '') {
      this.showDesc = true;
      this.descriptionState = 'visible';
      this.titleplaceHolder = "Title"
    }
  }
}
