using System;
using System.Collections.Generic;
using System.Text;

namespace blackJ {
    class Card {

        private int face;
        private int number;

        public Card(int face, int number) { 
            this.face = face;
            this.number = number;
        }

        public int getFace() {
            return this.face;
        }

        public int getNumber() {
            return this.number;
        }
    }
}
