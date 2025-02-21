using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Imaging;

namespace couples
{
    public partial class MainWindow
    {
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
    }
}







