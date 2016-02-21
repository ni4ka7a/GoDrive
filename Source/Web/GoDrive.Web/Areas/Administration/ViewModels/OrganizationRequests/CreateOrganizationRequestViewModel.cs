namespace GoDrive.Web.Areas.Administration.ViewModels.OrganizationRequests
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateOrganizationRequestViewModel : IMapFrom<CreateOrganizationRequest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string OrganizationName { get; set; }

        [MaxLength(3000)]
        public string OrganizationDescription { get; set; }

        public bool IsProceed { get; set; }

        public string UserId { get; set; }

        public string UserName { get; set; }

        public DateTime CreatedOn { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<CreateOrganizationRequest, CreateOrganizationRequestViewModel>()
               .ForMember(x => x.UserName, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}