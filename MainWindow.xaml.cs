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

        public List<Button> buttons;

        private int NumberOpenCard;

        public MainWindow()
        {
            InitializeComponent();

            deskHandler = new CardDeskHandler();

            NumberOpenCard = 0;

            buttons = deskHandler.GetButtonsFromGrid(DeskGrid);
            
            for(int i = 0; i < buttons.Count; i++)
            {
                buttons[i].Click += OpenCard;
                buttons[i].Content = deskHandler.GetImage(i);
            }
            

            
        }

        private void OpenCard(object sender,  RoutedEventArgs e)
        {
            var button = sender as Button;

            button.IsEnabled = false;
            if (button != null)
            {

            }
            
          
        }

       

       
       
    }
}