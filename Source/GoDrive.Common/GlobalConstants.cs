namespace GoDrive.Common
{
    public class GlobalConstants
    {
        public const string AdministratorRoleName = "Administrator";
        public const string OrganizationOwnerRoleName = "Owner";
        public const string DefaultImageName = "DefaultImage";
        public const string DefaultImagePath = "/Content/Images/defaultOrganizationImage.png";
        public const string JpgFileExtension = ".jpg";
        public const string JpegFileExtension = ".jpeg";
        public const string PngFileExtension = ".png";
        public const string UserCannotJoinOrganizationErrorMessage = "The user cannot be added becouse he is in another company already.";
        public const string TempDataErrorKey = "error";
        public const string TempDataSuccessKey = "success";
        public const string InvalidOrganizationRequestErrorMessage = "Invalid Organization Request";
        public const string CreatedOrganizationSuccessMessage = "Organization Created successfully!";
        public const string InvalidImageExtensionErrorMessage = "The Image Should be .jpg, .jpeg or .png!";
        public const string OrganizationRequestsPratialViewName = "_OrganizationsRequestsPartial";
        public const string UserAlreadyHaveOrganizationErrorMessage = "The User already have an Organization";
        public const string UserRequestsPratialName = "_UsersRequestPartial";
        public const int OrganizationsPerPage = 6;
        public const int TopOrganizationsCount = 6;
    }
}
