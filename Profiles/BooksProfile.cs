using AutoMapper;
using MyApplicationApi.Dtos;
using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Profiles
{
    public class BooksProfile : Profile
    {
        public BooksProfile()
        {
            CreateMap<Book, BookReadDTO>();
            CreateMap<BookCreationDTO, Book>();
        }
    }
}
