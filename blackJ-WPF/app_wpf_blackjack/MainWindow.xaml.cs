using blackJ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace app_wpf_blackjack {

    public partial class MainWindow : Window {

        private Game game;
        private ElementManager elmManager;
        private BetManager betManager;
        private CardEngine cardEngine;

        public MainWindow() {
            InitializeComponent();

            //sends elements from XAML file
            this.elmManager = new ElementManager(drawBtn, holdBtn, splitBtn, userTotal, dealerTotal, updateText);
            this.betManager = new BetManager(betText, scoreText, up_25, up_50, up_100);
            this.cardEngine = new CardEngine(userCards, dealerCards);

            //initializes the program
            this.game = new Game(this.elmManager, this.betManager, this.cardEngine);

        }

        public void handle_size(object sender, RoutedEventArgs e) {

            //Console.WriteLine(App_Window.ActualHeight);

            GridLength star = new GridLength(1, GridUnitType.Star);
            GridLength small = new GridLength(50);
            GridLength medium = new GridLength(80);

            if(App_Window.ActualHeight > 660) {
                utop_c.Height = star;
                ubot_c.Height = star;

                top_c.Height = star;
                bot_c.Height = star;
            }

            else if(App_Window.ActualHeight > 590) {
                utop_c.Height = medium;
                ubot_c.Height = medium;

                top_c.Height = medium;
                bot_c.Height = medium;
            }

            else {
                utop_c.Height = small;
                ubot_c.Height = small;

                top_c.Height = small;
                bot_c.Height = small;
            }

        }

        //Event handlers bet
        public void handle_25(object sender, RoutedEventArgs e) {
            this.game.IncrementBet(25);
        }

        public void handle_50(object sender, RoutedEventArgs e) {
            this.game.IncrementBet(50);
        }

        public void handle_100(object sender, RoutedEventArgs e) {
            this.game.IncrementBet(100);
        }

        //Event handlers game
        public void handleDraw(object sender, RoutedEventArgs e) {
            this.game.draw();
        }

        public void handleHold(object sender, RoutedEventArgs e) {
            this.game.hold();
        }

        public void handleSplit(object sender, RoutedEventArgs e) {
            this.game.split();
        }

    }
}
