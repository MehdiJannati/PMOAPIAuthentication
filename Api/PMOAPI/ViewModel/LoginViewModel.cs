namespace UI.WebApi.Estates.ViewModel
{
    public class LoginViewModel: System.Object
    {
        //[System.ComponentModel.DataAnnotations.MaxLength(200,ErrorMessageResourceName = "stringLenghtError",ErrorMessageResourceType =typeof(Resources.ErrorValidation))]
        public string Username { get; set; }

        //[System.ComponentModel.DataAnnotations.MaxLength(200, ErrorMessageResourceName = "stringLenghtError", ErrorMessageResourceType = typeof(Resources.ErrorValidation))]
        public string Password { get; set; }
    }
}