namespace GoDrive.Web.ViewModels.ApplyForOrganization
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateOrganizationRequestViewModel : IMapTo<CreateOrganizationRequest>
    {
        [Required]
        [MaxLength(20)]
        public string OrganizationName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [MaxLength(3000)]
        public string OrganizationDescription { get; set; }
    }
}