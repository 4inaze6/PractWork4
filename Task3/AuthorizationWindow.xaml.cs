using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Task3
{
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        private void AuthorizationButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(PasswordTextBox.Text);
            byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);
            string hash = Convert.ToHexString(hashedBytes);

            string[] settings = File.ReadAllLines("userData.txt");
            if (hash == settings[1] && LoginTextBox.Text == settings[0])
            {
                SettingsWindow settingsWindow = new();
                settingsWindow.Show();
            }
            else
                MessageBox.Show("Error");
        }
    }
}
