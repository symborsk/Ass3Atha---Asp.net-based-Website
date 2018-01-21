using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Net;
using System.Net.Mail;

namespace WebApplication1.Part3
{
    public partial class RecoverPassword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void RecoverPasswordBtn_Click(object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select * from users where Email='"+ EmailRecover.Text + "'", con);
            con.Open();

            var reader = cmd.ExecuteReader();

           if(!reader.HasRows)
            {
                InformationText.Text = "No account assosiated with that email";
            }
            else
            {
                reader.Read();
                SendEmail(reader["Username"].ToString(), reader["Password"].ToString(), reader["Email"].ToString());
                Response.Redirect("ComputerStore.aspx");

            }
        }

        private void SendEmail(String user, String pass, String Email)
        {
            var fromAddress = new MailAddress("john.symborski@gmail.com", "Rubber Ducky Computer");
            var toAddress = new MailAddress(Email, "Valued Client");
            const string fromPassword = "jsymborski25228";
            const string subject = "Password Recovery Rubber Ducky";
            string body = "Rubber Ducky Password Recovery \n Username:" + user + "\n" + "Password:" + pass;

            var smtp = new SmtpClient
            {
                Host = "smtp.gmail.com",
                Port = 587,
                EnableSsl = true,
                DeliveryMethod = SmtpDeliveryMethod.Network,
                Credentials = new NetworkCredential(fromAddress.Address, fromPassword),
                Timeout = 20000
            };
            using (var message = new MailMessage(fromAddress, toAddress)
            {
                Subject = subject,
                Body = body
            })
            {
                smtp.Send(message);
            }
        }
    }
}