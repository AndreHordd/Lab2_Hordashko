using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratory2.Model
{
    class Person
    {
        private string _name;
        private string _surname;
        private string _email;
        private DateTime _dateOfBirth;

        private bool _isAdult;
        private string _sunSign;
        private string _chineseSign;
        private bool _isBirthday;

        public string Name
        {
            get => _name;
            private set => _name = value;
        }

        public string Surname
        {
            get => _surname;
            private set => _surname = value;
        }

        public string Email
        {
            get => _email;
            private set => _email = value;
        }

        public DateTime DateOfBirth
        {
            get => _dateOfBirth;
            private set
            {
                _dateOfBirth = value;
                RecalculateProperties();
            }
        }

        public bool IsAdult => _isAdult;
        public string SunSign => _sunSign;
        public string ChineseSign => _chineseSign;
        public bool IsBirthday => _isBirthday;

       
        public Person(string name, string surname, string email, DateTime dateOfBirth)
        {
            _name = name;
            _surname = surname;
            _email = email;
            _dateOfBirth = dateOfBirth;

            RecalculateProperties();
        }

        public Person(string name, string surname, string email)
            : this(name, surname, email, DateTime.MinValue){}

        public Person(string name, string surname, DateTime dateOfBirth)
            : this(name, surname, string.Empty, dateOfBirth){}


        private void RecalculateProperties()
        {
            _isAdult = CalculateIsAdult();
            _sunSign = CalculateSunSign();
            _chineseSign = CalculateChineseSign();
            _isBirthday = CalculateIsBirthday();
        }

        private bool CalculateIsAdult()
        {
            int age = GetAge(_dateOfBirth);
            return age >= 18;
        }

        private string CalculateSunSign()
        {
            return GetWesternZodiac(_dateOfBirth);
        }

        private string CalculateChineseSign()
        {
            return GetChineseZodiac(_dateOfBirth.Year);
        }

        private bool CalculateIsBirthday()
        {
            DateTime today = DateTime.Today;
            return (today.Month == _dateOfBirth.Month && today.Day == _dateOfBirth.Day);
        }

        private static int GetAge(DateTime birthDate)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - birthDate.Year;
            if (birthDate > today.AddYears(-age))
                age--;
            return age;
        }

        private static string GetWesternZodiac(DateTime date)
        {
            int month = date.Month;
            int day = date.Day;
            if ((month == 3 && day >= 21) || (month == 4 && day <= 19)) return "Овен";
            if ((month == 4 && day >= 20) || (month == 5 && day <= 20)) return "Телець";
            if ((month == 5 && day >= 21) || (month == 6 && day <= 20)) return "Близнюки";
            if ((month == 6 && day >= 21) || (month == 7 && day <= 22)) return "Рак";
            if ((month == 7 && day >= 23) || (month == 8 && day <= 22)) return "Лев";
            if ((month == 8 && day >= 23) || (month == 9 && day <= 22)) return "Діва";
            if ((month == 9 && day >= 23) || (month == 10 && day <= 22)) return "Терези";
            if ((month == 10 && day >= 23) || (month == 11 && day <= 21)) return "Скорпіон";
            if ((month == 11 && day >= 22) || (month == 12 && day <= 21)) return "Стрілець";
            if ((month == 12 && day >= 22) || (month == 1 && day <= 19)) return "Козеріг";
            if ((month == 1 && day >= 20) || (month == 2 && day <= 18)) return "Водолій";
            if ((month == 2 && day >= 19) || (month == 3 && day <= 20)) return "Риби";
            return "";
        }

        private static string GetChineseZodiac(int year)
        {
            string[] animals = {
                "Щур", "Віл", "Тигр", "Кролик", "Дракон",
                "Змія", "Кінь", "Коза", "Мавпа", "Півень",
                "Собака", "Свиня"
            };
            int index = (year - 4) % 12;
            if (index < 0) index += 12;
            return animals[index];
        }

    }
}
