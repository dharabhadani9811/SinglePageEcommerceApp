import { Component, OnInit } from '@angular/core';
import { Department } from 'src/model/department.model';
import { DepartmentService } from '../department/department.service';
import { EmployeeService } from './employee.service';
import { ToastrService } from 'ngx-toastr';
import { NgxSpinnerService } from 'ngx-spinner';
import { Employee } from 'src/model/employee';
import { Message } from 'src/model/message.model';

@Component({
  selector: 'app-compose-message',
  templateUrl: './compose-message.component.html',
  styleUrls: ['./compose-message.component.css']
})
export class ComposeMessageComponent implements OnInit {

  departments:Department[];
  employees:Employee[];
  emp_id:number;
  message:Message;

  constructor(private deptService:DepartmentService,private empService:EmployeeService,
    private toastr:ToastrService,private spinner:NgxSpinnerService) { }

  ngOnInit(): void {
    this.message=new Message();
   this.loadDepartment();
  }

  onDepartmentSelected(dept_id:string):void{
    if(Number(dept_id) > 0){
      //console.log("Department"+dept_id);
      this.spinner.show();
      this.empService.getEmployeeByDept(Number(dept_id)).subscribe((data)=>{
        this.employees = data as Employee[],
        this.spinner.hide();
      },(err)=>{
        this.toastr.error(err,'Alert'),
        this.spinner.hide();
      });
    }
  }

  onEmployeeSelected(emp_id:string):void{
    if(Number(emp_id) > 0){
      console.log(emp_id);
      this.emp_id = Number(emp_id);
    }
  }

  createMsg(){
    this.spinner.show();
    this.message.emp_id = this.emp_id;
    this.empService.addMessage(this.message).subscribe((data)=>{
      this.toastr.success(data,'Alert'),
      this.spinner.hide();
    },(err)=>{
      this.toastr.error(err,'Alert'),
      this.spinner.hide();
    });
  }

  loadDepartment():void{
    this.spinner.show();
    this.deptService.getDepartment().subscribe((data)=>{
      this.departments = data as Department[],
      this.spinner.hide();
    },(err)=>{
      this.toastr.error(err,'Alert'),
      this.spinner.hide();
    });
  }

}
