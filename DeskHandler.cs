using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace couples
{
    public partial class MainWindow
    {
        public class DeskHandler
        {
            private Dictionary<int, string> FrontSideImage = new()
        {
            {0, "pack://application:,,,/couples;component/image/1.jpg"},
            {1, "pack://application:,,,/couples;component/image/2.jpg"},
            {2, "pack://application:,,,/couples;component/image/3.jpg"},
            {3, "pack://application:,,,/couples;component/image/4.jpg"},
            {4, "pack://application:,,,/couples;component/image/5.jpg"},
            {5, "pack://application:,,,/couples;component/image/6.jpg"},
            {6, "pack://application:,,,/couples;component/image/7.jpg"},
            {7, "pack://application:,,,/couples;component/image/8.jpg"},
        };

            private List<Card> cards = [];

            private int _countOpenCard;

            public int CountOpenCard
            {
                get { return _countOpenCard; }
                set
                {
                    _countOpenCard = value;
                    if (_countOpenCard == 2)
                    {
                        checkedOpenCards();
                        _countOpenCard = 0;
                    }
                }
            }

            private void checkedOpenCards()
            {
                List<Card> couples = [];

                foreach (Card card in cards)
                {
                    if (card.IsOpen)
                    {
                        couples.Add(card);
                    }
                }

                if (couples.Count == 2)
                {
                    if (couples[0]._cardId == couples[1]._cardId)
                    {
                        foreach (var item in couples)
                        {
                            item.EnableCards(false);
                            item.IsOpen = false;
                        }
                        MessageBox.Show("you found couples");
                    }
                    else
                    {
                        foreach (var item in couples)
                        {
                            item.IsOpen = false;
                            item.SetActualImage(item.BackSide, item.FrontSide);
                            item.EnableCards(true);
                        }
                    }
                }
            }

            public DeskHandler(List<Button> buttons)
            {
                int temp = 0;

                for (int i = 0; i < buttons.Count; i++)
                {
                    cards.Add(new Card(buttons[i], temp, new Image { Source = new BitmapImage(new Uri(FrontSideImage[temp])) }));
                    buttons[i].Content = cards[i].BackSide;
                    cards[i].PropertyChanged += Card_PropertyChanged;
                    if (i % 2 != 0)
                        temp++;
                }

            }
            private void Card_PropertyChanged(object sender, PropertyChangedEventArgs e)
            {
                if (e.PropertyName == nameof(Card.IsOpen))
                {
                    var temp = sender as Card;
                    if (temp != null)
                    {
                        if (temp.IsOpen == true)
                            CountOpenCard++;
                    }



                }
            }

        }
    }
}







