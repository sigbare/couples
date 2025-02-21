using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace couples
{
    public partial class MainWindow
    {
        public class ValueForCards<T, I>
        {
            public T Id { get; set; }
            public I PathFrontImage { get; set; }

            public ValueForCards(T id, I path)
            {
                Id = id;
                PathFrontImage = path;
            }

        }


        public class DeskHandler
        {
            private readonly Window _mainWindow;

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

            private List<ValueForCards<int, string>> ValueListCards;

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
                        checkedOpenCards(100);
                        _countOpenCard = 0;
                    }
                }
            }


            private async void checkedOpenCards(int delayInMillisconds)
            {
                _mainWindow.IsEnabled = false;
                await Task.Delay(delayInMillisconds);

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
                            Thread.Sleep(500);
                            item.IsOpen = false;
                            //item.SetActualImage(item.BackSide, item.FrontSide);
                            item.EnableCards(true);
                        }
                    }
                    _mainWindow.IsEnabled = true;
                }
            }

            public DeskHandler(List<Button> buttons, Window mainWindow)
            {

                _mainWindow = mainWindow;

                ValueListCards = new List<ValueForCards<int, string>> { };

                ValueListCards = InitializeCards(buttons);

                for (int i = 0; i < buttons.Count; i++)
                {
                    cards.Add(new Card(buttons[i], ValueListCards[i].Id, new Image { Source = new BitmapImage(new Uri(ValueListCards[i].PathFrontImage)) }));
                    buttons[i].Content = cards[i].BackSide;
                    cards[i].PropertyChanged += Card_PropertyChanged;

                }

            }

            private List<ValueForCards<int, string>> InitializeCards(List<Button> buttons)
            {
                int temp = 0;

                for (int i = 0; i < buttons.Count; ++i)
                {

                    ValueListCards.Add(new ValueForCards<int, string>(temp, FrontSideImage[temp]));

                    if (i % 2 != 0)
                        temp++;
                }

                return ShuffleList<ValueForCards<int, string>>(ValueListCards);

            }

            private List<T> ShuffleList<T>(List<T> list)
            {
                List<T> result = new List<T>(list);
                Random random = new Random();

                for (int i = result.Count - 1; i >= 1; i--)
                {
                    int j = random.Next(i) + 1;
                    T temp = result[i];
                    result[i] = result[j];
                    result[j] = temp;
                }

                return result;

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







