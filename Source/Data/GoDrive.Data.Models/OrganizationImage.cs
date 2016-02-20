namespace GoDrive.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using GoDrive.Data.Common.Models;

    public class OrganizationImage : BaseModel<int>
    {
        [Required]
        public string Url { get; set; }
    }
}
