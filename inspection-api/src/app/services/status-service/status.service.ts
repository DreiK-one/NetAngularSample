import { Observable } from 'rxjs';
import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';
import { Status } from 'src/app/models/status';

@Injectable({
  providedIn: 'root'
})
export class StatusService {

  statusUrl: string = 'status'

  private constructor(private apiService: ApiService) { }

  getAllStatuses(): Observable<Status[]>{
    return this.apiService.get(this.statusUrl)
  }

  createStatus(data: Status){
    return this.apiService.post(this.statusUrl, data)
  }

  updateStatus(id: string, data: Status){
    return this.apiService.put(this.statusUrl, id, data)
  }

  deleteStatus(id: string){
    return this.apiService.delete(this.statusUrl, id)
  }
}
