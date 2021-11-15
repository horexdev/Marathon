using System.Windows.Controls;

namespace Marafon.Menu
{
    /// <summary>
    /// Логика взаимодействия для CoordinatorMenu.xaml
    /// </summary>
    public partial class CoordinatorMenu : Page
    {
        public CoordinatorMenu()
        {
            InitializeComponent();

            LogoutButton.Click += LogoutButton_Click;
        }

        private void LogoutButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            UserApi.Logout();
        }
    }
}
