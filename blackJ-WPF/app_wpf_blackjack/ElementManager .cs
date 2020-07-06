using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Controls;

namespace app_wpf_blackjack {
    class ElementManager {

        private Button drawButton;
        private Button holdButton;
        private Button splitButton;

        private Label userTotal;
        private Label dealerTotal;
        private Label updateText;

        public ElementManager(Button drawButton, 
            Button holdButton, 
            Button splitButton, 
            Label userTotal, 
            Label dealerTotal,
            Label updateText) {

            this.drawButton = drawButton;
            this.holdButton = holdButton;
            this.splitButton = splitButton;

            this.userTotal = userTotal;
            this.dealerTotal = dealerTotal;
            this.updateText = updateText;
 
        }

        //Content setters
        public void drawContent(String content) {
            this.drawButton.Content = content;
        }

        public void updateStatus(String update) {
            this.updateText.Content = update;
        }


        //Enable setters
        public void enableDraw(bool enable) {
            this.drawButton.IsEnabled = enable;
        }

        public void enableHold(bool enable) {
            this.holdButton.IsEnabled = enable;
        }

        public void enableSplit(bool enable) {
            this.splitButton.IsEnabled = enable;
        }

        //Total setters
        public void setUserTotal(String total) {
            this.userTotal.Content = total;
        }

        public void setDealerTotal(String total) {
            this.dealerTotal.Content = total;
        }

    }
}
