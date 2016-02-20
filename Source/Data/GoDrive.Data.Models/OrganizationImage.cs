namespace GoDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using GoDrive.Data.Common.Models;

    public class OrganizationImage : BaseModel<int>
    {
        [Required]
        [MaxLength(400)]
        public string Name { get; set; }

        [Required]
        [MaxLength(500)]
        public string Url { get; set; }
    }
}
