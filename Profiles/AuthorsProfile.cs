using AutoMapper;
using MyApplicationApi.Dtos;
using MyApplicationApi.Helpers;
using MyApplicationApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyApplicationApi.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {
            //Mapping Objects for reading data 
            CreateMap<Author, AuthorReadDTO>()
                .ForMember
                (
                    dest => dest.Name,
                    opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember
                (
                    dest => dest.Age,
                    opt => opt.MapFrom(src => src.DOB.GetCurrentAge())
                )
                //.ForMember(dest => dest.Name, opt => opt.Ignore())
                ;

            //Mapping Objects to perform insert operation
            CreateMap<AuthorCreationDTO, Author>();
        }

    }
}
