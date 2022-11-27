import { Inspection } from 'src/app/models/inspection';
import { InspectionTypesService } from './../../services/inspection-types-service/inspection-types.service';
import { InspectionType } from './../../models/inspection-type';
import { InspectionService } from './../../services/inspection-service/inspection.service';
import { Component, OnInit } from '@angular/core';
import { Observable } from 'rxjs';


@Component({
  selector: 'app-show-inspection',
  templateUrl: './show-inspection.component.html',
  styleUrls: ['./show-inspection.component.css']
})
export class ShowInspectionComponent implements OnInit {

  inspectionList$!: Observable<Inspection[]>;
  inspectionTypesList$!: Observable<InspectionType[]>;
  inspectionTypesList: any = [];

  //Map to display associate with foreign keys
  inspectionTypesMap:Map<number, string> = new Map();

  constructor(private inspectionService: InspectionService, 
    private inspectionTypesService: InspectionTypesService) { }

  //Variables (properties)
  modalTitle: string = '';
  activateAddEditInspectionComponent: boolean = false;
  inspection!: Inspection;

  ngOnInit(): void {
    this.inspectionList$ = this.inspectionService.getAllInspections();
    this.inspectionTypesList$ = this.inspectionTypesService.getAllInspectionTypes();
    this.refreshInspectionTypesList();
  }

  refreshInspectionTypesList(){
    this.inspectionTypesService.getAllInspectionTypes().subscribe(data =>{
      this.inspectionTypesList = data;
        for (let i = 0; i < data.length; i++) {
          this.inspectionTypesMap.set(this.inspectionTypesList[i].id, 
            this.inspectionTypesList[i].inspectionName);
        }
      })
    }

    modalAdd(){
      this.inspection = {
        id: 0,
        status: '',
        comments: '',
        inspectionTypeId: 0
      }
      this.modalTitle = "Add Inspection";
      this.activateAddEditInspectionComponent = true;
    }

    modalEdit(item:Inspection){
      this.inspection = item;
      this.modalTitle = "Edit Inspection";
      this.activateAddEditInspectionComponent = true; 
    }

    delete(item: Inspection){
      if (confirm(`Are you sure you watn to delete inspection ${item.id}?`)) {
        this.inspectionService.deleteInspection(<number>item.id).subscribe(() =>{
          let closeModalBtn = document.getElementById('add-edit-close-modal');
            if(closeModalBtn)
              closeModalBtn.click();
        })

        let showDeleteSuccess = document.getElementById('delete-success-alert');
        if (showDeleteSuccess) {
          showDeleteSuccess.style.display = 'block';
        }

        setTimeout(() =>{
          if (showDeleteSuccess) {
            showDeleteSuccess.style.display = 'none';
          }
        }, 4000);
        this.inspectionList$ = this.inspectionService.getAllInspections();
      }
    }

    modalClose(){
      this.activateAddEditInspectionComponent = false;
      this.inspectionList$ = this.inspectionService.getAllInspections();
    }
}
