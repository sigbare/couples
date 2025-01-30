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
        
        BitmapImage FrontImage { get; set; }

        string name { get; set; }

        int id { get; set; }

        public Card(int id, string name, BitmapImage FrontImage)
        {
            this.id = id;
            this.name = name;
            this.FrontImage = FrontImage;
        }

    }

    class CardDeck
    {
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

        List<Card> cards = new List<Card>();

        public BitmapImage GetBackSide() => this.backSide;

        public void CreateCardDeck()
        {
            for(int i = 0; i < 8; i++)
            {
               Enumerable.Repeat(0,2).ToList().ForEach(_ => cards.Add(new Card(i, GetName(keyValuePairs[i]),new BitmapImage(new Uri($"pack://application:,,,/couples;component/image/{keyValuePairs[i]}")))));
            }



        }

        public string GetName(string nameFormat) => nameFormat.Remove(nameFormat.Length - 4 , 4);


    }
}
