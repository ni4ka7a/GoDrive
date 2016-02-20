namespace GoDrive.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Organization : BaseModel<int>
    {
        private ICollection<User> students;
        private ICollection<CarImage> carsImages;

        public Organization()
        {
            this.students = new HashSet<User>();
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

        public OrganizationImage OrganizationImage { get; set; }

        public virtual ICollection<User> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }

        public virtual ICollection<CarImage> CarsImages
        {
            get { return this.carsImages; }
            set { this.carsImages = value; }
        }
    }
}
