﻿using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using WebApi.Business.Application.BookOperations.CreateBook;
using WebApi.Business.Application.BookOperations.DeleteBook;
using WebApi.Business.Application.BookOperations.GetBookDetail;
using WebApi.Business.Application.BookOperations.GetBooks;
using WebApi.Business.Application.BookOperations.UpdateBook;
using WebApi.Business.Validators.Book;
using WebApi.Data.DBOperations;
using WebApi.Models.BookModels;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]s")]
    public class BookController : ControllerBase
    {
        private readonly BookStoreDbContext _context;
        private readonly IMapper _mapper;
        public BookController(BookStoreDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult GetBooks()
        {
            GetBooksQuery query = new GetBooksQuery(_context, _mapper);
            var result = query.Handle();
            return Ok(result);

        }


        [HttpGet("{id}")]
        public IActionResult GetBookById(int id)
        {
            BookDetailViewModel result;
            GetByIdQuery query = new GetByIdQuery(_context, _mapper);
            GetBookByIdValidator validator = new GetBookByIdValidator();
            query.BookId = id;
            validator.ValidateAndThrow(query);
            result = query.Handle();
            return Ok(result);

        }


        [HttpPost]
        public IActionResult AddBook([FromBody] CreateBookModel newBook)
        {
            CreateBookCommand command = new CreateBookCommand(_context, _mapper);
            command.Model = newBook;
            command.Handle();
            return Ok("Book created successfully!");
        }

        [HttpPut("{id}")]
        public IActionResult UpdateBook(int id, [FromBody] UpdateBookModel updatedBook)
        {
            UpdateBookCommand command = new UpdateBookCommand(_context);
            command.Model = updatedBook;
            command.BookId = id;
            UpdateBookValidator validator = new UpdateBookValidator();
            validator.ValidateAndThrow(command);

            command.Handle();
            return Ok("Book updated successfully!");

        }

        [HttpDelete("{id}")]
        public IActionResult DeleteBook(int id)
        {
            DeleteBookCommand command = new DeleteBookCommand(_context);
            command.BookId = id;
            DeleteBookValidator validator = new DeleteBookValidator();
            validator.ValidateAndThrow(command);
            command.Handle();
            return Ok("Book deleted successfully!");
        }


    }
}