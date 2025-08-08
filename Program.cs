using System;
using System.Collections.Generic;
using LibraryManagementSystem.Models;
using LibraryManagementSystem.Interfaces;
using LibraryManagementSystem.Transactions;
using LibraryManagementSystem.Services;
using LibraryManagementSystem.Core;
using LibraryManagementSystem.Utils;

namespace LibraryManagementSystem
{
    class Program
    {
        static void RunExercise1()
        {
            var book = new Book
            {
                ISBN = "111",
                Title = "C# OOP",
                Author = "John Smith",
                Year = 2023,
                CopiesAvailable = 5
            };
            book.DisplayInfo();
        }

        static void RunExercise2()
        {
            var member = new Member { MemberID = "M01", Name = "Alice", Email = "alice@example.com" };
            var premium = new PremiumMember
            {
                MemberID = "M02",
                Name = "Bob",
                Email = "bob@example.com",
                MembershipExpiry = DateTime.Now.AddYears(1),
                MaxBooksAllowed = 10
            };
            member.DisplayInfo();
            premium.DisplayInfo();
        }

        static void RunExercise3()
        {
            var member = new Member { Name = "Charlie" };
            var book = new Book { Title = "C# Advanced" };
            var borrow = new BorrowTransaction
            {
                Member = member,
                TransactionID = "T001",
                TransactionDate = DateTime.Now,
                BookBorrowed = book
            };
            var ret = new ReturnTransaction
            {
                Member = member,
                TransactionID = "T002",
                TransactionDate = DateTime.Now,
                BookReturned = book
            };
            borrow.Execute();
            ret.Execute();
        }

        static void RunExercise4()
        {
            var member = new Member { Name = "Dana" };
            var book = new Book { Title = "Design Patterns" };
            var transactions = new List<Transaction>
            {
                new BorrowTransaction { Member = member, BookBorrowed = book },
                new ReturnTransaction { Member = member, BookReturned = book }
            };
            foreach (var tx in transactions)
                tx.Execute();
        }

        static void RunExercise5()
        {
            var member = new Member { Name = "Eve" };
            var book = new Book { Title = "Clean Code" };
            IPrintable printableBook = book;
            IPrintable printableMember = member;
            printableBook.PrintDetails();
            printableMember.PrintDetails();

            IMemberActions actionMember = member;
            actionMember.BorrowBook(book);
            actionMember.ReturnBook(book);
        }

        static void RunExercise6()
        {
            var bookList = new List<Book>
            {
                new Book { Title = "Book A" },
                new Book { Title = "Book B" }
            };
            var lib1 = new Library();
            var lib2 = new Library("My Library", bookList);
            var lib3 = new Library(lib2);

            lib1.DisplayLibraryInfo();
            lib2.DisplayLibraryInfo();
            lib3.DisplayLibraryInfo();
        }

        static void RunExercise7()
        {
            var notify = new NotificationService();
            notify.SendNotification("Hello");
            notify.SendNotification("Hello", "user@example.com");
            notify.SendNotification("Hello", new List<string> { "a@example.com", "b@example.com" });

            var adv = new AdvancedNotificationService();
            adv.SendNotification("Urgent message");
        }

        static void RunExercise8()
        {
            var member = new Member { Name = "Frank" };
            var card = new LibraryCard("CARD001", member);
            Console.WriteLine($"Issued: {card.IssueDate}");
            card.RenewCard();
            Console.WriteLine($"Renewed: {card.IssueDate}");
        }

        static void RunExercise9()
        {
            var bc1 = new BookClass { ISBN = "123", Title = "A", Author = "X" };
            var bc2 = new BookClass { ISBN = "123", Title = "A", Author = "X" };
            Console.WriteLine("BookClass ==: " + (bc1 == bc2)); // false

            var br1 = new BookRecord("123", "A", "X");
            var br2 = new BookRecord("123", "A", "X");
            Console.WriteLine("BookRecord ==: " + (br1 == br2)); // true

            var br3 = br1 with { Title = "B" };
            Console.WriteLine("Modified Record: " + br3);
        }

        static void RunExercise10()
        {
            var book = new Book { Title = "Events in C#" };
            var member = new Member { Name = "Grace" };
            var library = new Library();

            var notify = new NotificationService();
            var adv = new AdvancedNotificationService();

            library.OnBookBorrowed += (b, m) => notify.SendNotification($"[Notify] {m.Name} borrowed {b.Title}");
            library.OnBookBorrowed += (b, m) => adv.SendNotification($"[AdvNotify] {m.Name} borrowed {b.Title}");

            library.BorrowBook(book, member);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Choose Exercise (1-10): ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1": RunExercise1(); break;
                case "2": RunExercise2(); break;
                case "3": RunExercise3(); break;
                case "4": RunExercise4(); break;
                case "5": RunExercise5(); break;
                case "6": RunExercise6(); break;
                case "7": RunExercise7(); break;
                case "8": RunExercise8(); break;
                case "9": RunExercise9(); break;
                case "10": RunExercise10(); break;
                default: Console.WriteLine("Invalid choice"); break;
            }
        }
    }
}
