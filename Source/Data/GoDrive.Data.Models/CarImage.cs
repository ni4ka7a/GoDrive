namespace GoDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using GoDrive.Data.Common.Models;

    public class CarImage : BaseModel<int>
    {
        [Required]
        [MaxLength(400)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }

        public int OrganizationId { get; set; }

        public Organization Organization { get; set; }
    }
}
