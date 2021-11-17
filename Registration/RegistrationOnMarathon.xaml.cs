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
            aboutPage.Show();
        }
    }
}
