using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace app_wpf_blackjack {
    class ElementManager {

        private Button drawButton;
        private Button holdButton;
        private Button splitButton;

        private Label userTotal;
        private Label dealerTotal;
        private Label updateText;

        private Grid maxmin;

        private Button max;
        private Button min;

        public ElementManager(Button drawButton, 
            Button holdButton, 
            Button splitButton, 
            Label userTotal, 
            Label dealerTotal,
            Label updateText,
            Grid maxmin,
            Button max,
            Button min) {

            this.drawButton = drawButton;
            this.holdButton = holdButton;
            this.splitButton = splitButton;

            this.userTotal = userTotal;
            this.dealerTotal = dealerTotal;
            this.updateText = updateText;

            this.maxmin = maxmin;

            this.max = max;
            this.min = min;
 
        }

        public void setMaxContent(int max, int min) {
            this.max.Content = "Max (" + max.ToString() + ")";
            this.min.Content = "Min (" + min.ToString() + ")";
        }

        public void maxVisable(bool visable) {

            if(visable) {
                this.maxmin.Visibility = Visibility.Visible;
            }

            else {
                this.maxmin.Visibility = Visibility.Collapsed;
            }

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
