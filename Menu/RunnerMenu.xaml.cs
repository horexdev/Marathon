using System.Windows;
using System.Windows.Controls;
using Marafon.Registration;

namespace Marafon.Menu
{
    /// <summary>
    /// Логика взаимодействия для RunnerMenu.xaml
    /// </summary>
    public partial class RunnerMenu : Page
    {
        public RunnerMenu()
        {
            InitializeComponent();

            GoBackButton.Click += Navigation.GoBack;
            LogoutButton.Click += LogoutButton_Click;
            MarathonRegistrationButton.Click += MarathonRegistrationButton_Click;
        }

        private void MarathonRegistrationButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new RegistrationOnMarathon());
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            UserApi.Logout();
        }
    }
}
