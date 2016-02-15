namespace GoDrive.Web.ViewModels.Home
{
    using GoDrive.Data.Models;
    using GoDrive.Web.Infrastructure.Mapping;

    public class JokeCategoryViewModel //: IMapFrom<JokeCategory>
    {
        public int Id { get; set; }

        public string Name { get; set; }
    }
}
