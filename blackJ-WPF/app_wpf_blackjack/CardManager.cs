using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace blackJ {
    class CardManager {

        private List<int> inplay = new List<int>();
        private Random random;

        public CardManager() {
            this.random = new Random();
        }

        public int drawCard() {
            bool unique = false;
            int index = 0;

            while(!unique) {
                index = randomNumberFromTo(0, 51);

                if(this.inplay.ToArray().Length == 0 || !this.inplay.Contains(index)) {
                    this.inplay.Add(index);
                    unique = true;
                }

            }

            return index;

        }

        public void clear() {
            this.inplay.Clear();
        }

        public int randomNumberFromTo(int min, int max) {
            return this.random.Next(min, max);
        }
    }
}
