import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';
import { InspectionType } from 'src/app/models/inspection-type'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionTypesService {

  private inspectionTypeUrl: string = 'inspectionTypes'

  constructor(private apiService: ApiService) { }

  getAllInspectionTypes(): Observable<InspectionType[]>{
    return this.apiService.get(this.inspectionTypeUrl)
  }

  createInspectionType(data: InspectionType){
    return this.apiService.post(this.inspectionTypeUrl, data)
  }

  updateInspectionType(id: string, data: InspectionType){
    return this.apiService.put(this.inspectionTypeUrl, id, data)
  }

  deleteInspectionType(id: string){
    return this.apiService.delete(this.inspectionTypeUrl, id)
  }
}
