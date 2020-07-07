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

            //Console.WriteLine(App_Window.ActualHeight); split_row is new row to be handled

            GridLength star = new GridLength(1, GridUnitType.Star);
            GridLength small = new GridLength(50);
            GridLength medium = new GridLength(80);

            bool split = game.splitVal();

            if(App_Window.ActualHeight > 660) {

                setUserAndSplitGridLength(star, split);

                setDealerGridLength(star);

            }

            else if(App_Window.ActualHeight > 590) {

                setUserAndSplitGridLength(medium, split);

                setDealerGridLength(medium);

            }

            else {

                setUserAndSplitGridLength(small, split);

                setDealerGridLength(small);

            }

        }

        private void setUserAndSplitGridLength(GridLength length, bool split) {
            if(!split) {
                split_row.Height = new GridLength(0);
                this.utop_c.Height = length;
                this.ubot_c.Height = length;
            }

            else {
                GridLength under = new GridLength(length.Value / 3);
                GridLength med = new GridLength(App_Window.ActualHeight / 8);
                GridLength over = new GridLength(App_Window.ActualHeight / 6);

                split_row.Height = new GridLength(1, GridUnitType.Star);

                if (App_Window.ActualHeight > 800) {
                    this.utop_c.Height = over;
                    this.ubot_c.Height = over;
                }

                else if(App_Window.ActualHeight > 660) {
                    this.utop_c.Height = med;
                    this.ubot_c.Height = med;
                }

                else {
                    this.utop_c.Height = under;
                    this.ubot_c.Height = under;
                }
        
            }
            
        }

        private void setDealerGridLength(GridLength length) {
            this.top_c.Height = length;
            this.bot_c.Height = length;
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
