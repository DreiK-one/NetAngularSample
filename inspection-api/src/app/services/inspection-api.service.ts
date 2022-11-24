import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionApiService {

  readonly inspectionApaUrl: string = "https://localhost:7125/api";

  constructor(private http: HttpClient) { }

  
  //Inspections

  getInspectionList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApaUrl + '/inspections');
  }

  getInspectionById(id: number | string): Observable<any>{
    return this.http.get<any>(this.inspectionApaUrl + `/inspections/${id}`);
  }

  addInspection(data: any){
    return this.http.post(this.inspectionApaUrl + '/inspections', data);
  }

  updateInspection(id: number | string, data: any){
    return this.http.put(this.inspectionApaUrl + `/inspections/${id}`, data);
  }

  deleteInspection(id: number | string){
    return this.http.delete(this.inspectionApaUrl + `/inspections/${id}`);
  }


  //Inspection Types

  getInspectionTypesList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApaUrl + '/inspectionsTypes');
  }

  getInspectionTypeById(id: number | string): Observable<any>{
    return this.http.get<any>(this.inspectionApaUrl + `/inspectionsTypes/${id}`);
  }

  addInspectionTypes(data: any){
    return this.http.post(this.inspectionApaUrl + '/inspectionsTypes', data);
  }

  updateInspectionTypes(id: number | string, data: any){
    return this.http.put(this.inspectionApaUrl + `/inspectionsTypes/${id}`, data);
  }

  deleteInspectionTypes(id: number | string){
    return this.http.delete(this.inspectionApaUrl + `/inspectionsTypes/${id}`);
  }


  //Statuses

  getStatusList(): Observable<any[]>{
    return this.http.get<any>(this.inspectionApaUrl + '/status');
  }

  getStatusById(id: number | string): Observable<any>{
    return this.http.get<any>(this.inspectionApaUrl + `/status/${id}`);
  }

  addStatus(data: any){
    return this.http.post(this.inspectionApaUrl + '/status', data);
  }

  updateStatus(id: number | string, data: any){
    return this.http.put(this.inspectionApaUrl + `/status/${id}`, data);
  }

  deleteStatus(id: number | string){
    return this.http.delete(this.inspectionApaUrl + `/status/${id}`);
  }
}
