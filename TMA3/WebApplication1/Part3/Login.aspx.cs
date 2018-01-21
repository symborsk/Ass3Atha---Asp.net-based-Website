using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication1.Part3
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginForm_Authenticate(object sender, AuthenticateEventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select * from users where Username = '" + loginForm.UserName + "' and Password = '" + loginForm.Password + "'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            if (reader.HasRows)
            {
                LoginSection.Visible = false;
                Session["User"] = loginForm.UserName;
                System.Web.Security.FormsAuthentication.RedirectFromLoginPage(loginForm.UserName, loginForm.RememberMeSet);
            }
        }
    }
}