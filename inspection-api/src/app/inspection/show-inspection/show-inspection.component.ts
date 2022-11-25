import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { ApiService } from 'src/app/services/api.service';

@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})
export class ShowInspectionComponent implements OnInit {

  inspectionList$!: Observable<any[]>;
  inspectionTypesList$!: Observable<any[]>;
  inspectionTypeList: any = [];

  //Map to display associate with foreign keys
  inspectionTypesMap:Map<number, string> = new Map();

  constructor(private service: ApiService) { }

  ngOnInit(): void {
    this.inspectionList$ = this.service.getInspectionList();
  }

}
