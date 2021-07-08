using Microsoft.Win32;
using System;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace WPfApplication
{
    /// <summary>
    /// Логика взаимодействия для Window1.xaml
    /// </summary>
    public partial class Photo_window : Window
    {
        public Photo_window()
        {
            InitializeComponent();
        }
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri file_path = new Uri(openFileDialog.FileName);
                show(openFileDialog);
            }
        }        
        public void show_photo(Image img, Uri path)
        {
            img.Source = new BitmapImage(path);
        }
        public void show_photo(Window window, Uri path)
        {
            window.Background = new ImageBrush(new BitmapImage(path));
        }

        public void show (OpenFileDialog openFileDialog)
        {
            StreamReader reader = new StreamReader(openFileDialog.FileName);
            tb.Text = reader.ReadToEnd();
            reader.Close();
        }
        public void show(string path)
        {
            StreamReader reader = new StreamReader(path);
            tb.Text = reader.ReadToEnd();
            reader.Close();
        }

    }
}
        

