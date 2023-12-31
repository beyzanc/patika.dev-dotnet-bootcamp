﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Data.DBOperations;

namespace WebApi.Business.BookOperations.DeleteBook
{
    public class DeleteBookCommand
    {
        private readonly BookStoreDbContext _dbContext;
        public int BookId { get; set; }
        public DeleteBookCommand(BookStoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Handle()
        {
            var book = _dbContext.Books.SingleOrDefault(x => x.Id == BookId);
            
            if (book is null)
            {
                throw new InvalidOperationException("The book is not exist.");
            
            }
            
            _dbContext.Books.Remove(book);
            _dbContext.SaveChanges();
        }
    }
}