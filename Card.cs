using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace couples
{
    internal class Card
    {
        
        BitmapImage frontImage { get; set; }

        string name { get; set; }

        int id { get; set; }

        public Card(int id, string name, BitmapImage FrontImage)
        {
            this.id = id;
            this.name = name;
            this.frontImage = FrontImage;
        }

    }

    class CardDeck
    {
        private Random random = new Random();

        Dictionary<int, string> keyValuePairs = new Dictionary<int, string>()
        {
            {0,"image/1.jpg"},
            {1,"image/2.jpg"},
            {2,"image/3.jpg"},
            {3,"image/4.jpg"},
            {4,"image/5.jpg"},
            {5,"image/6.jpg"},
            {6,"image/7.jpg"},
            {7,"image/8.jpg"},
        };

        readonly BitmapImage backSide = new BitmapImage(new Uri("pack://application:,,,/couples;component/image/back.jpg"));

        readonly List<Card> cards = new List<Card>();

        public BitmapImage GetBackSide() => this.backSide;

        private void CreateCardDeck()
        {
            for(int i = 0; i < 8; i++)
            {
               Enumerable.Repeat(0,2).ToList().ForEach(_ => cards.Add(new Card(i, GetName(keyValuePairs[i]),new BitmapImage(new Uri($"pack://application:,,,/couples;component/{keyValuePairs[i]}")))));
            }



        }

        private string GetName(string nameFormat) => nameFormat.Remove(nameFormat.Length - 4 , 4);

        private List<T> Shuffle<T>(List<T> cards)
        {
            

            if (cards == null || cards.Count <= 1)
            {
                return cards;
            }

            for(int i = cards.Count;  i > 0; i--)
            {
                int j = random.Next(i + 1);
                T temp = cards[i];
                cards[i] = cards[j];
                cards[j] = temp;
            }
            return cards;
        } 


        public CardDeck()
        {
            CreateCardDeck();
            this.cards = Shuffle<Card>(cards);
        }
    }
}
