using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Marafon.Database;

namespace Marafon.Registration
{
    /// <summary>
    /// Логика взаимодействия для RegistrationPage.xaml
    /// </summary>
    public partial class RegistrationPage : Page
    {
        public RegistrationPage()
        {
            InitializeComponent();

            using (var context = new marathonEntities())
            {
                CountryComboBox.ItemsSource = context.country.Select(c => c.CountryName).ToList();
                GenderComboBox.ItemsSource = context.gender.Select(g => g.Gender1).ToList();
            }

            GoBackButton.Click += Navigation.GoBack;
            RegisterButton.Click += RegisterButton_Click;
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordTextBox.Text;
            var passwordRepeat = PasswordRepeatTextBox.Text;
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            var gender = GenderComboBox.SelectionBoxItemStringFormat;
            var country = CountryComboBox.SelectionBoxItemStringFormat;

            if (string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(passwordRepeat)
                || string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(gender)
                || string.IsNullOrEmpty(country))
                return;

            if (PasswordTextBox.Text != PasswordRepeatTextBox.Text)
            {
                MessageBox.Show("Пароли не совпадают");

                return;
            }

            using (var context = new marathonEntities())
            {
                var user = new users
                {
                    Email = email,
                    Password = password,
                    FirstName = firstName,
                    LastName = lastName,
                    RoleId = "R"
                };

                /*var runner = new runner
                {
                    Email = email,
                    Gender = "",
                    DateOfBirth = new DateTime?(),
                    CountryCode = ""
                };*/

                context.users.Add(user);
                context.SaveChanges();
            }
        }
    }
}
