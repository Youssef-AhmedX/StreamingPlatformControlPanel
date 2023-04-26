using AutoMapper;
using Microsoft.AspNetCore.Mvc.Rendering;
using StreamingPlatformControlPanel.Core.Models;
using StreamingPlatformControlPanel.Core.ViewModels;

namespace Bookify.Web.Core.Mapping
{
    public class MappingProfile : Profile
    {

        public MappingProfile()
        {
            //Category
            CreateMap<Category, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));

            //FilmMaker
            CreateMap<FilmMaker, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));

            //Certification
            CreateMap<Certification, SelectListItem>()
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Text, opt => opt.MapFrom(src => src.Name));

            CreateMap<ContentFormViewModel, Content>()
                .ReverseMap()
                .ForMember(dest => dest.Categories, opt => opt.Ignore())
                .ForMember(dest => dest.DurationTimeInHour, opt => opt.Ignore())
                .ForMember(dest => dest.ContentPath, opt => opt.Ignore())
                .ForMember(dest => dest.TrailerPath, opt => opt.Ignore());

           

            //FilmRole
            //CreateMap<FilmRole, SelectListItem>()
            //    .ForMember(dest => dest.CategoriesList, opt => opt.MapFrom(src => src.Categories.Select(c => c.Category!.Name).ToList()))
            //    .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.Author!.Name))
            //    .ForMember(dest => dest.EditionsList, opt => opt.MapFrom(src => src.Editions));


            //CreateMap<BookFormViewModel, Book>()
            //    .ReverseMap()
            //    .ForMember(dest => dest.Categories, opt => opt.Ignore());






        }

    }
}
