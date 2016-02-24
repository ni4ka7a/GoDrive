namespace GoDrive.Web.Areas.Administration.ViewModels.Organizations
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class OrganizationGridInputMdel : IMapTo<Organization>
    {
        public int Id { get; set; }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        [Display(Name = "Aditional Information")]
        public string AboutInfo { get; set; }
    }
}
