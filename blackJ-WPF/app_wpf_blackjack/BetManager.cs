using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Text;
using System.Windows.Controls;
using System.Xml.Serialization;

namespace app_wpf_blackjack {

    class BetManager {

        private Label betText;
        private Label scoreText;

        private Button top;
        private Button mid;
        private Button bot;

        private int bet;
        private int score;

        private readonly String relativePath = Path.Combine(".", "resources", "score.xml");


        public BetManager(Label betText, Label scoreText, Button top, Button mid, Button bot) {
            this.betText = betText;
            this.scoreText = scoreText;

            this.top = top;
            this.mid = mid;
            this.bot = bot;

            this.bet = 0;
            this.score = 0;

            readXML();
        }

        public void resetScore() {
            this.score = 1000;
            this.scoreText.Content = 1000;

            writeXML(this.score);
        }

        private void readXML() {

            XmlSerializer deserializer = new XmlSerializer(typeof(int));

            TextReader reader = new StreamReader(@"" + this.relativePath);
            object obj = deserializer.Deserialize(reader);

            this.score = (int)obj;

            reader.Close();

        }

        private void writeXML(int score) {
            //writes score to xml when updated
            XmlSerializer serializer = new XmlSerializer(typeof(int));

            using (TextWriter tw = new StreamWriter(@"" + this.relativePath)) {
                serializer.Serialize(tw, score);
            }
        }

        public void setScore(int score) {
            this.score = score;
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

            writeXML(this.score);

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
