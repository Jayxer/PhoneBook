import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
@Injectable({
  providedIn: 'root'
})

export class ServiceService {

  constructor(private http: HttpClient) { }
  httpOptions = {
    headers: new HttpHeaders({
      'Content-Type': 'application/json'
    })
  }

  getData() {
    return this.http.get('/api/Entries'); 
  }

  postData(formData) {
    return this.http.post('/api/Entries', formData);
  }

  putData(entryId, formData) {
    return this.http.put('/api/Entries/' + entryId, formData);
  }

  deleteData(entryId) {
    return this.http.delete('/api/Entries/' + entryId);
  }

  searchEntries(searchName) {
    let params = new HttpParams().set("searchName", searchName);
    return this.http.get('/api/Entries/searchEntries', { params: params });
  }

}  
