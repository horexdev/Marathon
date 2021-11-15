using System;
using System.ComponentModel;
using System.Timers;

namespace Marafon
{
    public class PageTimer : INotifyPropertyChanged
    {
        private DateTime _currentDateTime;
        private DateTime _startDateTime;
        private string _timeStampLine;
        private readonly PropertyChangedEventArgs _propertyChangedEventArgs = new PropertyChangedEventArgs(nameof(TimeStampLine));
        private readonly Timer _timer = new Timer(1000);

        public event PropertyChangedEventHandler PropertyChanged;

        public string TimeStampLine
        {
            get => _timeStampLine;
            set
            {
                _timeStampLine = value;
                PropertyChanged?.Invoke(this, _propertyChangedEventArgs);
            }
        }

        public void Start(DateTime currentDateTime, DateTime startDateTime)
        {
            if (_timer.Enabled)
                return;

            _currentDateTime = currentDateTime;
            _startDateTime = startDateTime;

            _timer.Elapsed += OnTick;
            _timer.Start();
        }

        private void OnTick(object sender, EventArgs args)
        {
            var timeStamp = _startDateTime.Subtract(_currentDateTime);
            var dayWord = Generate(timeStamp.Days, "день", "дня", "дней");
            var hourWord = Generate(timeStamp.Hours, "час", "часа", "часов");
            var minuteWord = Generate(timeStamp.Minutes, "минута", "минуты", "минут");

            TimeStampLine = $"{timeStamp.Days} {dayWord} {timeStamp.Hours} {hourWord} {timeStamp.Minutes} {minuteWord} до старта марафона!";
            _currentDateTime = _currentDateTime.AddSeconds(1);
        }

        /// <summary>
        /// Возвращает слова в падеже, зависимом от заданного числа
        /// </summary>
        /// <param name="number">Число от которого зависит выбранное слово</param>
        /// <param name="nominativ">Именительный падеж слова. Например "день"</param>
        /// <param name="genetiv">Родительный падеж слова. Например "дня"</param>
        /// <param name="plural">Множественное число слова. Например "дней"</param>
        /// <returns></returns>
        private static string Generate(int number, string nominativ, string genetiv, string plural)
        {
            var titles = new[] { nominativ, genetiv, plural };
            var cases = new[] { 2, 0, 1, 1, 1, 2 };
            return titles[number % 100 > 4 && number % 100 < 20 ? 2 : cases[(number % 10 < 5) ? number % 10 : 5]];
        }
    }
}