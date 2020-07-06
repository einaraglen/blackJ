using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace blackJ {
    class HandManager {

        private List<int> userHand = new List<int>();
        private List<int> splitHand = new List<int>();
        private List<int> dealerHand = new List<int>();
        
        private CardManager cardManager;
        private Card[] stack;

        private bool isSplit;
        private bool max;

        public HandManager() {
            this.cardManager = new CardManager();
            this.isSplit = false;
            this.max = false;
            this.stack = createStack();
        }

        public void clear() {
            this.userHand.Clear();
            this.splitHand.Clear();
            this.dealerHand.Clear();

            this.cardManager.clear();

            this.isSplit = false;
            this.max = false;
        }

        public Card[] createStack() {
            List<Card> currentStack = new List<Card>();

            for (int i = 0; i < 4; i++) {

                for (int j = 1; j < 14; j++) {
                    currentStack.Add(new Card(i, j));
                }

            }

            return currentStack.ToArray();
        }

        public void drawUser(bool split) {
            if(!split) {
                this.userHand.Add(this.cardManager.drawCard());
            } 
            
            else {

                if(this.isSplit) {
                    this.userHand.Add(this.cardManager.drawCard());
                    this.splitHand.Add(this.cardManager.drawCard());
                }

                else {
                    int first = this.userHand[0];

                    this.splitHand.Add(first);
                    this.userHand.Remove(first);

                    this.isSplit = true;
                }

            }
        }

        public void drawDealer() {
            this.dealerHand.Add(this.cardManager.drawCard());
        }

        public Card getCard(int index) {
            return this.stack[index];
        }

        public bool userIsAbove() {
            return (getUserTotal() > 21);
        }

        public bool userBest() {
            return (getUserTotal() == 21);
        }

        public bool isSplittable() {
            if(this.isSplit) {
                return true;
            }

            else {
                Card first = getCard(this.userHand[0]);
                Card secound = getCard(this.userHand[1]);

                return (first.getNumber() == secound.getNumber());
            }
        }

        public bool hasAce() {
            bool found = false;
            
            foreach(int i in this.userHand) {
                
                if(getCard(i).getNumber() == 1) {
                    found = true;
                }

            }

            return found;
        }

        public String getResults() {

            int user = getUserTotal();
            int split = getSplitTotal();
            int dealer = getDealerTotal();

            int best = 0;

            if (user > split || split > 21) {
                best = user;
            } 
            
            else {
                best = split;
            }

            String winner = null;

            if (best == dealer) {
                winner = "draw";
            }

            if (best > dealer) {
                winner = "user";
            }

            if (dealer > 21) {
                winner = "user";
            }

            if (dealer > best) {
                winner = "dealer";
            }

            if (dealer> 21) {
                winner = "user";
            }

            if (best > 21) {
                winner = "dealer";
            }

            return winner;
        }

        public void setMax(bool max) {
            this.max = max;
        }

        public int getUserTotal() {
            return totalOf(this.userHand, false);
        }

        public int getSplitTotal() {
            return totalOf(this.splitHand, false);
        }

        public int getDealerTotal() {
            return totalOf(this.dealerHand, true);
        }

        private int totalOf(List<int> hand, bool isDealer) {
            int total = 0;

            foreach(int i in hand) {
                
                if(!isDealer && this.max && getCard(i).getNumber() == 1) {
                    total += 11;
                }

                else if(getCard(i).getNumber() > 10) {
                    total += 10;
                }

                else {
                    total += getCard(i).getNumber();
                }
            }

            return total;
        }
    }
}
