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
    internal class Card
    {
        public readonly Image backSide = new Image { Source = new BitmapImage(new Uri("pack://application:,,,/couples;component/image/back.jpg"))};

        public Image frontSide {  get; set; }

        private bool _isOpen;

        public bool IsOpen
        {
            get { return _isOpen; }
            set
            {
                if (_isOpen != value)
                {
                    _isOpen = value;
                    OnValueChanged(EventArgs.Empty);
                }
            }
        }

        public int id { get; set; }

        public Card(Image fronSide, int id)
        {
            this.frontSide = fronSide;
            IsOpen = false;
            this.id = id;
        }

        public event EventHandler ValueChange;

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChange?.Invoke(this, e);
        }

        
       

    }

    class CardDeck 
    {
        private Random random = new Random();

        Dictionary<int, string> LinqForFrontImage = new Dictionary<int, string>()
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

        public readonly List<Card> cards = new List<Card>();

        private  void CreateCardDesk()
        {
            for(int i = 0; i < LinqForFrontImage.Count; i++)
            {
                Enumerable.Repeat(0,2).ToList().ForEach(_ => cards.Add(new Card(
                    new Image { Source = new BitmapImage(new Uri($"pack://application:,,,/couples;component/{LinqForFrontImage[i]}")) },
                    i)));
                cards[i].ValueChange += OnValueChanged;
                
            }
        }

        private List<T> Shuffle<T>(List<T> cards)
        {

            if (cards == null || cards.Count <= 1)
            {
                return cards;
            }

            for (int i = cards.Count - 1; i > 0; i--)
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
            CreateCardDesk();
            this.cards = Shuffle(cards);
        }

        private void OnValueChanged(object sender, EventArgs e)
        {
            MessageBox.Show("it's work");
        }

    




    }
}
