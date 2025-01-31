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

namespace couples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        

        public MainWindow()
        {
            InitializeComponent();
            CardDeck cardDeck = new CardDeck();

            List<Button> buttons = GetButtonsFromGrid(DeskGrid);
            int n = 0;
            foreach(var button in buttons)
            {
                button.Click += BT_Zero_Zero;
                button.Content = cardDeck.cards[n].frontImage;
                button.FontStretch = 
                n++;
            }
        }

        private void BT_Zero_Zero(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
        }



        private List<Button> GetButtonsFromGrid(Grid grid)
        {
            List<Button> buttons = new List<Button>();

            foreach (UIElement child in grid.Children)
            {
                if (child is Button button)
                {
                    buttons.Add(button);
                }
            }

            return buttons;
        }

       
    }
}