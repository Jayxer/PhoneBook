import { Component } from '@angular/core';
import { ServiceService } from './service.service';
import { FormGroup, FormControl, Validators } from '@angular/forms';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html'
})  

export class AppComponent {
  title = 'PhoneBook';

  constructor(private ServiceService: ServiceService) { }
  data: any;
  EntriesForm: FormGroup;
  submitted = false;
  EventValue: any = "Save";

  ngOnInit(): void {
    this.getdata();

    this.EntriesForm = new FormGroup({
      entryId: new FormControl(null),
      name: new FormControl("", [Validators.required]),
      phoneNumber: new FormControl("", [Validators.required]),
      searchName: new FormControl("")
    })
  }

  getdata() {
    this.ServiceService.getData().subscribe((data: any[]) => {
      this.data = data;
    })
  }

  deleteData(entryId) {
    this.ServiceService.deleteData(entryId).subscribe((data: any[]) => {
      this.data = data;
      this.getdata();
    })
  }

  editData(Data) {
    this.EntriesForm.controls["entryId"].setValue(Data.entryId);
    this.EntriesForm.controls["name"].setValue(Data.name);
    this.EntriesForm.controls["phoneNumber"].setValue(Data.phoneNumber);
    this.EventValue = "Update";
  }

  resetFrom() {
    this.getdata();
    this.EntriesForm.reset();
    this.EventValue = "Save";
    this.submitted = false;
  }

  search() {
    this.ServiceService.searchEntries(this.EntriesForm.controls["searchName"].value).subscribe((data: any[]) => {
        this.data = data;
    })
  }

  Save() {
    this.submitted = true;

    if (this.EntriesForm.invalid) {
      return;
    }

    this.ServiceService.postData(this.EntriesForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();
    })
  }

  Update() {
    this.submitted = true;

    if (this.EntriesForm.invalid) {
      return;
    }

    this.ServiceService.putData(this.EntriesForm.value.entryId, this.EntriesForm.value).subscribe((data: any[]) => {
      this.data = data;
      this.resetFrom();
    })
  }
}
