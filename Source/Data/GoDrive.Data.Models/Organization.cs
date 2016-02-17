namespace GoDrive.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using Common.Models;

    public class Organization : BaseModel<int>
    {
        private ICollection<User> students;

        public Organization()
        {
            this.students = new HashSet<User>();
        }

        [Required]
        [MaxLength(20)]
        public string Name { get; set; }

        [MaxLength(3000)]
        public string AboutInfo { get; set; }

        public string OwnerID { get; set; }

        [ForeignKey("OwnerID")]
        public User Owner { get; set; }

        public virtual ICollection<User> Students
        {
            get { return this.students; }
            set { this.students = value; }
        }
    }
}
