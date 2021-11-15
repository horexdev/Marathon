using System.Windows.Controls;

namespace Marafon
{
    /// <summary>
    /// Логика взаимодействия для RunnerSponsorPage.xaml
    /// </summary>
    public partial class RunnerSponsorPage : Page
    {
        public RunnerSponsorPage()
        {
            InitializeComponent();

            GoBackButton.Click += Navigation.GoBack;
        }
    }
}
