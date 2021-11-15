using System.Windows;
using System.Windows.Controls;

namespace Marafon
{
    public static class Navigation
    {
        private static Frame _frame;

        public static void SetFrame(Frame frame)
        {
            if (_frame != null)
                return;

            _frame = frame;
        }

        public static void Navigate(Page page)
        {
            if (page.DataContext != MainWindow.PageTimer)
                page.DataContext = MainWindow.PageTimer;

            _frame?.Navigate(page);
        }

        public static void GoBack(object sender, RoutedEventArgs e)
        {
            _frame.GoBack();
        }
    }
}