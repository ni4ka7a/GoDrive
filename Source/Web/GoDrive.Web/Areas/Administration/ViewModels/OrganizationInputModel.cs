namespace GoDrive.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class OrganizationInputModel
    {
        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string AboutInfo { get; set; }
    }
}