namespace GoDrive.Web.ViewModels.Manage
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class PersonalInformationViewModel : IMapFrom<User>, IMapTo<User>
    {
        public string Username { get; set; }

        public string Email { get; set; }

        [Required]
        [MaxLength(30)]
        public string FirstName { get; set; }

        [Required]
        [MaxLength(30)]
        public string LastName { get; set; }

        [Required]
        [Range(16, 130)]
        public int Age { get; set; }
    }
}
