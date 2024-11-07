using System;
using AutoMapper;
using LibraryMVC.Entity;
using LibraryMVC.Enums;
using LibraryMVC.Models;

namespace LibraryMVC.MappingProfile
{
    public class LibraryItemProfile : Profile
    {
        public LibraryItemProfile()
        {
            CreateMap<LibraryItemModel, LibraryItem>().ReverseMap()
            .ForMember(dest => dest.Type, opt => opt.MapFrom(src => Enum.Parse<ItemType>(src.GetType().Name)))
            .ForMember(dest => dest.NumberOfPages, opt => opt.MapFrom(src => (src as Book).NumberOfPages))
            .ForMember(dest => dest.Runtime, opt => opt.MapFrom(src => (src as Dvd).Runtime));
            CreateMap<LibraryItemModel, Book>().ReverseMap().ForMember(dest => dest.Type, opt => opt.MapFrom(src => ItemType.Book));
            CreateMap<LibraryItemModel, Dvd>().ReverseMap().ForMember(dest => dest.Type, opt => opt.MapFrom(src => ItemType.Dvd));
            CreateMap<LibraryItemModel, Magazine>().ReverseMap().ForMember(dest => dest.Type, opt => opt.MapFrom(src => ItemType.Magazine));
        }
    }
}


