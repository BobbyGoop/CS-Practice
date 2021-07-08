using System;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    public class Student : Human
    {
        public override string position { get; set; } = "Студент"; // Переопределение abstract свойства

        private const int _group = 5938; // бесполезное поле для student
        public static ObservableCollection<Student> SObjects = new ObservableCollection<Student>();

        // Конструкторы 
        public Student() : base()
        {
            _chair = 0;
            SObjects.Add(this);
        }
        // вызывает без параметров, ставит chair в 0 и уходит в base
        public Student(string sname, string name, string fname, DateTime bday) : this()
        {
            this.Name = name;
            this.Surname = sname;
            this.FName = fname;
            this.enter_date = bday;
        }

        public int get_group
        {
            get => _group;
        }

        public override DateTime enter_date
        {
            get => _enterDt;

            set { if (value < new DateTime(2020, 09, 01)) _enterDt = value; }
        }

        public override sealed void year_count(out int res)
        {
            res = (int)(DateTime.Now - enter_date).TotalDays / 365;
        }

        // Тестирование методов
        public override string First()
        {
            return ("Первый метод из Student (child), OVERRIDE");
        }

        public new string Second()
        {
            return ("Второй метод из Student (child), NEW ");
        }


    }
}
