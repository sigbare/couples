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
        DeskHandler handler;
        private int _numberCards = 16;
        

        public MainWindow()
        {
            InitializeComponent();


            handler = new DeskHandler(_numberCards);

            foreach(var item in DeskGrid.Children)
            {
                if(item is Button)
                {
                    handler.FillButtons(button: (Button)item);
                }
            }

            for(int i = 0; i < _numberCards; i++)
            {
                handler.SetImage(i);
            }
        }

       

       
       

      
       
    }
}