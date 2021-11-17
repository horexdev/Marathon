using System.Windows.Controls;
using Marafon.Database;

namespace Marafon.Registration
{
    /// <summary>
    /// Логика взаимодействия для RegistrationOnMarathon.xaml
    /// </summary>
    public partial class RegistrationOnMarathon : Page
    {
        public RegistrationOnMarathon()
        {
            InitializeComponent();

            FundComboBox.DisplayMemberPath = "CharityName";
            FundComboBox.ItemsSource = Context.GetFundsList();

            FundInfoButton.Click += FundInfoButton_Click;
        }

        private void FundInfoButton_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            var aboutPage = new AboutFundWindow();
            var charity = FundComboBox.SelectedItem as charity;
            var logoPath = $"../Resources/{charity?.CharityLogo}";
            var obj = new
            {
                CharityName = charity?.CharityName,
                CharityDescription = charity?.CharityDescription,
                CharityLogo = logoPath
            };
            aboutPage.DataContext = obj;
            aboutPage.Show();
        }
    }
}
