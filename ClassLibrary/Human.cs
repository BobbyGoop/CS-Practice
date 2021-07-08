using System;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    public abstract class Human
    {
        // если abstract свойство - обязательна реализация get и set
        public string Surname { get; set; }
        public string Name { get; set; }
        public string FName { get; set; }
        public abstract string position { get; set; }

        private protected static int _chair;
        private protected DateTime _enterDt;

        public Human()
        {
            Name = "(Имя отсутствует)";
            Surname = "(Фамилия отсутствует)";
            FName = "(Отчество отсутствует)";
            //position = "(Должность отсутствует)";
        }

        public int get_chair
        {
            get => _chair;
        }

        public virtual DateTime enter_date
        {
            get => _enterDt;
            set
            {
                if (value < DateTime.Now) _enterDt = value;
            }
        }

        public virtual void year_count(out int res)
        {
            res = DateTime.UtcNow.Year - enter_date.Year - 1 + (((DateTime.UtcNow.Month > enter_date.Month) ||
            ((DateTime.UtcNow.Month == enter_date.Month) && (DateTime.UtcNow.Day >= enter_date.Day))) ? 1 : 0);
        }

        // Тестирование new и override
        public virtual string First()
        {
            return ("Первый метод из Human (base), VIRTUAL \n");
        }

        public virtual string Second()
        {
            return ("Второй метод из Human (base), VIRTUAL \n");
        }
        public override string ToString()
        {
            return " ToString() Теперь не работает";
        }
    }
}
