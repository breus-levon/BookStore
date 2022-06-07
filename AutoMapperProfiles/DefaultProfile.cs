using AutoMapper;
using BookStore.Database.Entities;
using BookStore.ViewModels;

namespace BookStore.AutoMapperProfiles
{
    public class DefaultProfile : Profile
    {
        public DefaultProfile()
        {
            CreateMap<AddBookRequest, Book>();
            CreateMap<Book, GetBooksRequest>();

            CreateMap<EditAuthorRequest, Author>();
            CreateMap<EditBookRequest, Book>();
            CreateMap<UpdateBookRequest, Book>();
        }
    }
}
