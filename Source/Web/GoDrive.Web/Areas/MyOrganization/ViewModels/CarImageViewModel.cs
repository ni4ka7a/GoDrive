namespace GoDrive.Web.Areas.MyOrganization.ViewModels
{
    using GoDrive.Data.Models;
    using GoDrive.Web.Infrastructure.Mapping;

    public class CarImageViewModel : IMapFrom<CarImage>
    {
        public int Id { get; set; }

        public string Url { get; set; }
    }
}
