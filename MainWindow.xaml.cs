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

        }

        private void BT_Zero_Zero(object sender, RoutedEventArgs e)
        {
            BT_Z_Z.Source = backSide;
        }
    }
}