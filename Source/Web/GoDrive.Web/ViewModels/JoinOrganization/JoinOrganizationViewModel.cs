namespace GoDrive.Web.ViewModels.JoinOrganization
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class JoinOrganizationViewModel : IMapTo<JoinOrganizationRequest>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(17, 130)]
        public int Age { get; set; }

        [Display(Name = "Ask a Question")]
        [DataType(DataType.MultilineText)]
        public string AdditionalInformation { get; set; }

        public int OrganizationId { get; set; }

        public string OrganizationName { get; set; }
    }
}