import { Component } from '@angular/core';
import { FAQ } from './faq';

@Component({
  selector: 'app-faq',
  templateUrl: './faq.component.html',
  styleUrls: ['./faq.component.scss']
})
export class FAQComponent {
 
  faqs: FAQ[] 
  showFaqs :boolean[]

  constructor() {
    this.showFaqs = Array.from({length: 4}, () => false);
    const faq1 = new FAQ(1,"What is Clash Royale Clan Wars?", "It's just a game");
    const faq2 = new FAQ(2,"How do I play Clash Royale Clan Wars?", "You just play");
    const faq3 = new FAQ(3,"How do I win Clash Royale Clan Wars?", "You just win");
    const faq4 = new FAQ(4,"How do I lose Clash Royale Clan Wars?", "You just lose");

    this.faqs = [];
   
    
      this.faqs.push(faq1);
      this.faqs.push(faq2);
      this.faqs.push(faq3);
      this.faqs.push(faq4);
    

   
   }

   ShowAnswer(faq: FAQ) {
    this.showFaqs[(faq.id) - 1] = !this.showFaqs[(faq.id) - 1];
    console.log(true);
   }

}


