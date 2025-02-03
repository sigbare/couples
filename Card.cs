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
        public readonly Image backSide = new() { Source = new BitmapImage(new Uri("pack://application:,,,/couples;component/image/back.jpg"))};

        public Image FrontSide {  get; set; }

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

        public int Id { get; set; }

        public Card(Image frontSide, int id)
        {
            FrontSide = frontSide;
            IsOpen = false;
            Id = id;
        }

        public event EventHandler? ValueChange;

        protected virtual void OnValueChanged(EventArgs e)
        {
            ValueChange?.Invoke(this, e);
        }

    }

    class CardDeck 
    {
        private readonly Random random = new();

        readonly Dictionary<int, string> LinqForFrontImage = new ()
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

        private int? lastGetId = null;


        public readonly List<Card> cards = [];

        private  void CreateCardDesk()
        {
            for(int i = 0; i < 16; i++)
            {
                int n;   // take id number for create two same cards 

                if(i <= 7)
                {
                     n = i;
                }
                else
                {
                    n = i - 8;
                }
                
                cards.Add(new Card(new Image { Source = new BitmapImage(new Uri($"pack://application:,,,/couples;component/{LinqForFrontImage[n]}")) },               
                     n));
                cards[i].ValueChange += OnValueChanged;
                
            }
        }

        private List<T>? Shuffle<T>(List<T> cards)
        {

            if (cards == null || cards.Count <= 1)
            {
                return cards;
            }

            for (int i = cards.Count - 1; i > 0; i--)
            {
                int j = random.Next(i + 1);
                (cards[j], cards[i]) = (cards[i], cards[j]);
            }
            return cards;
        }

        public CardDeck()
        {
            CreateCardDesk();
            this.cards = Shuffle(cards);
        }

        private void OnValueChanged(object? sender, EventArgs e)
        {
            Card? card = sender as Card;
            if(lastGetId is not null && card is not null)
            {
                if(lastGetId == card.Id)
                {
                    OnRemoveCard(EventArgs.Empty);
                }
                else
                {
                   foreach(Card card1 in cards)
                    {
                        if (card1.Id == card.Id)
                        {
                            card1.IsOpen = false;
                            
                        }
                            
                    }



                    lastGetId = null;
                }

            }
            else
            {
                lastGetId = card.Id;
                MessageBox.Show("записали");
            }
            
        }

        

        public event EventHandler? RemoveCard;

        

        protected virtual void OnRemoveCard(EventArgs e)
        {
            RemoveCard?.Invoke(this, e);
        }

        public int? GetRemoveCardID()
        {
            return lastGetId;
        }
    }
}
