using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication1.Part3
{
    public partial class RegisterUser : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                UsernameText.Attributes["value"] = UsernameText.Text;
                Password.Attributes["value"] = Password.Text;
                PasswordConfirm.Attributes["value"] = PasswordConfirm.Text;
                Email.Attributes["value"] = Email.Text;
            }
        }


        private bool IsValidateUserProfile()
        {
            if(UsernameText.Text == "" || PasswordConfirm.Text == "" || Password.Text == "" || Email.Text ==""){
                InformationText.Text = "Please fill out all fields";
                return false;
            }

            if(Password.Text != PasswordConfirm.Text)
            {
                InformationText.Text = "Password do not match";
                return false;
            }

            if (!IsValidEmail(Email.Text))
            {
                InformationText.Text = "Email is not valid";
                return false;
            }

            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select Count(*) as \"count\" from users where Username='" + UsernameText.Text + "'", con);
            con.Open();

            var reader = cmd.ExecuteReader();
            reader.Read();

            if(Convert.ToInt32(reader["count"]) != 0)
            {
                InformationText.Text = "That Username is already in use";
                con.Close();
                return false;
            }

            InformationText.Text = "";
            con.Close();
            return true;
        }

        protected void CreateUserButton_Click(object sender, EventArgs e)
        {
            if (IsValidateUserProfile())
            {
                MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                MySqlCommand cmd = new MySqlCommand("Insert into users VALUES('" + UsernameText.Text + "','" + Password.Text + "','" + Email.Text + "')", con);
                con.Open();

                var reader = cmd.ExecuteNonQuery();

                Session["User"] = UsernameText.Text;
                Response.Redirect("ComputerStore.aspx");
            }
          
        }

        bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }


    }
}