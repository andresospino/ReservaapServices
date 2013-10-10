using System.Collections.Generic;
using System.Web.Script.Serialization;
using System.Web.Script.Services;
using System.Web.Services;
using Entities;
namespace ReservApp
{
    /// <summary>
    /// Reservapp API
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [System.Web.Script.Services.ScriptService]
    public class Reservapp : System.Web.Services.WebService
    {

        [WebMethod(Description = "Login")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Login(string pMail, string pPassWord)
        {
            User lUser = new User();
            bool Result = lUser.Login(pMail, pPassWord);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = string.Empty;
            if (Result)
                strJSON = js.Serialize(lUser);
            return strJSON;
        }

        [WebMethod(Description = "Register")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string Register(string pName,string pMail, string pPassWord)
        {
            bool Result = new User().Register(pName, pMail, pPassWord);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(Result);
            return strJSON;
        }

        [WebMethod(Description = "Get Restaurant")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetRestaurant(long pId)
        {
            Restaurant lRestaurant = new Restaurant(pId);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(lRestaurant);
            return strJSON;
        }

        [WebMethod(Description = "Get Restaurant List")]
        [ScriptMethod(ResponseFormat = ResponseFormat.Json)]
        public string GetListRestaurant(short pPosition)
        {
            List<Restaurant> lRestaurant = new Restaurant().GetList(pPosition);
            JavaScriptSerializer js = new JavaScriptSerializer();
            string strJSON = js.Serialize(lRestaurant);
            return strJSON;
        }
    }
}
