namespace GoDrive.Web.ViewModels.Organizations
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationDetailsViewModel : IMapFrom<Organization>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string AboutInfo { get; set; }

        public int UsersCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public string OrganizationImageUrl { get; set; }

        public ICollection<string> CarImages { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Organization, OrganizationDetailsViewModel>()
               .ForMember(x => x.UsersCount, opt => opt.MapFrom(x => x.Students.Where(c => c.IsDeleted == false).Count()))
               .ForMember(x => x.CarImages, opt => opt.MapFrom(x => x.CarsImages.Select(c => c.Url)));
        }
    }
}