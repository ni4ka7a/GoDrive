namespace GoDrive.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Organization : BaseModel<int>
    {
        private ICollection<User> users;
        private ICollection<CarImage> carsImages;

        public Organization()
        {
            this.users = new HashSet<User>();
            this.carsImages = new HashSet<CarImage>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string AboutInfo { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int OrganizationImageId { get; set; }

        public virtual OrganizationImage OrganizationImage { get; set; }

        [ForeignKey("JoinedOrganizationId")]
        public virtual ICollection<User> Students
        {
            get { return this.users; }
            set { this.users = value; }
        }

        public virtual ICollection<CarImage> CarsImages
        {
            get { return this.carsImages; }
            set { this.carsImages = value; }
        }
    }
}
