using System.ComponentModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Threading;
using System.Runtime.CompilerServices;

namespace couples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly List<Button> _buttons;
        private readonly DeskHandler _handler;

        public MainWindow()
        {
            InitializeComponent();
            _buttons = GetButtonList();

            _handler = new DeskHandler(_buttons);

        }

        private List<Button> GetButtonList()
        {
            List<Button> _bt = [];
            foreach (var item in DeskGrid.Children)
            {
                if (item is Button button)
                {
                    _bt.Add(button);
                }
            }
            return _bt;
        }

    }

    public class Card : INotifyPropertyChanged
    {

        private Button _button { get; set; }

        public readonly Image BackSide = new() { Source = (new BitmapImage(new Uri("pack://application:,,,/couples;component/image/back.jpg"))) };

        public Image FrontSide { get; set; }

        public int _cardId { get; private set; }

        private bool _IsOpent;

        public bool IsOpen
        {
            get { return _IsOpent; }
            set
            {
                if (value != _IsOpent)
                {
                    _IsOpent = value;
                     OnPropertyChanged(nameof(IsOpen));
                }

            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public Card(Button button, int _cardId, Image FrontSide)
        {
            _button = button;
            this.FrontSide = FrontSide;
            _button.Click += ButtonClik;
            this._cardId = _cardId; 

        }

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void ButtonClik(object sender, RoutedEventArgs e)
        {
            IsOpen = IsOpen != true;
            SetActualImage(BackSide, FrontSide);
            if (IsOpen)
            {
                _button.IsEnabled = false;
            }
        }

        public void SetActualImage(Image backSide, Image frontSide)
        {
            if (IsOpen == false)
                _button.Content = backSide;
            else
                _button.Content = frontSide;
        }

        public void EnableCards(bool enable)
        {
            if (!enable)
            {
                _button.Visibility = Visibility.Hidden;
                _button.IsEnabled = false;
            }

            else
            {
                _button.Visibility = Visibility.Visible;
                _button.IsEnabled = true;
            }
           
           }
                

    }


    public class DeskHandler 
    {
       
        Dictionary<int, string> FrontSideImage = new()
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
                if(_countOpenCard == 2)
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

            if(couples.Count == 2)
            {
                if (couples[0]._cardId == couples[1]._cardId)
                {
                    foreach(var item in couples)
                    {
                        item.EnableCards(false);
                        item.IsOpen = false;
                    }
                    MessageBox.Show("you found couples");
                }
                else
                {
                    foreach(var item in couples)
                    {
                        item.IsOpen = false;
                        item.SetActualImage(item.BackSide,item.FrontSide);
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
                if(temp != null)
                {
                    if (temp.IsOpen == true)
                        CountOpenCard++;
                }
              

 
            }
        }

    }
}







