import { Observable } from 'rxjs';
import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';
import { Status } from 'src/app/models/status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  statusUrl: string = 'status'

  constructor(private service: ApiService) { }

  getAllStatuses(): Observable<Status[]>{
    return this.service.get(this.statusUrl)
  }

  createStatus(data: Status){
    return this.service.post(this.statusUrl, data)
  }

  updateStatus(id: string, data: Status){
    return this.service.put(this.statusUrl, id, data)
  }

  deleteStatus(id: string){
    return this.service.delete(this.statusUrl, id)
  }
}
