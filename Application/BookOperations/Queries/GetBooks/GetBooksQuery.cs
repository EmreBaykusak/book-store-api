﻿using AutoMapper;
using BookStoreApi.DBOperations;
using Microsoft.EntityFrameworkCore;

namespace BookStoreApi.Application.BookOperations.Queries.GetBooks;

public class GetBooksQuery
{
    private readonly BookStoreDbContext _dbContext;
    private readonly IMapper _mapper;
    public GetBooksQuery(BookStoreDbContext dbContext, IMapper mapper)
    {
        _dbContext = dbContext;
        _mapper = mapper;
    }

    public List<BookViewModel> Handle()
    {
        var bookList = _dbContext.Books.Include(x=> x.Genre).OrderBy(x => x.Id).ToList();

        List<BookViewModel> vm = _mapper.Map<List<BookViewModel>>(bookList);

        return vm;
    }

    public class BookViewModel
    {
        public string Title { get; set; }
        public int PageCount { get; set; }
        public string PublishDate { get; set; }
        public string Genre { get; set; }
    }
}