using System.Windows;
using System.Windows.Controls;
using Marafon.Auth;

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();

            LoginButton.Click += LoginButton_Click;
            ChoiceButton.Click += ChoiceButton_Click;
        }

        private void ChoiceButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new RunnerChoicePage());
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new AuthPage());
        }
    }
}
