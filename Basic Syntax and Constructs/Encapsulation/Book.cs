using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class Book
    {
        //attributes of Book class
        #region PrivateAttributes
        private int bookId;
        private string bookName;
        private string author;
        private int edition;
        private string category;
        private bool isIssued;
        private int issuedTo;
        private DateTime issuedDate;
        #endregion

        #region PublicAttributes
        public int BookID
        {
            get { return bookId; }
            set { bookId = value; }
        }
        public string BookName
        {
            get { return bookName; }
            set { bookName = value; }
        }
        public string Author
        {
            get { return author; }
            set { author = value; }
        }
        public int Edition
        {
            get { return edition; }
            set { edition = value; }
        }

        public string Category
        {
            get { return category; }
            set { category = value; }
        }
        public bool IsIssued
        {
            get { return isIssued; }
            set { isIssued = value; }
        }
        public int IssuedTo
        {
            get { return issuedTo; }
            set { issuedTo = value; }
        }
        public DateTime IssuedDate
        {
            get { return issuedDate; }
            set { issuedDate = value; }
        }
        #endregion

        //constructor to create a new book object
        public Book(int bookId, string bookName, string author, int edition, string category)
        {
            this.bookId = bookId;
            this.bookName = bookName;
            this.author = author;
            this.edition = edition;
            this.category = category;
            this.isIssued = false;
        }

        //method to issue a book
        public void UpdateIssued(int userId)
        {
            //here the book is issued to the specified user and issue status is updated to true
            isIssued = true;
            issuedTo = userId;
            issuedDate = DateTime.Now;
        }

        //method to return a book
        public void ReturnBook()
        {
            //here the book issued status is set to false and book will  be available for issue
            isIssued = false;
        }

        
    }
}
