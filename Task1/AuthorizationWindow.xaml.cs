using System.Windows;

namespace Task1
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
            if (PasswordTextBox.Text == Properties.Settings.Default.Password && LoginTextBox.Text == Properties.Settings.Default.Login)
            {
                SettingsWindow settingsWindow = new();
                settingsWindow.Show();
            }
            else
                MessageBox.Show("Error");
        }
    }
}
