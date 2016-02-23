namespace GoDrive.Web.Areas.Administration.ViewModels.Organizations
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationGridViewModel : IMapFrom<Organization>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string AboutInfo { get; set; }

        public string OwnerUsername { get; set; }

        public string OwnerEmail { get; set; }

        public string JoinedUsersCount { get; set; }

        public DateTime CreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }

        public bool IsDeleted { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Organization, OrganizationGridViewModel>()
                .ForMember(x => x.JoinedUsersCount, opt => opt.MapFrom(x => x.Students.Count))
                .ForMember(x => x.OwnerEmail, opt => opt.MapFrom(x => x.User.Email))
                .ForMember(x => x.OwnerUsername, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}