using System.Windows;
using System.Text.RegularExpressions;
using System.Windows.Input;
using System.Windows.Controls;

namespace WinTimer
{
    public partial class MainWindow : Window
    {
        // Public
        MainWindowData data = new MainWindowData();

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = data;

            // Move window to center
            double screenWidth = System.Windows.SystemParameters.PrimaryScreenWidth;
            double screenHeight = System.Windows.SystemParameters.PrimaryScreenHeight;
            double windowWidth = this.Width;
            double windowHeight = this.Height;
            this.Left = (screenWidth / 2) - (windowWidth / 2);
            this.Top = (screenHeight / 2) - (windowHeight / 2);
        }

        private void RadioButton_Times_Checked(object sender, RoutedEventArgs e)
        {
            RadioButton pressed = (RadioButton)sender;
            if (pressed.Name == "Radio_Button_M") { this.data.TimeType = 0; }
            if (pressed.Name == "Radio_Button_H") { this.data.TimeType = 1; }
        }

        private void Button_Activate_Click(object sender, RoutedEventArgs e)
        {
            this.data.ActiveShutDown();
        }

        private void Button_Deactivate_Click(object sender, RoutedEventArgs e)
        {
            this.data.DeactivateShutDown();
        }

        private void NumberValidationTextBox(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

        private void Time_Text_Box_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = (TextBox)sender;
            string text = textBox.Text;
            int time = int.Parse(text);
            this.data.CurrentTime = time;
        }
    }
}      
