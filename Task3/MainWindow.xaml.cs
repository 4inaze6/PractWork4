using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Windows;

namespace Task3
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

        private void AuthorizateButton_Click(object sender, RoutedEventArgs e)
        {
            AuthorizationWindow authorizationWindow = new();
            authorizationWindow.Show();
        }

        private void MainWindow_Load(object sender, RoutedEventArgs e)
        {
            string[] settings = File.ReadAllLines("userData.txt");
            var uriDict = new Uri($"Themes/{settings[3]}.xaml", UriKind.Relative);
            ResourceDictionary dictionary = Application.LoadComponent(uriDict) as ResourceDictionary;
            Application.Current.Resources.Clear();
            Application.Current.Resources.MergedDictionaries.Add(dictionary);
        }
    }
}