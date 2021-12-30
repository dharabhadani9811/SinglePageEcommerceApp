import { Component, OnInit, AfterViewInit } from '@angular/core';
import { Router } from '@angular/router';
declare var $: any;

@Component({
  selector: 'app-master',
  templateUrl: './master.component.html',
  styleUrls: ['./master.component.css']
})
export class MasterComponent implements OnInit {

  constructor(private router:Router) { }
  

  ngOnInit(): void {
    $('[data-widget="treeview"]').Treeview('init');
  }

  logout():void{
    sessionStorage.removeItem("username");
    sessionStorage.clear();
    this.router.navigate(['login']);
  }

}
