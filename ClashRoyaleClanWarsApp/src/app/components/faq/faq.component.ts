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
    const faq1 = new FAQ(1,"What is Clash Royale Clan Wars?", "Clash Royale Clan Wars is a feature in the mobile game Clash Royale that allows players to compete against each other in teams. Clans are groups of players who can chat, share cards, and participate in wars together.In a Clan War, two clans are matched against each other and each player in the clan must participate in a series of battles. The goal is to earn as many stars as possible by winning battles. The clan that earns the most stars at the end of the war wins and receives a prize. Clan Wars can be a lot of fun and a great way to compete with other players. They can also be a good way to earn rewards, such as cards and gold.");
    const faq2 = new FAQ(2,"How do I play Clash Royale Clan Wars?", "To participate in a Clan War, tap the Clan Wars button in your profile to turn it green. This indicates to the Clan Leader and Co-Leaders that you are available for Wars. However, the Leader who initiates the war has to choose you into the war before you can participate, whether your button is green or red.");
    const faq3 = new FAQ(3,"How do I win Clash Royale Clan Wars?", "Your clan can win by accumulating the most points.");
    const faq4 = new FAQ(4,"How do I lose Clash Royale Clan Wars?", "A clan loses when it does not have enough points to win");

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


