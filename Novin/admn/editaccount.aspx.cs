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
    public partial class editaccount : System.Web.UI.Page
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
                GetUserDetails();
            }
        }

        protected void sabt_OnServerClick(object sender, EventArgs e)
        {
            if (CheckInputs())
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "CheckRequiredFields();redalert('n','لطفا فیلدهای خالی را تکمیل کنید')", true);
                return;
            }

            if (CheckPasswords())
            {
                ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "redalert('n','لطفا پسورد را چک کنید')", true);
                return;
            }
            var re = new RijndaelEnhanced(Key, InitVector);
            var pass = re.Encrypt(txtPass.Value);
            _cnn.Open();
            var updateUser = new SqlCommand("UPDATE [dbo].[admin] "+
                                            "SET[name] = N'"+txtName.Value.Trim()+"' " +
                                            ",[username] = N'"+txtUserName.Value.Trim()+"' " +
                                            ",[password] = '"+pass+"' " +
                                            ",[tell] = '"+txtTell.Value+"' " +
                                            ",[email] = '"+txtEmail.Value+"' ", _cnn);
            updateUser.ExecuteNonQuery();
            _cnn.Close();
            GetUserDetails();
            ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "greenalert('n','با موفقیت ثبت شد')", true);
        }

        private bool CheckPasswords()
        {
            return txtPass.Value != txtRepPass.Value;
        }

        private bool CheckInputs()
        {
            return txtEmail.Value ==  "" || txtName.Value == "" || txtPass.Value == "" 
                   || txtRepPass.Value == "" || txtTell.Value == "" || txtUserName.Value == "";
        }

        private void GetUserDetails()
        {
            _cnn.Open();
            var select = new SqlCommand("SELECT [id],[name],[username],[password],[usrlevel],[permit],[tell],[email]FROM [dbo].[admin]",_cnn);
            var r = select.ExecuteReader();
            if (!r.Read()) return;
            txtName.Value = r["name"].ToString();
            txtUserName.Value = r["username"].ToString();
            var re = new RijndaelEnhanced(Key,InitVector);
            var password = re.Decrypt(r["password"].ToString());
            txtPass.Value = password;
            txtRepPass.Value = password;
            txtTell.Value = r["tell"].ToString();
            txtEmail.Value = r["email"].ToString();
            _cnn.Close();
        }
    }
}