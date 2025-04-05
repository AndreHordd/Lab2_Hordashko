using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Laboratory2.Model;
using System;
using System.Threading.Tasks;
using System.Windows;

namespace Laboratory2.ViewModel
{
    public class DateViewModel : ObservableObject
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime? _selectedDate;
        private string _resultText;
        private Person _person;

        public DateViewModel()
        {
            ResultText = "";
            ProceedCommand = new RelayCommand(UpdateDateInfo, CanExecute);
        }

        public string Name
        {
            get => _name;
            set
            {
                SetProperty(ref _name, value);
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public string Surname
        {
            get => _surname;
            set
            {
                SetProperty(ref _surname, value);
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public string Email
        {
            get => _email;
            set
            {
                SetProperty(ref _email, value);
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public DateTime? SelectedDate
        {
            get => _selectedDate;
            set
            {
                SetProperty(ref _selectedDate, value);
                ProceedCommand.NotifyCanExecuteChanged();
            }
        }

        public string ResultText
        {
            get => _resultText;
            set => SetProperty(ref _resultText, value);
        }

        public RelayCommand ProceedCommand { get; }

        private bool CanExecute()
        {
            return !string.IsNullOrWhiteSpace(Name) &&
                   !string.IsNullOrWhiteSpace(Surname) &&
                   !string.IsNullOrWhiteSpace(Email) &&
                   SelectedDate.HasValue;
        }

        private async void UpdateDateInfo()
        {
            if (!SelectedDate.HasValue)
            {
                MessageBox.Show("Введіть дату народження", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            DateTime selectedDate = SelectedDate.Value;

            try
            {
                _person = new Person(Name, Surname, Email, selectedDate);

                await Task.Delay(1000);

                ResultText = $"Ім'я: {_person.Name}\n" +
                             $"Прізвище: {_person.Surname}\n" +
                             $"Електронна пошта: {_person.Email}\n" +
                             $"Дата народження: {_person.DateOfBirth:d}\n" +
                             $"Дорослий: {_person.IsAdult}\n" +
                             $"Знак зодіаку (західний): {_person.SunSign}\n" +
                             $"Китайський знак: {_person.ChineseSign}\n" +
                             $"День народження: {_person.IsBirthday}";
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }


        private int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
                age--;
            return age;
        }
    }
}
