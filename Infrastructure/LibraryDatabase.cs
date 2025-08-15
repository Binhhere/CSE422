using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.InMemory;
using System;
using System.Collections.Generic;

namespace Infrastructure
{
    public class LibraryDatabase
    {
        private static LibraryDatabase _instance;
        private static readonly object _lock = new(); // thread-safe

        public IBookRepository BookRepository { get; private set; }
        public IReaderRepository ReaderRepository { get; private set; }

        public List<IDocument> Documents { get; set; } = new();
        public List<IDocument> Templates { get; set; } = new();

        private LibraryDatabase()
        {
            BookRepository = new BookRepository();
            ReaderRepository = new ReaderRepository();
        }

        public static LibraryDatabase Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_lock)
                    {
                        if (_instance == null)
                        {
                            _instance = new LibraryDatabase();
                        }
                    }
                }
                return _instance;
            }
        }
    }
}
