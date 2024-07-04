using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ienumerable_Vs_IQueryable
{
    class Program
    {
        static void Main(string[] args)
        {
            //normal case to read books from DB
            Library_DBEntities DB = new Library_DBEntities();
            var list = DB.Libraries.ToList();
            foreach (var book in list)
            {
                Console.WriteLine($"Book name is : {book.BookName} Color is : {book.BookColor} Writer is : {book.BookWriter}");
            }

            //IQuryable Case : 
            IQueryable<Library> list1 = DB.Libraries.Where(n => n.BookColor == "Blue" && n.BookName== "The Housemaid Is Watching");
            //in sql :
            //SELECT * FROM Books AS [n] WHERE [n].[BookColor] == 'Blue' AND [n].[BookName] == 'The Housemaid Is Watching'

            //IEnumerable Case :
            IEnumerable<Library> Book = DB.Libraries.AsEnumerable().Where(b=>b.BookColor == "Blue" && b.BookName == 'The Housemaid Is Watching');
            //in sql :
            //SELECT* FROM Books AS[n]

            Console.ReadKey();
        }
    }
}
