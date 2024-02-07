import {Component, Inject} from '@angular/core';
import {StickyNote} from "../StickyNote";
import {QueryService} from "../query.service";
import {MAT_DIALOG_DATA, MatDialogRef} from "@angular/material/dialog";
import {FormControl, FormGroup} from "@angular/forms";

@Component({
  selector: 'app-editdialog',
  templateUrl: './editdialog.component.html',
  styleUrl: './editdialog.component.css'
})
export class EditdialogComponent {
  editForm: FormGroup = new FormGroup({
    title: new FormControl(''),
    description: new FormControl('')
  })

constructor(private queryManager: QueryService, public dialogRef: MatDialogRef<EditdialogComponent>,
            @Inject(MAT_DIALOG_DATA) public modifyNote: StickyNote) {
this.editForm.get("title")?.setValue(modifyNote.title);
this.editForm.get("description")?.setValue(modifyNote.description);
}
  submitForm() {
    if (this.editForm.valid) {
      const formData = this.editForm.value;
      const note : StickyNote = {
        title: formData.title,
        description: formData.description,
        id: this.modifyNote.id,
        lastModifiedDate:""
      }

      this.queryManager.Update(note)
      this.dialogRef.close();
      this.editForm.reset();
    } else {
      console.log('Form is invalid');
    }
  }
}
