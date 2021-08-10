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
using System.Windows.Shapes;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary; //Print to Binary file
using System.Runtime.Serialization.Formatters.Soap; //Print to XML
using System.Runtime.Serialization.Json; //Print to JSon

namespace Week6Day1Ex1And2
{
    /// <summary>
    /// Interaction logic for _2ndWindow.xaml
    /// </summary>
    public partial class _2ndWindow : Window
    {
        public _2ndWindow()
        {
            InitializeComponent();
            ListofBooks.BookList = new List<Books>();

            
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrEmpty(txtID.Text) && !string.IsNullOrWhiteSpace(txtBookTitle.Text)
                && !string.IsNullOrWhiteSpace(txtAuthor.Text) && !string.IsNullOrEmpty(dpAdded.SelectedDate.Value.ToString()))
            {
                int id = Convert.ToInt32(txtID.Text);
                string cat = ((ComboBoxItem)comboCategory.SelectedItem).Content.ToString();
                string btitle = txtBookTitle.Text;
                string aname = txtAuthor.Text;
                string dateadded = dpAdded.SelectedDate.Value.Date.ToShortDateString();
                Books newBook = new Books(id, cat, btitle, aname, dateadded);

                ListofBooks.BookList.Add(newBook);

                MessageBox.Show("A new book has been added to the library");
            }
            RefreshList();
        }
        private void RefreshList()
        {
            txtID.Clear();
            txtBookTitle.Clear();
            txtAuthor.Clear();
            dpAdded.SelectedDate = null;
        }

        private void btnJSON_Click(object sender, RoutedEventArgs e)
        {
            Books obj = new Books();
            obj.ID = Convert.ToInt32(txtID.Text);
            obj.Categories = comboCategory.Text;
            obj.BookTitle = txtBookTitle.Text;
            obj.AuthorName = txtAuthor.Text;
            obj.DateAdded = dpAdded.SelectedDate.Value.Date.ToShortDateString();

            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType());
            FileStream jsonBuffer = File.Create(@"C:\Assignment\HungJsonData.txt");
            jsonSerializer.WriteObject(jsonBuffer, obj);
            jsonBuffer.Close();

            MessageBox.Show("Your book has been serialized using JSon, please Deserialized");

            
        }

        private void btnDeJSon_Click(object sender, RoutedEventArgs e)
        {
            DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(typeof(Books));
            FileStream jsonBufferred = File.OpenRead(@"C:\Assignment\HungJsonData.txt");
            Books jsonobj = (Books)jsonSerializer.ReadObject(jsonBufferred);
            jsonBufferred.Close();

            lblDesJson.Content = "Book ID: " + jsonobj.ID + " " + "Cateogry: " + jsonobj.Categories + " " + "Book Title: " + jsonobj.BookTitle
                + " " + "Book Author: " + jsonobj.AuthorName + " " + "Date Inserted: " + jsonobj.DateAdded;

            MessageBox.Show("Your book has been Deserialized using JSon, check your folder");
        }

        private void btnBinary_Click(object sender, RoutedEventArgs e)
        {
            Books obj = new Books();
            obj.ID = Convert.ToInt32(txtID.Text);
            obj.Categories = comboCategory.Text;
            obj.BookTitle = txtBookTitle.Text;
            obj.AuthorName = txtAuthor.Text;
            obj.DateAdded = dpAdded.SelectedDate.Value.Date.ToShortDateString();

            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream filestreambin = new FileStream(@"C:\Assignment\HungBinaryData.txt", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            binaryFormatter.Serialize(filestreambin, obj);
            filestreambin.Close();

            MessageBox.Show("Your book has been serialized using Binary, please Deserialized");
        }

        private void btnDeBinary_Click(object sender, RoutedEventArgs e)
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            FileStream fileStreambinde = new FileStream(@"C:\Assignment\HungBinaryData.txt", FileMode.Open, FileAccess.ReadWrite);
            Books obj;
            obj = (Books)binaryFormatter.Deserialize(fileStreambinde);
            fileStreambinde.Close();

            lblDesBin.Content = "Book ID: " + obj.ID + " " + "Cateogry: " + obj.Categories + " " + "Book Title: " + obj.BookTitle
                + " " + "Book Author: " + obj.AuthorName + " " + "Date Inserted: " + obj.DateAdded;

            MessageBox.Show("Your book has been Deserialized using Binary, check your folder");
        }

        private void btnXML_Click(object sender, RoutedEventArgs e)
        {
            Books obj = new Books();
            obj.ID = Convert.ToInt32(txtID.Text);
            obj.Categories = comboCategory.Text;
            obj.BookTitle = txtBookTitle.Text;
            obj.AuthorName = txtAuthor.Text;
            obj.DateAdded = dpAdded.SelectedDate.Value.Date.ToShortDateString();

            SoapFormatter soapFormatter = new SoapFormatter();
            FileStream fileStreamxml = new FileStream(@"C:\Assignment\HungXMLData.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            soapFormatter.Serialize(fileStreamxml, obj);
            fileStreamxml.Close();

            MessageBox.Show("Your book has been serialized using XML, please Deserialized");
        }

        private void btndeXML_Click(object sender, RoutedEventArgs e)
        {
            SoapFormatter soapFormatter = new SoapFormatter();
            FileStream bufferXML = File.OpenRead(@"C:\Assignment\HungXMLData.xml");
            Books objxml = (Books)soapFormatter.Deserialize(bufferXML);
            bufferXML.Close();

            lblDesXML.Content = "Book ID: " + objxml.ID + " " + "Cateogry: " + objxml.Categories + " " + "Book Title: " + objxml.BookTitle
                + " " + "Book Author: " + objxml.AuthorName + " " + "Date Inserted: " + objxml.DateAdded;

            MessageBox.Show("Your book has been Deserialized using XML, check your folder");
        }
    }
}
