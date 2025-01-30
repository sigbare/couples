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

            List<Button> buttons = GetButtonsFromGrid(DeskGrid);
            int n = 0;
            foreach(var button in buttons)
            {
                button.Content = $"it's {n} button";
                n++;
             
            }
        }

        private void BT_Zero_Zero(object sender, RoutedEventArgs e)
        {
           
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