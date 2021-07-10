using System;
using System.IO;
using System.Windows;
using System.Windows.Media;
using Microsoft.Win32;
using ClassLibrary;
using WPfApplication;

namespace FirstWpfApp
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();   
        }

        Student stud1 = new Student() { Surname = "Свеженин", Name = "Иван", FName = "Денисович"};
        Student stud2 = new Student("Сидоров", "Максим", "Сергеевич", new DateTime(2008, 1, 3));
        Student stud3 = new Student("Версальских", "Елизавета", "Петровна", new DateTime(2009, 10, 25));
        Student stud4 = new Student("Иванов", "Вадим", "Викторович", new DateTime(1998, 5, 16));
        Student stud5 = new Student("Петров", "Александр", "Иванович", new DateTime(1960, 6, 19));
        Teacher tchr1 = new Teacher() { Name = "tchr1" };
        Teacher obj = new Teacher("Сидоров", "Петр", "Вячеславович", new DateTime(2008, 1, 3));
        
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            output.Clear();           
            string sname = input.Text;
            string response = "";
            foreach (Student item in Student.SObjects)
                {
                if (item.Surname == sname) 
                {
                    response = "Данные студента: " + item.Surname + " " + item.Name + " " + item.FName + " " + item.enter_date.ToShortDateString();                
                }
            }
            response = response != "" ? response : "Такого студента не существует";
            output.Text += response + "\n";

            // ВЫЗОВ СТАТИЧЕСКОГО КОНСТРУКТОРА
            search_btn.BorderBrush = new SolidColorBrush(BGColours.bordercolor);
            search_btn.Background = new SolidColorBrush(BGColours.backcolor);
        }
        public class BGColours
        {
            public static readonly Color bordercolor;
            public static readonly Color backcolor;
            static BGColours()
            {
                bordercolor = Colors.Green;
                backcolor = Colors.LightGreen;
            }
        }

        private void T_CheckBox_Click(object sender, RoutedEventArgs e)
        {
            if (T_CheckBox.IsChecked == true)
            {
                T_CheckBox.Opacity = 1;
                TButton.IsEnabled = true;          
            }
            else 
            {
                T_CheckBox.Opacity = 0.4;
                TButton.IsEnabled = false;
            }
        }

        // ВЫЗОВ ЦЕПОЧКИ КОНСТРУКТОРОВ (СМ. ФАЙЛ КЛАССА)

        private void TButton_Click(object sender, RoutedEventArgs e)
        {
            /*
            //  Разница проявляется в случае полиморфизма. Если вы работаете с экземпляром класса-наследника
            //  через его родительский класс, то в случае, если вы будете вызывать переопределенный виртуальный 
            //  метод (override), то будет вызвана его реализация из наследника, а если перекрытый (new), 
            //  то будет вызван метод базового класса. Нагляднее будет увидеть на примере:
            //Human exmp = new Human();

            
            Human example = new Student() { Name = "example" }; // UPCASTING
            Student example2 = (Student)example; // DOWNCASTING, не работает конструктор потому что это ссылка
            //example2.Name = "example2";
            output.Text += "Преобразование типов: UPCASTING: Human example = new Student() \n";
            output.Text += example.First() + "\n";
            output.Text += example.Second();
            output.Text += "\nПреобразование типов: DOWNCASTING: Student example2 = (Student)example \n";
            output.Text += example2.First() + "\n";
            output.Text += example2.Second();
              output.Text += "\n\n " + Student.SObjects.Count + " " + Teacher.TObjects.Count + "\n";  
            */



            foreach (Teacher item in Teacher.TObjects)
            {
                output.Text += $"Должность: {item.position}, " + item.Surname + " " + item.Name + " " + item.FName + " " +
                                " " + item.ID_info + " " + item.enter_date.ToShortDateString()  + "\n";
            }
            foreach (Student item in Student.SObjects)
            {
                output.Text += $"Должность: {item.position}, " +  item.Surname + " " + item.Name + " " + item.FName + " "
                    + item.enter_date.ToShortDateString() + item.ToString() + "\n";
            }
        }
        private void add_btn_Click(object sender, RoutedEventArgs e)
        {
            AddWindow info_window = new AddWindow();
            info_window.Owner = this;
            info_window.Show();
        }

        private void Photo_btn_Click(object sender, RoutedEventArgs e)
        {
            Photo_window wind = new Photo_window();
            wind.Owner = this;
            wind.Show();
        }
        // СОХРАНЕНИЯ ФАЙЛА, МЕТОДЫ WRITETOFILE
        public void WriteToFile(string response, string all_files = "Все файлы (*.*)|*.*")
        {
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = $"Текстовый файл (*.txt)|*.txt|{all_files}";
            if (file.ShowDialog() == true)
            {
                StreamWriter writer = new StreamWriter(file.FileName);
                writer.WriteLine(response);
                writer.Close();
            }
        }
        public void WriteToFile( string response, SaveFileDialog save_file)
        {
            StreamWriter writer = new StreamWriter(save_file.FileName);
            writer.WriteLine(response);
            writer.Close();
        }

        private void Save_btn_Click(object sender, RoutedEventArgs e)
        {
            string resp = "";
            foreach (Student item in Student.SObjects)
            {
                item.year_count(out int age);
                resp += " Должность: студент, " + item.Surname + " " + item.Name + " " + item.FName + " " + age.ToString() + "\n";
            }
            foreach (Teacher item in Teacher.TObjects)
            {
                item.year_count(out int age);
                resp += " Должность: преподаватель, " + item.Surname + " " + item.Name + " " + item.FName + " " + age.ToString() + "\n";
            }
            SaveFileDialog file = new SaveFileDialog();
            file.Filter = "Текстовый файл (*.txt)|*.txt|RTF файл (*.rtf)|*.rtf|Все файлы (*.*)|*.*";
            if (file.ShowDialog() == true)
            {
                WriteToFile(resp, file);// второй вариант перегрузки
                //WriteToFile(resp); // первый вариант перегрузки, УБРАТЬ УСЛОВИЕ!!!!
                MessageBox.Show("Файл успешно сохранен!", "Файл", MessageBoxButton.OK, MessageBoxImage.Asterisk, MessageBoxResult.OK);
            }
        }
    }
}