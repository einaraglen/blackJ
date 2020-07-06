using blackJ;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace app_wpf_blackjack {
    
    class CardEngine {

        private StackPanel userCards;
        private StackPanel dealerCards;

        private String PATH = "resources/images/";
        public String[] faces = {"hearts", "spades", "diamonds", "clubs"};

        public Card[] stack;

        public CardEngine(StackPanel userCards, StackPanel dealerCards) { 

            this.userCards = userCards;
            this.dealerCards = dealerCards;

            this.stack = createStack();
        
        }

        public void updateUserCards(List<int> userHand) {
            updateCards(userHand, this.userCards);
        }

        public void updateDealerCards(List<int> dealerHand) {
            updateCards(dealerHand, this.dealerCards);
        }

        public void updateCards(List<int> indexes, StackPanel elm) {

            Console.WriteLine(indexes.ToArray().Length);

            elm.Children.Clear();

            foreach(int i in indexes.ToArray()) {

                Image img = new Image();

                BitmapImage bitmap = new BitmapImage();
                bitmap.BeginInit();
                bitmap.UriSource = new Uri(this.PATH + getCard(i).getNumber() + this.faces[getCard(i).getFace()] + ".png", UriKind.Relative);
                bitmap.EndInit();

                img.Stretch = Stretch.Fill;
                img.Stretch = Stretch.UniformToFill;
                img.Margin = new Thickness(2, 10, 2, 10);
                img.Source = bitmap;

                elm.Children.Add(img);
                
            }

        }

        private Card getCard(int index) {
            return this.stack[index];
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

    }
}
