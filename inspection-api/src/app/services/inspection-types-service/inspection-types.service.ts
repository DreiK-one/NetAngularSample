import { ApiService } from 'src/app/services/api.service';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class InspectionTypesService {

  constructor(private service: ApiService) { }
}
