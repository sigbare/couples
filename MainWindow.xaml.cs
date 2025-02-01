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
        CardDeskHandler deskHandler;
        private Dictionary<Button, int> ButtonsKeys = new Dictionary<Button, int>();
        public List<Button> buttons;

   

        public MainWindow()
        {
            InitializeComponent();

            deskHandler = new CardDeskHandler();


            buttons = deskHandler.GetButtonsFromGrid(DeskGrid);
            
            for(int i = 0; i < buttons.Count; i++)
            {
                ButtonsKeys.Add(buttons[i], i);
                buttons[i].Click += OpenCard;
                buttons[i].Content = deskHandler.GetImage(i);
            }
            

            
        }

        private void OpenCard(object sender,  RoutedEventArgs e)
        {
            var button = sender as Button;

            if (button != null)
            {
                deskHandler.cardDeck.cards[ButtonsKeys[button]].IsOpen = true;
                button.Content = deskHandler.GetImage(ButtonsKeys[button]);
                button.IsEnabled = false;
                
            }
            
          
        }

       
       

      
       
    }
}