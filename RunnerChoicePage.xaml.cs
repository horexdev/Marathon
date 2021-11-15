using System.Windows;
using System.Windows.Controls;
using Marafon.Auth;
using Marafon.Registration;

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для RunnerChoicePage.xaml
    /// </summary>
    public partial class RunnerChoicePage : Page
    {
        public RunnerChoicePage()
        {
            InitializeComponent();

            GoBackButton.Click += Navigation.GoBack;
            NewParticipiantButton.Click += NewParticipiantButton_Click;
            ParticipatedEarlierButton.Click += ParticipatedEarlierButton_Click;
        }

        private void ParticipatedEarlierButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new AuthPage());
        }

        private void NewParticipiantButton_Click(object sender, RoutedEventArgs e)
        {
            Navigation.Navigate(new RegistrationPage());
        }
    }
}
