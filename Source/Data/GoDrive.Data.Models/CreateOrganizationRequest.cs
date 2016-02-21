namespace GoDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class CreateOrganizationRequest : BaseModel<int>
    {
        [Required]
        [MaxLength(20)]
        public string OrganizationName { get; set; }

        [MaxLength(3000)]
        public string OrganizationDescription { get; set; }

        public bool IsProceed { get; set; }

        public string UserId { get; set; }

        public virtual User User { get; set; }
    }
}
