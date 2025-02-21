using System.ComponentModel.DataAnnotations;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Threading;

namespace couples
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private readonly List<Button> _buttons;
        private readonly DeskHandler _handler;
        [Required]
        private DispatcherTimer _timer;
        private int _remainingTime = 30;

        public MainWindow()
        {
            InitializeComponent();
            InitializeTimer();
            _buttons = GetButtonList();

            _handler = new DeskHandler(_buttons, this);


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

        private void InitializeTimer()
        {
            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(1) };
            _timer.Tick += TimerTick;
            _timer.Start();
        }

        private void TimerTick(object? sender, EventArgs e)
        {
            if (_remainingTime > 0)
            {
                _remainingTime--;
                TimerLable.Text = _remainingTime.ToString();
            }
            else
            {
                _timer.Stop();
                TimerLable.Text = "you lose";
            }

        }
    }
}







