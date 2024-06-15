using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Task3
{
    /// <summary>
    /// Логика взаимодействия для SettingsWindow.xaml
    /// </summary>
    public partial class SettingsWindow : Window
    {
        public SettingsWindow()
        {
            InitializeComponent();
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            byte[] inputBytes = Encoding.UTF8.GetBytes(PasswordTextBox.Text);
            byte[] hashedBytes = SHA256.Create().ComputeHash(inputBytes);
            string hash = Convert.ToHexString(hashedBytes);

            File.WriteAllText("userData.txt", $"{LoginTextBox.Text}\n{hash}\n{EmailTextBox.Text}");
            MessageBox.Show("Settings saved");
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            string[] settings = File.ReadAllLines("userData.txt");
            LoginTextBox.Text = settings[0];
            PasswordTextBox.Text = settings[1];
            EmailTextBox.Text = settings[2];
        }

        private void DarkThemeButton_Click(object sender, RoutedEventArgs e)
        {
            string[] settings = File.ReadAllLines("userData.txt");
            string str1 = settings[0];
            string str2 = settings[1];
            string str3 = settings[2];
            string str4 = "Dark";
            File.WriteAllText("userData.txt", $"{str1}\n{str2}\n{str3}\n{str4}");
            ChangeTheme("Dark");

        }

        private void LightThemeButton_Click(object sender, RoutedEventArgs e)
        {
            string[] settings = File.ReadAllLines("userData.txt");
            string str1 = settings[0];
            string str2 = settings[1];
            string str3 = settings[2];
            string str4 = "Light";
            File.WriteAllText("userData.txt", $"{str1}\n{str2}\n{str3}\n{str4}");
            ChangeTheme("Light");
        }

        private void ChangeTheme(string themeName)
        {
            var uriDict = new Uri($"Themes/{themeName}.xaml", UriKind.Relative);
            ResourceDictionary dictionary = Application.LoadComponent(uriDict) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}
