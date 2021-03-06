import { Component, OnInit } from '@angular/core';
import { TenderServiceService } from 'src/app/tender-service.service';
import { Offer } from '../../models/Offer';

@Component({
  selector: 'app-active-tender',
  templateUrl: './active-tender.component.html',
  styleUrls: ['./active-tender.component.css']
})
export class ActiveTenderComponent implements OnInit {

  constructor(private tenderService:TenderServiceService) { }

  id:number;
  medicamentId:number;
  price:number;
  quantity:number;
  comment:string;

  ModalTitle:string;
  ActivateAddEditClose:boolean=false;
  clo:Offer;

  OfferList: Offer[];

  ngOnInit(): void {
    this.refreshOfferList();
  }

  refreshOfferList(){
    this.tenderService.getOfferListActive().subscribe((data: Offer[]) => {
      console.log(data);
      this.OfferList = data;
    })
  }

  choose(id:number){
    this.tenderService.chooseTender(id).subscribe(data=>{
      console.log(data)
    })
    alert("Successfully choosen!")
  }
}
