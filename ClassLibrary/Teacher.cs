using System;
using System.Collections.ObjectModel;

namespace ClassLibrary
{
    public class Teacher : Human
    {
        public override string position { get; set; } = "Преподаватель";
        public static ObservableCollection<Teacher> TObjects = new ObservableCollection<Teacher>();
        public Teacher() : base()
        {
            _tchID = "";
            _chair = 53;
            TObjects.Add(this);
        }
        public Teacher(string sname, string name, string fname, DateTime bday) : this()
        {
            this.Name = name;
            this.Surname = sname;
            this.FName = fname;
            this.enter_date = bday;
        }
        private string _tchID; // Бесполезное поле для Teacher
        public string ID_info
        {
            get => _tchID;
            set
            {

                if (value.Length == 5)
                {
                    if (char.IsLower(value[0]))
                        _tchID = value[0].ToString().ToUpper() + value.Substring(1);
                    else _tchID = value;
                }
                else _tchID = "(ID отсутствует)";
            }
        }

        public override void year_count(out int res)
        {
            res = enter_date.Year;
        }
    }
}
