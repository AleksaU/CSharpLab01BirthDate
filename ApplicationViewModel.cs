using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Input;

namespace Lab01BirthDateMVVM
{

    internal class ApplicationViewModel : INotifyPropertyChanged
    {


        private DateTime _usersBirthDate = DateTime.Today;
        private int _usersAge;
        private string _westernZodiac;
        private string _chineseZodiac;

        private ICommand _calculateCommand;


        public ICommand SignInCommand => _calculateCommand ?? (_calculateCommand = new RelayCommand<object>(o => Calculations()));

        public string Age
        {
            get
            {
                return $"Your age is {_usersAge}";
            }
        }

        public string WesternZodiac
        {
            get
            {
                return $"Western zodiak: {_westernZodiac}";
            }
            private set
            {
                _westernZodiac = value;
                OnPropertyChanged();
            }
        }



        public string ZodiacChinese
        {
            get
            {
                return $"China zodiak: {_chineseZodiac}";

            }
            private set
            {
                _chineseZodiac = value;
                OnPropertyChanged();
            }
        }
        public DateTime BirthDate
        {
            get { return _usersBirthDate; }
            set
            {
                _usersBirthDate = value;
                try
                {

                    Calculations();
                    OnPropertyChanged();

                    if (IsTodayBirthday())
                        MessageBox.Show("Happy Birthday!");
                }
                catch (Exception)
                {
                    MessageBox.Show("You entered wrong date!");
                }
            }
        }

        internal ApplicationViewModel()
        {
        }
        public void Calculations()
        {


            DateTime today = DateTime.Today;
            int ageNow = today.Year - _usersBirthDate.Year;

            if (today.Day < _usersBirthDate.Day && today.Month == _usersBirthDate.Month || today.Month < _usersBirthDate.Month)
            {
                ageNow--;
            }

            _usersAge = ageNow;
            OnPropertyChanged(nameof(Age)); //nameof - returns value of Age(_age)

            if ((ageNow < 0) || (ageNow > 135))
            {

                MessageBox.Show("Wrong!");

            }

            ZodiacChinese = CalculateChineseZodiac();
            WesternZodiac = CalculateWesternZodiac();

        }

        private string CalculateChineseZodiac()
        {
            switch ((_usersBirthDate.Year - 4) % 12)
            {
                case 0:
                    return "Rat";
                    break;
                case 1:
                    return "Ox";
                    break;
                case 2:
                    return "Tiger";
                    break;
                case 3:
                    return "Rabbit";
                    break;
                case 4:
                    return "Dragon";
                    break;
                case 5:
                    return "Snake";
                    break;
                case 6:
                    return "Horse";
                    break;
                case 7:
                    return "Goat";
                    break;
                case 8:
                    return "Monkey";
                    break;
                case 9:
                    return "Rooster";
                    break;
                case 10:
                    return "Do";
                    break;
                case 11:
                    return "Pig";
                    break;

                default:
                    return " ";
                    break;
            }

        }

        private string CalculateWesternZodiac()
        {
            if (((_usersBirthDate.Month == 3) && (_usersBirthDate.Day >= 21 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 4) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 20)))
            {
                return "Aires";
            }
            if (((_usersBirthDate.Month == 4) && (_usersBirthDate.Day >= 21 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 5) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 21)))
            {
                return "Taurus";
            }

            if (((_usersBirthDate.Month == 5) && (_usersBirthDate.Day >= 21 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 6) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 21)))
            {
                return "Gemini";
            }
            if (((_usersBirthDate.Month == 6) && (_usersBirthDate.Day >= 22 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 7) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 22)))
            {
                return "Cancer";
            }
            if (((_usersBirthDate.Month == 7) && (_usersBirthDate.Day >= 23 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 8) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 22)))
            {
                return "leo";
            }
            if (((_usersBirthDate.Month == 8) && (_usersBirthDate.Day >= 23 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 9) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 21)))
            {
                return "Virgo";
            }
            if (((_usersBirthDate.Month == 9) && (_usersBirthDate.Day >= 22 && _usersBirthDate.Day <= 30)) || ((_usersBirthDate.Month == 10) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 22)))
            {
                return "Libra";
            }
            if (((_usersBirthDate.Month == 10) && (_usersBirthDate.Day >= 23 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 11) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 21)))
            {
                return "Scorpio";
            }
            if (((_usersBirthDate.Month == 11) && (_usersBirthDate.Day >= 22 && _usersBirthDate.Day <= 30)) || ((_usersBirthDate.Month == 12) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 21)))
            {
                return "Sagittarius";
            }
            if (((_usersBirthDate.Month == 12) && (_usersBirthDate.Day >= 22 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 1) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 20)))
            {
                return "Capricorn";
            }
            if (((_usersBirthDate.Month == 1) && (_usersBirthDate.Day >= 21 && _usersBirthDate.Day <= 30)) || ((_usersBirthDate.Month == 2) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 19)))
            {
                return "Aquarius";
            }
            if (((_usersBirthDate.Month == 2) && (_usersBirthDate.Day >= 20 && _usersBirthDate.Day <= 31)) || ((_usersBirthDate.Month == 3) && (_usersBirthDate.Day >= 01 && _usersBirthDate.Day <= 20)))
            {
                return "Pisces";
            }
            else
            {
                return "La";
            }


        }


        private bool IsTodayBirthday()

        {
            return DateTime.Today.DayOfYear == _usersBirthDate.DayOfYear;
        }

        public event PropertyChangedEventHandler PropertyChanged;


        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
   
}
