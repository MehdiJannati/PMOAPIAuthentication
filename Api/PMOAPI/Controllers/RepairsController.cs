using System.Data;
using System.Net.Http;
using System.Web.Http;
using UI.WebApi.Estates.Helpers;
using System.Data.SqlClient;
using System.Net;
using UI.WebApi.Estates.ViewModel;

namespace UI.WebApi.Estates.Controllers
{
    public class RepairsController : ApiController
    {
        private SqlConnection _scs;
        private SqlCommand _com;
        //private const string ConnectionString = "Data Source=.;Initial Catalog=PMOTestDB;user id=sa;password=123;";
        private const string ConnectionString =
            @"Data Source=84.241.11.164\operating;Initial Catalog=NETKRSARKHONLIVE2;user id=MobAppLogin;password=123456q@;";
        
        public RepairsController()
        {
            _scs = new SqlConnection(ConnectionString);
            _com = new SqlCommand()
            {
                Connection = _scs,
                CommandType = CommandType.StoredProcedure
            };
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage GetPerson([FromBody]LoginViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (_scs.State != ConnectionState.Open)
                    _scs.Open();

                _com.CommandText = "[dbo].[Sp_SLogin]";
                _com.Parameters.AddWithValue("@UserName", vm.Username);
                _com.Parameters.AddWithValue("@Pass", vm.Password);
                var da = new SqlDataAdapter(_com);
                var dt = new DataTable();
                da.Fill(dt);
                return Request.CreateResponse(HttpStatusCode.OK, new {message = dt});
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new {message = "error!"});
            }
        }

        [HttpPost]
        public HttpResponseMessage CreateWorkOrder([FromBody] ViewModel.CreateWorkOrderViewModel vm)
        {
            if (ModelState.IsValid && vm != null)
            {
                if (_scs.State != ConnectionState.Open)
                    _scs.Open();

                _com.CommandText = "[dbo].[Sp_CreateWorkOrder]";
                _com.Parameters.AddWithValue("@SQCode", vm.SQCode);
                _com.Parameters.AddWithValue("@ShomarehPersonnel", vm.PersonnelId);
                _com.Parameters.AddWithValue("@KodeNoeKar", vm.DamageTypeCode);
                _com.Parameters.AddWithValue("@Molahezat", vm.Consideration);
                _com.Parameters.AddWithValue("@Dakheli", vm.Internal);
                SqlDataAdapter da = new SqlDataAdapter(_com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { message = dt });
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = $"خطا" });
                }
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = $"خطا" });
        }

        [Authorize]
        [HttpGet]
        public HttpResponseMessage GetDamageTypes()
        {
            if (ModelState.IsValid)
            {
                if (_scs.State != ConnectionState.Open)
                    _scs.Open();

                _com.CommandText = "[dbo].[Sp_NoeKharabiList]";
                SqlDataAdapter da = new SqlDataAdapter(_com);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { dt });
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = $"خطا" });

                }
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = $"خطا" });
        }

        [Authorize]
        [HttpPost]
        public HttpResponseMessage ValidateDamageType(ViewModel.DamageTypeValidationViewModel vm)
        {
            if (ModelState.IsValid)
            {
                if (_scs.State != ConnectionState.Open)
                    _scs.Open();
                _com.CommandText = "[dbo].[Sp_ValidateNoeKharabi]";
                _com.Parameters.AddWithValue("@SQCode", vm.SQCode);
                _com.Parameters.AddWithValue("@KodeNoeKar", vm.KodeNoeKar);
                SqlDataAdapter da = new SqlDataAdapter()
                {
                    SelectCommand = _com
                };
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.OK, new { message = dt });
                }
                else
                {
                    return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = $"خطا" });
                }
            }
            return Request.CreateResponse(System.Net.HttpStatusCode.BadRequest, new { message = $"خطا" });
        }
    }
}