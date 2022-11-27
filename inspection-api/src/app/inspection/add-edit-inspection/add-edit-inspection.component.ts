import { StatusService } from './../../services/status-service/status.service';
import { InspectionTypesService } from './../../services/inspection-types-service/inspection-types.service';
import { InspectionService } from './../../services/inspection-service/inspection.service';
import { Component, Input, OnInit } from '@angular/core';
import { Observable } from 'rxjs';
import { Inspection } from 'src/app/models/inspection';
import { Status } from 'src/app/models/status';
import { InspectionType } from 'src/app/models/inspection-type';



@Component({
  selector: 'app-add-edit-inspection',
  templateUrl: './add-edit-inspection.component.html',
  styleUrls: ['./add-edit-inspection.component.css']
})
export class AddEditInspectionComponent implements OnInit {

  inspectionList$!: Observable<Inspection[]>;
  statusList$!: Observable<Status[]>;
  inspectionTypesList$!: Observable<InspectionType[]>;

  constructor(private inspectionService: InspectionService, 
    private inspectionTypesService: InspectionTypesService, 
    private statusService: StatusService) { }

  @Input() inspection!: Inspection;
    id?: number = 0;
    status: string = '';
    comments: string = '';
    inspectionTypeId!: number;

  ngOnInit(): void {
    this.id = this.inspection.id;
    this.status = this.inspection.status;
    this.comments = this.inspection.comments;
    this.inspectionTypeId = this.inspection.inspectionTypeId;
    this.statusList$ = this.statusService.getAllStatuses();
    this.inspectionList$ = this.inspectionService.getAllInspections();
    this.inspectionTypesList$ = this.inspectionTypesService.getAllInspectionTypes();
  }

  addInspection(){
    let inspection:Inspection = {
      status: this.status,
      comments: this.comments,
      inspectionTypeId: this.inspectionTypeId
    }

    this.inspectionService.createInspection(inspection).subscribe(() =>{
      let closeModalBtn = document.getElementById('add-edit-close-modal');
      if(closeModalBtn)
        closeModalBtn.click();
    })

    let showCteateSuccess = document.getElementById('add-success-alert');
    if (showCteateSuccess) {
      showCteateSuccess.style.display = 'block';
    }

    setTimeout(() =>{
      if (showCteateSuccess) {
        showCteateSuccess.style.display = 'none';
      }
    }, 4000);
  }

  updateInspection(){
    let inspection:Inspection = {
      id: this.id,
      status: this.status,
      comments: this.comments,
      inspectionTypeId: this.inspectionTypeId
    }

    this.inspectionService.updateInspection(<number>inspection.id, inspection).subscribe(() =>{
      let closeModalBtn = document.getElementById('add-edit-close-modal');
      if(closeModalBtn)
        closeModalBtn.click();
    })

    let showUpdateSuccess = document.getElementById('update-success-alert');
    if (showUpdateSuccess) {
      showUpdateSuccess.style.display = 'block';
    }

    setTimeout(() =>{
      if (showUpdateSuccess) {
        showUpdateSuccess.style.display = 'none';
      }
    }, 4000);
  }
}
