namespace GoDrive.Web.Areas.MyOrganization.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserRequestViewModel : IMapFrom<JoinOrganizationRequest>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int OrganizationId { get; set; }

        public string Username { get; set; }

        public string UserId { get; set; }

        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(17, 130)]
        public int Age { get; set; }

        public bool IsProceed { get; set; }

        public DateTime CreatedOn { get; set; }

        public string AdditionalInformation { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<JoinOrganizationRequest, UserRequestViewModel>()
               .ForMember(x => x.Username, opt => opt.MapFrom(x => x.User.UserName));
        }
    }
}
