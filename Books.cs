﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AHBC_2019_Midterm_JulyBC
{
   public class Books
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public bool IsCheckedOut { get; set; }
        public DateTime ReturnDate { get; set; }

        public Books(string title, string author, bool status, DateTime returnDate)
        {
            Title = title;
            Author = author;
            IsCheckedOut = status;
            ReturnDate = returnDate;
        }
        
    }
}