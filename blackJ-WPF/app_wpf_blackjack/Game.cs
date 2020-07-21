using app_wpf_blackjack;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security.Cryptography;
using System.Text;
using System.Windows.Controls;
using System.Xml;

namespace blackJ {

    class Game {

        private HandManager handManager;
        private ElementManager elmManager;
        private BetManager betManager;
        private CardEngine cardEngine;
        private ResizingHandler resizer;

        private bool roundIsOver;
        private bool start;
        private bool issplit;

        public Game(ElementManager elmManager, BetManager betManager, CardEngine cardEngine, ResizingHandler resizer) {

            this.handManager = new HandManager();
            this.betManager = betManager;
            this.elmManager = elmManager;
            this.cardEngine = cardEngine;
            this.resizer = resizer;

            this.roundIsOver = false;
            this.issplit = false;
            this.start = true;

            //Kinda starts the program u know?
            reset();

        }

        public void draw() {

            if (this.betManager.gameOver()) {
                this.elmManager.updateStatus("game over");
            } 
            
            else {

                if (!this.roundIsOver) {

                    this.elmManager.updateStatus("user draws");

                    if (this.start) {
                        firstRound();
                    } 
                    
                    else { 
                        this.elmManager.maxVisable(false);
                        this.handManager.drawUser(this.issplit);
                    }

                } 
                
                else {
                    reset();
                }

                if (this.handManager.userIsAbove() || this.handManager.userBest()) {
                    hold();
                }

                update();

            }

        }

        public void resize(double window) {
            //cast to int for easier manipulation
            this.resizer.resize((int)window);
        }

        public void setMax(bool enable) {
            this.handManager.setMax(enable);

            this.elmManager.enableDraw(true);
            this.elmManager.enableHold(true);

            this.elmManager.maxVisable(false);

            if (this.handManager.userIsAbove() || this.handManager.userBest()) {
                hold();
            }

            update();
        }

        private void update() {

            if (this.issplit) {

                int user = this.handManager.getUserTotal();
                int split = this.handManager.getSplitTotal();

                this.cardEngine.updateUserCards(this.handManager.getUserHand());
                this.cardEngine.updateSplitCards(this.handManager.getSplitHand());

                this.elmManager.setUserTotal(user.ToString() + " | " + split.ToString());

            }
            
            else {

                this.elmManager.setUserTotal(this.handManager.getUserTotal().ToString());
                this.cardEngine.updateUserCards(this.handManager.getUserHand());

            }

            this.elmManager.setDealerTotal(this.handManager.getDealerTotal().ToString());
        }

        private void updateDealer(bool first) {

            if (first) {
                this.cardEngine.updateDealerCards(this.handManager.getDealerHand());
                this.cardEngine.addBackside();
            } 
            
            else {
                this.cardEngine.updateDealerCards(this.handManager.getDealerHand());
            }

        }


        private void reset() {
            this.elmManager.drawContent("Start");
            this.elmManager.enableHold(false);
            this.elmManager.enableSplit(false);

            this.roundIsOver = false;
            this.issplit = false;
            this.resizer.setIsSplit(this.issplit);
            this.start = true;

            this.betManager.reset(this.handManager.getResults());

            this.betManager.enableBetButtons(true);

            this.handManager.clear();

            this.betManager.incrementBet(25);

            this.elmManager.updateStatus("start");

            updateDealer(false);
        }

        public void hold() {
            while (this.handManager.getDealerTotal() <= 16) {
                this.handManager.drawDealer();
            }

            updateDealer(false);
            update();

            this.roundIsOver = true;

            if (this.handManager.getResults().Equals("draw")) {
                this.elmManager.updateStatus(this.handManager.getResults());
            } 
            
            else {
                this.elmManager.updateStatus(this.handManager.getResults() + " wins");
            }

            this.elmManager.enableHold(false);
            this.elmManager.enableSplit(false);
            this.elmManager.enableDraw(true);
            this.elmManager.drawContent("Next");

        }

        public void split() {
            this.elmManager.enableDraw(true);
            this.elmManager.enableHold(true);
            this.elmManager.enableSplit(false);

            this.issplit = true;
            this.resizer.setIsSplit(this.issplit);

            //does to splitting
            this.handManager.drawUser(this.issplit);

            update();

        }

        public void IncrementBet(int bet) {

            bool betConfirmed = this.betManager.incrementBet(bet);

            if (!betConfirmed) {
                this.elmManager.updateStatus("score not high enough");
            } 
            
            else {
                this.elmManager.updateStatus("bet +" + bet.ToString());
            }

        }

        private void firstRound() {

            this.elmManager.updateStatus("round started");

            for (int i = 0; i < 3; i++) {

                if (i < 2) {
                    this.handManager.drawUser(this.issplit);
                } 
                
                else {
                    this.handManager.drawDealer();
                }

            }

            if (handManager.isSplittable()) {
                this.elmManager.updateStatus("split available");

                this.elmManager.enableSplit(true);
                //this.elmManager.enableDraw(false);
                this.elmManager.enableHold(true);
            } 
            
            else if (handManager.hasAce()) {
                this.elmManager.updateStatus("ace available");

                this.elmManager.setMaxContent(this.handManager.getUserMax(), this.handManager.getUserTotal());

                this.elmManager.maxVisable(true);
                this.elmManager.enableDraw(false);
                this.elmManager.enableHold(false);
            } 
            
            else {
                this.elmManager.enableHold(true);
            }
            
            this.betManager.enableBetButtons(false);
            this.elmManager.drawContent("Draw");
            this.start = false;

            updateDealer(true);

        }
    }
}
