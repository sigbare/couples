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

        List<Button> _buttons = new List<Button>();

       
        public MainWindow()
        {
            InitializeComponent();

            foreach(var item in DeskGrid.Children)
            {
                if(item is Button)
                {
                    _buttons.Add(x => item as Button);
                }
            }

        }

      
       

       
       

      
       
    }


  
}