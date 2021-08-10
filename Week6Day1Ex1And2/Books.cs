using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using System.Windows.Input;
using System.Runtime.Serialization.Formatters.Binary; //Print to Binary file
using System.Runtime.Serialization.Formatters.Soap; //Print to XML
using System.Runtime.Serialization.Json; //Print to JSon

namespace Week6Day1Ex1And2
{
    [Serializable]
    struct Books 
    {
        public int ID { get; set; }
        public string Categories { get; set; }
        public string BookTitle { get; set; }
        public string AuthorName { get; set; }
        public string DateAdded { get; set; }

        public Books(int id, string cat, string btitle, string aname, string dateadded)
        {
            this.ID = id;
            this.Categories = cat;
            this.BookTitle = btitle;
            this.AuthorName = aname;
            this.DateAdded = dateadded;
            
        }

    }
    static class ListofBooks
    {
        public static List<Books> BookList;
    }
}
