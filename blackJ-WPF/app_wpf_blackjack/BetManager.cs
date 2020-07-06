using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace app_wpf_blackjack {

    class BetManager {

        private Label betText;
        private Label scoreText;

        private Button top;
        private Button mid;
        private Button bot;

        private int bet;
        private int score;


        public BetManager(Label betText, Label scoreText, Button top, Button mid, Button bot) {
            this.betText = betText;
            this.scoreText = scoreText;

            this.top = top;
            this.mid = mid;
            this.bot = bot;

            this.bet = 0;
            this.score = 1000;
        }

        public bool gameOver() {
            return (score == 0) ;
        }

        public bool incrementBet(int increment) {

            if((this.score - (this.bet + increment)) < 0) {
                return false;
            }

            else {
                this.bet += increment;
                this.betText.Content = bet.ToString();
                return true;
            }

        }

        public void reset(String winner) {

            if (winner.Equals("user")) {
                this.score += this.bet;
            }

            else if(winner.Equals("dealer")) {
                this.score -= this.bet;
            }

            this.scoreText.Content = score.ToString();
            this.bet = 0;
        }

        public void enableBetButtons(bool enable) {
            this.top.IsEnabled = enable;
            this.mid.IsEnabled = enable;
            this.bot.IsEnabled = enable;
        }

    }
}
