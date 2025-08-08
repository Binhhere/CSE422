using System;
using LibraryManagementSystem.Interfaces; 

namespace LibraryManagementSystem.Models
{
    public class Book : IPrintable
    {
        public string ISBN { get; set; } = "";
        public string Title { get; set; } = "";
        public string Author { get; set; } = "";

        private int year;
        public int Year
        {
            get => year;
            set => year = value < 0 ? 0 : value;
        }

        private int copiesAvailable;
        public int CopiesAvailable
        {
            get => copiesAvailable;
            set => copiesAvailable = value < 0 ? 0 : value;
        }

        public void DisplayInfo()
        {
            Console.WriteLine($"ISBN: {ISBN}, Title: {Title}, Author: {Author}, Year: {Year}, Copies: {CopiesAvailable}");
        }

        public void PrintDetails()
        {
            DisplayInfo();
        }
    }
}
