using System.Configuration;
using System.Windows;

namespace Task2
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            if (PasswordTextBox.Text == ConfigurationManager.AppSettings.Get("Password") && LoginTextBox.Text == ConfigurationManager.AppSettings.Get("Login"))
            {
                    SettingsWindow settingsWindow = new();
                    settingsWindow.Show();
            }
            else
                MessageBox.Show("Error");
        }
    }
}
