using System;
using System.Windows;

namespace Marafon
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            Navigation.SetFrame(FrmMain);
            Navigation.Navigate(new MainPage());

            PageTimer.Start(
                new DateTime(2017, 11, 5, 21, 42, 0),
                new DateTime(2017, 11, 24, 6, 0, 0));
        }

        public static PageTimer PageTimer = new PageTimer();
    }
}
