namespace GoDrive.Web.ViewModels.ApplyForOrganization
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateOrganizationRequestViewModel : IMapTo<CreateOrganizationRequest>
    {
        [Required]
        [MaxLength(20)]
        [Display(Name = "Organization Name")]
        public string OrganizationName { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        [Display(Name = "About The Organization")]
        [MaxLength(3000)]
        public string OrganizationDescription { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }
    }
}
