/*using CommunityToolkit.Mvvm.Input;
using Laboratory2.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratory2.ViewModel
{
    public class DateViewModel : INotifyPropertyChanged
    {
        private string _ageText;
        private string _westernHoroscope;
        private string _chineseHoroscope;
        private string _happyBirthday;
        private Person _user = new Person();
        public DateViewModel()
        {
            DefaultText();
            BCommand = new RelayCommand(UpdateDateInfo, CanExecute);

        }

        public DateTime? SelectedDate
        {
            get => _user.BirthDate;
            set
            {
                if (_user.BirthDate != value)
                {
                    _user.BirthDate = value;
                    UpdateCanExecute();
                    OnPropertyChanged(nameof(SelectedDate));
                }
            }
        }

        public string AgeText
        {
            get => _ageText;
            set
            {
                _ageText = value;
                OnPropertyChanged(nameof(AgeText));
            }
        }

        public string WesternHoroscope
        {
            get => _westernHoroscope;
            set
            {
                _westernHoroscope = value;
                OnPropertyChanged(nameof(WesternHoroscope));
            }
        }

        public string ChineseHoroscope
        {
            get => _chineseHoroscope;
            set
            {
                _chineseHoroscope = value;
                OnPropertyChanged(nameof(ChineseHoroscope));
            }
        }

        public string HappyBirthday
        {
            get => _happyBirthday;
            set
            {
                _happyBirthday = value;
                OnPropertyChanged(nameof(HappyBirthday));
            }
        }

        public RelayCommand BCommand { get; }

        public void DefaultText()
        {
            AgeText = "Ваш вік:";
            WesternHoroscope = "Ваш знак західного гороскопу:";
            ChineseHoroscope = "Ваш знак китайського гороскопу:";
            HappyBirthday = "";
        }
        private void UpdateDateInfo()
        {
            DateTime birthDate = SelectedDate.Value;
            DateTime today = DateTime.Today;

            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
                age--;

            if (age < 0 || age > 135)
            {
                MessageBox.Show("Неправильний вік. Перевірте дату народження.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                DefaultText();
                return;
            }

            AgeText = $"Ваш вік: {age}";
            WesternHoroscope = $"Ваш знак західного гороскопу: {GetWesternZodiac(birthDate)}";
            ChineseHoroscope = $"Ваш знак китайського гороскопу: {GetChineseZodiac(birthDate.Year)}";

            if (birthDate.Month == today.Month && birthDate.Day == today.Day)
                HappyBirthday = "З днем народження!";
            else
                HappyBirthday = "";
        }

        private bool CanExecute()
        {
            return SelectedDate.HasValue;
        }

        private void UpdateCanExecute()
        {
            BCommand.NotifyCanExecuteChanged();
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}

*/