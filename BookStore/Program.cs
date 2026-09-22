using System;
using System.IO;
using DAL;
static class Program
{
    static void Main(string[] args)
    {
        BookDataAccess dataAccess = new BookDataAccess();
        while (true)
        {
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. View All Books");
            Console.WriteLine("3. Find Book By Id");
            Console.WriteLine("4. Create Backup");
            Console.WriteLine("5. Exit");
            Console.Write("Enter your choice: ");
            int choice = Convert.ToInt32(Console.ReadLine());
           if (choice == 1)
            {
                dataAccess.AddBook();
            }
            else if (choice == 2)
            {
                dataAccess.ViewAllBooks();
            }
            else if (choice == 3)
            {
                dataAccess.FindBookById();
            }
            else if (choice == 4)
            {
                dataAccess.CreateBackup();
            }
            else if (choice == 5)
            {
                break;
            }
            else
            {
                Console.WriteLine("Invalid choice.");
            }
        }
        return;
    }
}