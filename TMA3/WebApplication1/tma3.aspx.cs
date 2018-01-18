using System;
using System.Data;
using System.Web;

namespace TMA3
{
    public partial class HostPage : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            //Add a visit to 
            if (!IsPostBack)
            {
                AddIpVisit(GetIP());
            }
            
        }

        protected void PersistentCookie_OnClick(Object sender, EventArgs e)
        {
            String s = "<h5>Number of visits for IP " + GetIP().ToString() + " : " + GetNumberVisits(GetIP()) +"</h5>";
            contentWindow.InnerHtml = s;
        }

        public static String GetIP()
        {
            String ip =
            HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];


            if (string.IsNullOrEmpty(ip))
            {
                ip = HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            }

            return ip;
        }

        private void AddIpVisit(String ip)
        {
            HttpCookie cookie = Request.Cookies["IPAddressVisits"];

            if (cookie == null)
            {
                cookie = new HttpCookie("IPAddressVisits");
                cookie.Expires = DateTime.Now.AddHours(100);
                Response.Cookies.Add(cookie);
            }

            if (!string.IsNullOrEmpty(cookie.Values[ip]))
            {
                cookie.Values[ip] = Convert.ToString(Convert.ToInt32(cookie.Values[ip].ToString()) + 1);
                Response.Cookies.Add(cookie);
            }
            else
            {
                cookie.Values.Add(ip, "1");
            }
        }

        private string GetNumberVisits(String ip)
        {
            HttpCookie cookie = Request.Cookies["IPAddressVisits"];

            if (cookie == null)
            {
                cookie = new HttpCookie("IPAddressVisits");
                cookie.Expires = DateTime.Now.AddHours(100);
                Response.Cookies.Add(cookie);
            }

            if (!string.IsNullOrEmpty(cookie.Values[ip]))
            {
                return cookie.Values[ip].ToString();
            }
            else
            {
                return "0";
            }
        }
    }
}