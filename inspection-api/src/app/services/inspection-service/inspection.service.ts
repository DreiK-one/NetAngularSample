import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';
import { Inspection } from 'src/app/models/inspection'
import { Observable } from 'rxjs';


@Injectable({
  providedIn: 'root'
})
export class InspectionService {

  inspectionUrl: string = 'inspection'

  constructor(private service: ApiService) { }

  getAllInspections(): Observable<Inspection[]>{
    return this.service.get(this.inspectionUrl)
  }

  createInspection(data: Inspection){
    return this.service.post(this.inspectionUrl, data)
  }

  updateInspection(id: string, data: Inspection){
    return this.service.put(this.inspectionUrl, id, data)
  }

  deleteInspection(id: string){
    return this.service.delete(this.inspectionUrl, id)
  }
}
