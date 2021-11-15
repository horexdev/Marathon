using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Marafon.Database;
using Marafon.Menu;

namespace Marafon.Auth
{
    /// <summary>
    /// Логика взаимодействия для AuthPage.xaml
    /// </summary>
    public partial class AuthPage : Page
    {
        public AuthPage()
        {
            InitializeComponent();

            GoBackButton.Click += Navigation.GoBack;
            SignInButton.Click += SignInButton_Click;
        }

        private void SignInButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordTextBox.Text;

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(password))
                return;

            var user = Context.FindUserByEmail(email);

            if (user == null || user.Password != password)
            {
                MessageBox.Show("Неверный логин пароль");

                return;
            }

            AuthHandler.AuthorizeUser(user);
            MessageBox.Show("Вы успешно авторизовались!");
            Navigation.Navigate(new RunnerMenu());
        }
    }
}
