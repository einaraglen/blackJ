﻿using blackJ;
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
        private ResizingHandler rsHandler;

        public MainWindow() {
            //Inits window
            InitializeComponent();

            //sends elements from XAML file
            this.elmManager = new ElementManager(drawBtn, holdBtn, splitBtn, userTotal, dealerTotal, updateText, max_buttons, btn_max, btn_min);
            this.betManager = new BetManager(betText, scoreText, up_25, up_50, up_100);
            this.cardEngine = new CardEngine(userCards, splitCards, dealerCards);
            this.rsHandler = new ResizingHandler(utop_c, ubot_c, top_c, bot_c, split_row);

            //initializes the program
            this.game = new Game(this.elmManager, this.betManager, this.cardEngine, this.rsHandler);

        }
        public void handle_max(object sender, RoutedEventArgs e) {
            this.game.setMax(true);
        }

        public void handle_min(object sender, RoutedEventArgs e) {
            this.game.setMax(false);
        }

        public void handle_size(object sender, RoutedEventArgs e) {

            //Console.WriteLine(App_Window.ActualHeight);

            this.game.resize(App_Window.ActualHeight);
            
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
