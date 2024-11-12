using AutoMapper;
using LibraryMVC.Entity;
using LibraryMVC.Models;

namespace LibraryMVC.MappingProfile;

public class HistoryProfile : Profile
{
    public HistoryProfile()
    {
        CreateMap<BorrowingHistory, HistoryViewModel>()
            .ForMember(dest => dest.LibraryItem, opt => opt.MapFrom(src => src.LibraryItem))
            .ForMember(dest => dest.BorrowerName, opt => opt.MapFrom(src => src.Borrower.Name));
    }
}