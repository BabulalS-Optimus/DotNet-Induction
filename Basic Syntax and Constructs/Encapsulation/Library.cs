using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class Library
    {
        //attributes
        private static Book[] books = new Book[1000];
        private static int bookCount = 0;

        //method to add a new book in the library
        static public void AddNewBook(int bookId, string bookName, string author, int edition, string category)
        {
            books[bookCount] = new Book(bookId, bookName, author,  edition, category);
            bookCount++;
        }
        
        //method to search a book with a title
        static public int SearchBook(string title)
        {
            int bookNo = -1;
            int result = -1;

            //call to a method to search the bookID for the book title
            bookNo = FindBookName(title);
            
            if (bookNo != -1)
            {
                //book found
                result = books[bookNo].BookID;
            }
            else
            {
                //when there is no book with the same title
                Console.WriteLine("There is no such book with title {0} ", title);
            }
            return result; //returning the book ID
        }

        //method to search a book from the array with the specified title
        private static int FindBookName(string title)
        {
            int bookNo = -1;
            for (int i = 0; i < bookCount; i++)
            {
                if (books[i].BookName.Contains(title))
                {
                    bookNo = i;
                }
            }
            return bookNo;
        }


        //method to issue a book to a user 
        static public void IssueBook(int bookID, int userID)
        {
            int bookNo = -1;
            bookNo = FindBookID(bookID);
            if (bookNo != -1)
            {
                //updating the status of the book to issued by calling a method of Book class
                if (books[bookNo].IsIssued)
                {
                    Console.Write("This book is already issued to someone...!!!");
                }
                else
                {
                    books[bookNo].UpdateIssued(userID);

                    ///the issue details are stored in a file with BookID, UserID, IssueDate
                    ///here comes the code to store the details 
                }
            }
            else
            {
                Console.WriteLine("There is no such book with bookID {0} ", bookID);
            }


        }

        //method to return a book
        internal static void ReturnBook(int bookID)
        {
            int bookNo = FindBookID(bookID);
            if (bookNo != -1)
            {
                //returning the book by calling a method of Book class
                if (books[bookNo].IsIssued)
                {
                    books[bookNo].ReturnBook();

                    ///the issue details are updated in a file where ReturnDate is set
                }
                else
                {
                    Console.WriteLine("This book is not issued to any user..!!!!");
                }
            }
            else
            {
                Console.WriteLine("There is no such book with bookID {0} ", bookID);
            }

        }
        //method to find the index of book with the specified BookID
        private static int FindBookID(int bookID)
        {
            int bookNo = -1;
            for (int i = 0; i < bookCount; i++)
            {
                if (books[i].BookID == bookID)
                {
                    bookNo = i;
                }
            }
            return bookNo;
        }

        //method to see the book issue history
        public void ShowBookIssueHistory(int bookID)
        {
            //this prints the history of book issues from the file with BookID
            ///here comes the code to read the database or file which stores the history of books issued from the library
            ///the records for the specified books is fetched and displayed here.
        }


        //method to see the user issue history
        public void ShowUserIssueHistory(int userID)
        {
            //this prints the history of book issues from the file with UserID
            ///here comes the code to read the database or file which stores the history of books issued from the library
            ///the records for the specified user is fetched and displayed here.
        }


    }
}
