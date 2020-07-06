using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace app_wpf_blackjack {
    
    class CardEngine {

        private StackPanel userCards;
        private StackPanel dealerCards;

        public CardEngine(StackPanel userCards, StackPanel dealerCards) { 
            this.userCards = userCards;
            this.dealerCards = dealerCards;
        }

    }
}
