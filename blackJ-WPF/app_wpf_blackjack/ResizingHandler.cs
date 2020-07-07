using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;

namespace app_wpf_blackjack {

    class ResizingHandler {

        private RowDefinition userTop;
        private RowDefinition userBot;
        private RowDefinition dealerTop;
        private RowDefinition dealerBot;
        private RowDefinition split;

        private bool issplit;

        private int currentSize;

        private readonly GridLength STAR = new GridLength(1, GridUnitType.Star);
        private readonly GridLength NONE = new GridLength(0);
        private readonly GridLength SMALL = new GridLength(50);
        private readonly GridLength MED = new GridLength(80);

        public ResizingHandler(RowDefinition userTop, RowDefinition userBot,
            RowDefinition dealerTop, RowDefinition dealerBot,
            RowDefinition split) {

            this.userTop = userTop;
            this.userBot = userBot;

            this.dealerTop = dealerTop;
            this.dealerBot = dealerBot;

            this.split = split;

            this.issplit = false;
            this.currentSize = 0;

        }

        public void setIsSplit(bool issplit) {
            this.issplit = issplit;
            resize(this.currentSize);
        }

        public void resize(int window) {
            this.currentSize = window;
            
            if(window > 660) {
                setSize(this.STAR, this.issplit);
            }

            else if(window > 590) {
                setSize(this.MED, this.issplit);
            }

            else {
                setSize(this.SMALL, this.issplit);
            }
        }

        private void setSize(GridLength length, bool split) {
            //sets dealer size
            this.dealerTop.Height = length;
            this.dealerBot.Height = length;

            //sets usersize and split
            if(!this.issplit) {
                this.split.Height = this.NONE;
                this.userTop.Height = length;
                this.userBot.Height = length;
            }

            else {

                GridLength under = new GridLength(length.Value / 3);
                GridLength med = new GridLength(this.currentSize / 8);
                GridLength over = new GridLength(this.currentSize / 6);

                this.split.Height = this.STAR;

                if (this.currentSize > 660) {
                    this.userTop.Height = over;
                    this.userBot.Height = over;
                }

                else if(this.currentSize > 590) {
                    this.userTop.Height = med;
                    this.userBot.Height = med;
                }

                else {
                    this.userTop.Height = under;
                    this.userBot.Height = under;
                }

            }

        }

    }
}
