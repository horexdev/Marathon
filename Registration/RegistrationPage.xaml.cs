using System;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using Marafon.Database;
using Microsoft.Win32;

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

            CountryComboBox.ItemsSource = Context.GetCountriesList();
            GenderComboBox.ItemsSource = Context.GetGendersList();

            GoBackButton.Click += Navigation.GoBack;
            RegisterButton.Click += RegisterButton_Click;
            PasswordRepeatTextBox.PasswordChanged += PasswordRepeatTextBox_TextChanged;
            PasswordTextBox.PasswordChanged += PasswordRepeatTextBox_TextChanged;
            LoadAvatarButton.Click += LoadAvatarButton_Click;
            DateOfBirthPicker.PreviewTextInput += DateOfBirthPicker_PreviewTextInput;

            _registrationHandler = new RegistrationHandler();
        }

        private readonly RegistrationHandler _registrationHandler;
        private byte[] _binaryAvatar;

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            var email = EmailTextBox.Text;
            var password = PasswordTextBox.Password;
            var passwordRepeat = PasswordRepeatTextBox.Password;
            var firstName = FirstNameTextBox.Text;
            var lastName = LastNameTextBox.Text;
            var gender = GenderComboBox.SelectedItem?.ToString();
            var country = CountryComboBox.SelectedItem?.ToString();
            var countryCode = Context.GetCountryCodeByName(country);
            var roleAbbreviation = RoleTypes.GetAbbreviation(RoleTypes.Runner);
            var dateOfBirth = DateOfBirthPicker.SelectedDate;

            if (string.IsNullOrEmpty(email)
                || string.IsNullOrEmpty(password)
                || string.IsNullOrEmpty(passwordRepeat)
                || string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(gender)
                || string.IsNullOrEmpty(country)
                || dateOfBirth == null)
                return;

            if (_registrationHandler.IsValidPassword(password) == false)
            {
                MessageBox.Show("Пароль должен отвечать следующим требованиям\rМинимум 6 символов\rМинимум 1 прописная буква\rМинимум 1 цифра\rМинимум один из следующих символов: ! @ # $ % ^", "", MessageBoxButton.OK, MessageBoxImage.Information);

                return;
            }

            if (roleAbbreviation == null)
                throw new NullReferenceException("Role Abbreviation Null Reference Exception");

            if (_registrationHandler.IsValidEmail(email) == false)
            {
                MessageBox.Show("Введённая вами электронная почта не соответствует формату");

                return;
            }

            if (PasswordTextBox.Password != PasswordRepeatTextBox.Password)
            {
                MessageBox.Show("Пароли не совпадают");

                return;
            }

            _registrationHandler.RegisterUser(email, password, firstName, lastName, roleAbbreviation, _binaryAvatar);
            _registrationHandler.RegisterRunner(email, gender, dateOfBirth.Value, countryCode);
        }

        private void PasswordRepeatTextBox_TextChanged(object sender, RoutedEventArgs e)
        {
            var currentPassword = PasswordTextBox.Password;
            var repeatedPassword = PasswordRepeatTextBox.Password;

            if (string.IsNullOrEmpty(currentPassword) || string.IsNullOrEmpty(currentPassword))
                return;

            if (currentPassword == repeatedPassword)
                PasswordConfirmedImage.Visibility = Visibility.Visible;
            else
            {
                if (PasswordConfirmedImage.Visibility == Visibility.Hidden)
                    return;

                PasswordConfirmedImage.Visibility = Visibility.Hidden;
            }
        }

        private void LoadAvatarButton_Click(object sender, RoutedEventArgs e)
        {
            var openFileDialog = new OpenFileDialog();
            var avatarPath = "";
            if (openFileDialog.ShowDialog() == true)
                avatarPath = openFileDialog.FileName;

            _binaryAvatar = UserApi.ConvertAvatarToBinary(avatarPath);
        }

        private void DateOfBirthPicker_PreviewTextInput(object sender, System.Windows.Input.TextCompositionEventArgs e) => e.Handled = true;
    }
}
