namespace UI.WebApi.Estates.ViewModel
{
    public class CreateWorkOrderViewModel : System.Object
    {
        //[System.ComponentModel.DataAnnotations.MaxLength(200,ErrorMessageResourceName = "stringLenghtError",ErrorMessageResourceType =typeof(Resources.ErrorValidation))]
        public string SQCode { get; set; }

        public string PersonnelId { get; set; }

        public int DamageTypeCode { get; set; }

        //[System.ComponentModel.DataAnnotations.MaxLength(4000,ErrorMessageResourceName = "stringLenghtError", ErrorMessageResourceType =typeof(Resources.ErrorValidation))]
        public string  Consideration { get; set; }

        //[System.ComponentModel.DataAnnotations.MaxLength(10,ErrorMessageResourceName = "stringLenghtError",ErrorMessageResourceType =typeof(Resources.ErrorValidation))]
        public string Internal { get; set; }
    }
}