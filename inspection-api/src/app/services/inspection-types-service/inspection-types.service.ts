import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';
import { InspectionType } from 'src/app/models/inspection-type'
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class InspectionTypesService {

  inspectionTypeUrl: string = 'inspectionType'

  constructor(private service: ApiService) { }

  getAllInspectionTypes(): Observable<InspectionType[]>{
    return this.service.get(this.inspectionTypeUrl)
  }

  createInspectionType(data: InspectionType){
    return this.service.post(this.inspectionTypeUrl, data)
  }

  updateInspectionType(id: string, data: InspectionType){
    return this.service.put(this.inspectionTypeUrl, id, data)
  }

  deleteInspectionType(id: string){
    return this.service.delete(this.inspectionTypeUrl, id)
  }
}
