using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //Print to Binary file
using System.Runtime.Serialization.Formatters.Soap; //Print to XML
using System.Runtime.Serialization.Json; //Print to JSon

namespace Week6Day1Ex1And2
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>

    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void addNewB_Click(object sender, RoutedEventArgs e)
        {
            _2ndWindow addNewBook = new _2ndWindow();
            addNewBook.ShowDialog();
        }

        private void Display_Click(object sender, RoutedEventArgs e)
        {
            ShowData();
        }

        private void ShowData()
        {
            myLibrary.ItemsSource = null;
            myLibrary.ItemsSource = ListofBooks.BookList;
        }

    }
}
