﻿using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace AHBC_2019_Midterm_JulyBC
{
    class SaveLoad 
    {
        public List<String> BooksStringList { get; set; }
        public List<Book> BooksList { get; set; }

        public void Save(List<Book> bookList) 
        {
            using (var writer = new StreamWriter("./LibrarySaveFile.txt", false))  //  (file location, bool for overwrite[false] or append[true])
            {
                foreach (var item in bookList)
                {
                    string title = item.Title.ToString();
                    string author = item.Author.ToString();
                    string status = item.IsCheckedOut.ToString();
                    string returnDate = item.ReturnDate.ToString();

                    string saveLine = ($"{title}//{author}//{status}//{returnDate}");

                    writer.WriteLine(saveLine);
                }
            }
        }

        public List<Book> Load()  //Probably going to output a list of books
        {
            using (var reader = new StreamReader("./LibrarySaveFile.txt"))
            {
                var entireFile = reader.ReadToEnd();
                var linesArray = entireFile.Split("\r\n");
                List<Book> _BookList = new List<Book>();
                

                string line = reader.ReadLine();


                foreach (var _line in linesArray)
                {
                    string[] bookInfo = _line.Split("//");

                    if (bookInfo.Length == 4)
                    {
                        string title = bookInfo[0];
                        string author = bookInfo[1];
                        bool isCheckedOut = Convert.ToBoolean(bookInfo[2]);
                        DateTime returnDate = Convert.ToDateTime(bookInfo[3]);

                        _BookList.Add(new Book(title, author, isCheckedOut, returnDate));
                    }

                }


                return _BookList;

            }
        }


    }
}
