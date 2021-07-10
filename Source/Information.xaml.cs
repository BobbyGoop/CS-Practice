using System.Windows;
using System.Windows.Controls;
using ClassLibrary;

namespace WPfApplication
{
    /// <summary>
    /// Логика взаимодействия для Information.xaml
    /// </summary>
    public partial class AddWindow : Window
    {
        public AddWindow()
        {       
            InitializeComponent();
        }

        private void enter_btn_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (st_check.IsChecked == true)
                {
                    new Student
                    (fam_box.Text,
                    name_box.Text,
                    fname_box.Text,
                    (System.DateTime)DatePicker.SelectedDate);
                    ListbOX.ItemsSource = Student.SObjects;
                }
                else if (tchr_check.IsChecked == true)
                {
                    new Teacher
                    (fam_box.Text,
                    name_box.Text,
                    fname_box.Text,
                    (System.DateTime)DatePicker.SelectedDate);

                    ListbOX.ItemsSource = Teacher.TObjects;
                }
            }
            catch (System.InvalidOperationException)
            {
                MessageBox.Show("Одно или несколько полей пустые", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
         
        }

        private void clear_click(object sender, RoutedEventArgs e)
        {
            // ....
        }
    }
}
