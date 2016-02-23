namespace GoDrive.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using ViewModels.Users;
    using Web.Controllers;

    public class ManageUsersController : BaseController
    {
        private IUsersService users;

        public ManageUsersController(IUsersService users)
        {
            this.users = users;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Users_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.users
                .GetAllWithDeleted()
                .To<UserGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Update([DataSourceRequest]DataSourceRequest request, UserGridInputModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var organizationToUpdate = this.Mapper.Map<User>(model);
                this.users.Update(organizationToUpdate);
            }

            var userToDispley = this.users
                .GetAll()
                .Where(x => x.Id == model.Id)
                .To<UserGridViewModel>()
                .FirstOrDefault();

            return this.Json(new[] { userToDispley }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Users_Destroy([DataSourceRequest]DataSourceRequest request, UserGridInputModel userToDelete)
        {
            this.users.Delete(userToDelete.Id);

            return this.Json(new[] { userToDelete }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
