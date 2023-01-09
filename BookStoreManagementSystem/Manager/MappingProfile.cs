using AutoMapper;
using BookManagement.DBModels;
using BookManagement.Dto;

namespace BookManagement.Manager
{
    public class MappingProfile: Profile
    {
       public MappingProfile()
        {
            CreateMap<BookStoreModelDto, BookStoreModel>().ReverseMap();
        }
    }
}
