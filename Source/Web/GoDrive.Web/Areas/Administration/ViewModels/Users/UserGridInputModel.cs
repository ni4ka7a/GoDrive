namespace GoDrive.Web.Areas.Administration.ViewModels.Users
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class UserGridInputModel : IMapTo<User>
    {
        public string Id { get; set; }

        [MaxLength(30)]
        public string FirstName { get; set; }

        [MaxLength(30)]
        public string LastName { get; set; }

        [Range(16, 130)]
        public int Age { get; set; }
    }
}
