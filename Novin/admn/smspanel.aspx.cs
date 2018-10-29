using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Novin.Class;
using rijndael;

namespace Novin.admn
{
    public partial class smspanel : System.Web.UI.Page
    {
        private readonly SqlConnection _cnn = new SqlConnection(ConfigurationManager.ConnectionStrings["novin"].ConnectionString);
        private const string InitVector = "F4568dgbdfgtt444";
        private const string Key = "rdf48JH4";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Authentication.IsAuthenticated())
            {
                Response.Redirect("../adminn.aspx");
            }

            if (!Page.IsPostBack)
            {
               GetSmsData();
            }
        }

        private void GetSmsData()
        {
            _cnn.Open();
            var re = new RijndaelEnhanced(Key, InitVector);
            var select = new SqlCommand("select username , password , address from sms",_cnn);
            var r = select.ExecuteReader();
            if (!r.Read()) return;
            txtaddress.Value = (r["address"].ToString());
            txtusername.Value = re.Decrypt(r["username"].ToString());
            txtpass.Value= re.Decrypt(r["password"].ToString());
            _cnn.Close();
        }

        protected void sabt_OnServerClick(object sender, EventArgs e)
        {
            if (ChechInputs())
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CheckRequiredFields();redalert('n','لطفا فیلدهای خالی را تکمیل کنید')", true);
                return;
            }
            _cnn.Open();
            var re = new RijndaelEnhanced(Key, InitVector);
            var username = re.Encrypt(txtusername.Value);
            var password = re.Encrypt(txtpass.Value);
            var insert = new SqlCommand("update sms set username= '"+username+"',password = '"+password+"',address ='"+ txtaddress.Value + "'",_cnn);
            insert.ExecuteNonQuery();
            _cnn.Close();
            GetSmsData();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "greenalert('n','با موفقیت ثبت شد')", true);
        }

        private bool ChechInputs()
        {
            return txtpass.Value == "" || txtaddress.Value == "" || txtusername.Value == "";
        }
    }
}