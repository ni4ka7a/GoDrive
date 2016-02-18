namespace GoDrive.Web.Areas.Administration.ViewModels.Organizations
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateOganizationViewModel : IMapTo<Organization>
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        [Display(Name = "Aditional Information")]
        public string AboutInfo { get; set; }

        [Required]
        public string UserId { get; set; }
    }
}