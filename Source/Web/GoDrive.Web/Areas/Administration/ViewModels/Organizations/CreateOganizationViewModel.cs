namespace GoDrive.Web.Areas.Administration.ViewModels.Organizations
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;

    public class CreateOganizationViewModel
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