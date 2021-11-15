using System.Windows;
using System.Windows.Controls;

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
        }

        private void LogoutButton_Click(object sender, RoutedEventArgs e)
        {
            UserApi.Logout();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
