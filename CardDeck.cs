using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace couples
{
    internal class CardDeck
    {
        private Dictionary<int, string> _imagePathKey = new Dictionary<int, string>()
        {
            {0,"1.jpg" },
            {1,"2.jpg" },
            {2,"3.jpg" },
            {3,"4.jpg" },
            {4,"5.jpg" },
            {5,"6.jpg" },
            {6,"7.jpg" },
            {7,"8.jpg" }
        };

        public Image BackSide { get; private set; }

        public int CardsCounts { get; private set; }

        public List<Card> Cards { get; private set; }

        public CardDeck(int CardsCounts)
        {
            BackSide = new Image { Source = new BitmapImage(new Uri("pack://application:,,,/couples;component/image/back.jpg")) };
            this.CardsCounts = CardsCounts;
            BackSide.Stretch = System.Windows.Media.Stretch.Fill;
            FillCardsList();
        }

        private void FillCardsList()
        {
            Cards = new List<Card>();
            for (int i = 0; i < CardsCounts / 2; i++)
            {

                Enumerable.Range(0, 2).ToList().ForEach(x => { Cards.Add(new Card(i, _imagePathKey[i])); });

               
            }
        }

        protected void InitButtonIdForCard(int buttonId, int indexCard)
        {
            if (indexCard > -1 && indexCard < CardsCounts)
            {
                Cards[indexCard].ButtonId = buttonId;
            }
            else
            {
                MessageBox.Show("InitButtonIdForCard error ");
            }


        }
    }
}
