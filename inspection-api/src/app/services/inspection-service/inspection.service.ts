import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';
import { Inspection } from 'src/app/models/inspection'
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class InspectionService {

  private inspectionUrl: string = 'inspections'

  constructor(private apiService: ApiService) { }

  getAllInspections(): Observable<Inspection[]>{
    return this.apiService.get(this.inspectionUrl)
  }

  createInspection(data: Inspection){
    return this.apiService.post(this.inspectionUrl, data)
  }

  updateInspection(id: string, data: Inspection){
    return this.apiService.put(this.inspectionUrl, id, data)
  }

  deleteInspection(id: string){
    return this.apiService.delete(this.inspectionUrl, id)
  }
}
