import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InspectionService {

  constructor(private service: ApiService) { }
}
