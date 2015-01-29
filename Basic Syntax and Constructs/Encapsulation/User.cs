using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation
{
    class User
    {
        //attributes for a user
        int userID;
        string fullName;
        int age;
        string address;
        string mobile;
        string emailID;

        //constructor to create a new user
        public User(int userID, string fullName, int age, string address, string mobile, string emailID)
        {
            this.userID = userID;
            this.fullName = fullName;
            this.age = age;
            this.address = address;
            this.mobile = mobile;
            this.emailID = emailID;
        }

        //method to search a book 
        public void SearchBook()
        {
            string title = Console.ReadLine();
            int bookID = Library.SearchBook(title);
            if (bookID != -1)
            {
                //ask user to issue the book?
                //if yes then call--> IssueBook method of Library class with the bookID and userID
                Console.Write("Book found!!! \nPress 'Y' to issue the book.");
                string choice = Console.ReadLine();
                if (choice.ToUpper().Equals("Y"))
                {
                    Library.IssueBook(bookID, this.userID);
                }
            }
        }

        //method to issue a book with a known bookID
        public void IssueBook()
        {
            //Issue a book using bookID
            //call IssueBook method of Library class with bookID and userID
            int bookID;
            Console.Write("Please enter the book ID to issue. (NOTE :- If dont know the book ID, please search the book with its title.) ");
            bookID = Convert.ToInt16(Console.ReadLine());
            Library.IssueBook(bookID, this.userID);
        }

        //return a book
        public void ReturnBook()
        {
            //Return a book 
            //call ReturnBook method of Library class with bookID 
            int bookID;
            Console.Write("Please enter the book ID to return : ");
            bookID = Convert.ToInt16(Console.ReadLine());
            Library.ReturnBook(bookID);
        }

    }
}
