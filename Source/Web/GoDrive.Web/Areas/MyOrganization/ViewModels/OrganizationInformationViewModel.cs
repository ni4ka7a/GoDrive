namespace GoDrive.Web.Areas.MyOrganization.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationInformationViewModel : IMapFrom<Organization>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [Required]
        [MaxLength(3000)]
        [DataType(DataType.MultilineText)]
        [Display(Name = "Aditional Information")]
        public string AboutInfo { get; set; }
    }
}