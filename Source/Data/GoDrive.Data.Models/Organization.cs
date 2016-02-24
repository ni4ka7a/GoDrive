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
        private ICollection<DriveEvent> driveEvents;

        public Organization()
        {
            this.users = new HashSet<User>();
            this.carsImages = new HashSet<CarImage>();
            this.driveEvents = new HashSet<DriveEvent>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string AboutInfo { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public string UserId { get; set; }

        public User User { get; set; }

        public int OrganizationImageId { get; set; }

        public virtual OrganizationImage OrganizationImage { get; set; }

        public virtual ICollection<DriveEvent> DriveEvents
        {
            get { return this.driveEvents; }
            set { this.driveEvents = value; }
        }

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
