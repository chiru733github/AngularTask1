import { Component, OnInit } from '@angular/core';
import { BillService } from '../../Services/Bill/bill.service';

@Component({
  selector: 'app-hospital-bill',
  templateUrl: './hospital-bill.component.html',
  styleUrl: './hospital-bill.component.scss'
})
export class HospitalBillComponent implements OnInit{
  patientDetails={
    bill_No:0,
    bill_Date:'',
    patient_Name:'',
    gender:'',
    dob:'',
    address:'',
    email_Id:'',
    mobile_No:''
  };
  Patients: boolean = false;
  PatientsList : any;
  selectedBillNo: any;
  constructor(private Bill:BillService){}
  ngOnInit(): void {  
  }
  AddOrEditButton(){
    console.log('Hello');
    let data ={
      bill_No:this.patientDetails.bill_No,
      bill_Date:this.patientDetails.bill_Date,
      patient_Name:this.patientDetails.patient_Name,
      gender:this.patientDetails.gender,
      dob:this.patientDetails.dob,
      address:this.patientDetails.address,
      email_Id:this.patientDetails.email_Id,
      mobile_No:this.patientDetails.mobile_No
    }
    this.Bill.AddPatient(data).subscribe((response:any)=>{
      console.log(response);
    })
  }

  Edit(){
    console.log("Edit method")
    this.Bill.GetAllPatient().subscribe((response: any) => {
      console.log(response);
      this.Patients =true;
      this.PatientsList = response.data;
    })
  }
  GetById(bill_No:any){
    console.log("hello");
    console.log(bill_No);
    console.log(this.PatientsList);

    this.Bill.GetById(bill_No).subscribe((response:any)=>{
      this.patientDetails = response.data;
      if (this.patientDetails.bill_Date && this.patientDetails.dob) {
        this.patientDetails.bill_Date = new Date(this.patientDetails.bill_Date).toISOString().split('T')[0];
        this.patientDetails.dob = new Date(this.patientDetails.dob).toISOString().split('T')[0];
      }
    })
    console.log(this.patientDetails);
  }




}
