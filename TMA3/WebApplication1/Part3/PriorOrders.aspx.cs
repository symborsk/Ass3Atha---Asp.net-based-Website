using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1.Part3
{
    public partial class PriorOrders : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!IsPostBack)
            {
                string username = Session["User"].ToString();


                MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                MySqlCommand cmd = new MySqlCommand("Select * from user_orders where Username='" + username +"'", con);
                MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
                DataTable tab = new DataTable();

                con.Open();
                adp.Fill(tab);
                con.Close();

                BuildPriorOrderDisplay(tab);
            }
        }

        private void BuildPriorOrderDisplay(DataTable tab)
        {
            if(tab.Rows.Count == 0)
            {
                return;
            }

            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select * from computer_components", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tabComp = new DataTable();

            con.Open();
            adp.Fill(tabComp);
            con.Close();


            String innerHTML = "";
            foreach (DataRow row in tab.Rows)
            {
                Dictionary<int, int> allItems = ConvertToItemDict(row["OrderContent"].ToString());
                double runningTotal = 0;

                innerHTML += "<div class=\"OrderList\"/>";
                innerHTML += "<h5> Order Time = " + row["OrderTime"].ToString() + "</h5>";
                foreach(KeyValuePair<int,int> pair in allItems)
                {
                    DataRow currentItemRow = tabComp.Select("idComponent=" + pair.Key)[0];
                    innerHTML += "<div class=\"HistoricalItem\">";
                    innerHTML += "<image src=\"Images/" + currentItemRow["Type"].ToString() + ".jpg\" height=200 width=200 />";
                    innerHTML += "<h5>" + currentItemRow["Name"].ToString() + "</h5>";
                    innerHTML += "<p><b>Price: " + currentItemRow["Price"].ToString() + "</b></p>";
                    innerHTML += "<p><b>Quantity: " + pair.Value + "</b></p>";
                    innerHTML += "<p><b>Item(s) Total: " + pair.Value * Convert.ToDouble(currentItemRow["Price"]) + "</b></p>";
                    innerHTML += "</div>";
                    runningTotal += pair.Value * Convert.ToDouble(currentItemRow["Price"]);
                }

                innerHTML += "<h5> Total Of Order: " + runningTotal;
                innerHTML += "</div>";
            }

            PriorOrderList.InnerHtml = innerHTML;
        }

        private Dictionary<int, int> ConvertToItemDict(String items)
        {
            Dictionary<int, int> rgItems = new Dictionary<int, int> { };

            String []  itemPairs = items.Split(null);
            foreach(string s in itemPairs)
            {
                String[] itemAndCount = s.Split(':');

                if(itemAndCount.Count() != 2)
                {
                    continue;
                }

                rgItems.Add(Convert.ToInt32(itemAndCount[0]), Convert.ToInt32(itemAndCount[1]));
            }

            return rgItems;
        }
    }
}