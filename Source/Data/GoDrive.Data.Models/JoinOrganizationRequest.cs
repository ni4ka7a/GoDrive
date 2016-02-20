namespace GoDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class JoinOrganizationRequest : BaseModel<int>
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }

        [Range(17, 130)]
        public int Age { get; set; }

        public string AdditionalInformation { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}
