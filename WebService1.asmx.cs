using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace SampleWebAPI
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        SqlConnection con = new SqlConnection(@"Data Source=PC339\SQL2008;Initial Catalog=SampleWebAPIDB;Integrated Security=True");
        SqlCommand cmd;//Insert/Update/Delete

        [WebMethod]
        public string HelloWorld()
        {
            return "Hello World";
        }

        [WebMethod]
        public string InsertNewUser(string FirstName, string LastName)
        {
            string Status = "";
            cmd = new SqlCommand("insert into UserInfo values(@Fname,@Lname)", con);
            cmd.Parameters.AddWithValue("@Fname", FirstName);
            cmd.Parameters.AddWithValue("@Lname", LastName);
            con.Open();
            Status= cmd.ExecuteNonQuery().ToString();
            con.Close();
            return Status;
        }


    }
}
