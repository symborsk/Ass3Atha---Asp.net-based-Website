using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace WebApplication1.Part3
{
    public partial class ComputerStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if( Session["Items"] == null)
            {
                Session["Items"] = new List<int> { };
            }

            RecalcCart();

            if (!IsPostBack)
            {
                MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components", con);

                con.Open();

                var reader = cmd.ExecuteReader();

                ProductsList.DataSource = reader;
                ProductsList.DataBind();
                computerDisplayList.InnerHtml = "";

                con.Close();
            }

        }

        protected void UpdateViewComputer(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select * from computers", con);

            con.Open();

            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();
            adp.Fill(tab);

            Computer comp = new Computer();
            String htmlText = "";
            foreach (DataRow row in tab.Rows)
            {
                comp.AddAllComponents(row, tab.Columns.Count);
                htmlText += comp.BuildHtmlComputerItem(row["ConfigurationName"].ToString());
            }

            computerDisplayList.InnerHtml = htmlText;
            con.Close();

            ProductsList.DataSource = null;
            ProductsList.DataBind();
        }

        protected void UpdateViewRam(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where Type='Ram'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void UpdateViewHardDrive(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where Type='HardDrive'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void UpdateViewCPU(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where Type='CPU'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void UpdateViewDisplay(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where Type='Display'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void UpdateViewGPU(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where Type='GPU'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void UpdateViewOS(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where Type='OS'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void ViewShoppingCartContents(Object sender, EventArgs e)
        {

        }

        protected void DisplaySearchResults(Object sender, EventArgs e)
        {
            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where name LIKE '%" + txtSearchMaster.Text.ToString() + "%'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();
            computerDisplayList.InnerHtml = "";

            con.Close();
        }

        protected void AddItemToCart(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int componentId = Convert.ToInt32(button.CommandArgument);

            List<int> rgItems = (List<int>) Session["Items"];
            rgItems.Add(componentId);

            Session["Items"] = rgItems;

            RecalcCart();
        }

        private DataTable GetAllCartItems()
        {
            List<int> rgItems = (List<int>)Session["Items"];

            if (rgItems.Count == 0)
            {
                return null;
            }

            string containsString = "(";
            foreach (int id in rgItems)
            {
                containsString += id.ToString() + ",";
            }

            containsString = containsString.Substring(0, containsString.Length - 1);
            containsString += ")";


            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select Name, Price, Type from computer_components where idComponent IN " + containsString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();

            adp.Fill(tab);

            return tab;
        }

        private void RecalcCart()
        {
            DataTable tab = GetAllCartItems();
            
            if(tab == null)
            {
                ShoppingCart.Text = "Items: 0 - $0.0";
            }
            else
            {
                int count = tab.Rows.Count;
                Double tot = 0;
                foreach(DataRow row in tab.Rows)
                {
                    tot += Convert.ToDouble(row["Price"]);
                }

                ShoppingCart.Text = "Items: " + count.ToString() + " - $" + tot.ToString("N2"); 
            }      
        }

        private class Computer{

            private List<String> rgPartsRequired = new List<String> { "CPU", "Display", "GPU", "HardDrive", "OS", "Ram" };
            private List<ComputerComponent> rgComponents = new List<ComputerComponent> { };

            public void AddComponent(ComputerComponent comp)
            {
                rgComponents.Add(comp);
            }

            public void AddAllComponents(DataRow row, int columnCount)
            {
                ClearComponents();
                string containsString = "(";

                //Skip the first column as it is always the configuration name
                for (int i = 1; i < columnCount; i++)
                {
                    containsString += row[i].ToString() + ",";
                }

                //Trim last comma
                containsString = containsString.Substring(0, containsString.Length - 1);
                containsString += ")";

                MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                string s = "Select Name, Price, Type from computer_components where idComponent IN " + containsString;
                MySqlCommand cmd = new MySqlCommand("Select Name, Price, Type from computer_components where idComponent IN " + containsString, con);

                con.Open();

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    AddComponent(new ComputerComponent(reader["Type"].ToString(), reader["Name"].ToString(), Convert.ToDouble(reader["Price"].ToString())));
                }

                con.Close();
            }

            public void ClearComponents()
            {
                rgComponents.Clear();
            }

            public double GetTotalCost()
            {
                Double total = 0;
                foreach(ComputerComponent comp in rgComponents)
                {
                    total += comp.Cost;
                }

                return total;
            }

            public void ReplacePart( ComputerComponent comp )
            {
                String type = comp.Type;
                foreach (ComputerComponent currentComp in rgComponents)
                {
                    if(type == currentComp.Type)
                    {
                        rgComponents.Remove(currentComp);
                        break;
                    }
                }

                AddComponent(comp);
            }

            public string GetPartName(String type)
            {
                foreach (ComputerComponent currentComp in rgComponents)
                {
                    if (type == currentComp.Type)
                    {
                        return currentComp.Name;
                    }
                }

                return "None Selected";
            }

            public string BuildHtmlComputerItem(string configurationName)
            {
                String htmlText = "<div class= \"Computer\">";

                htmlText += "<h5>" + configurationName + "</h5>";
                htmlText += "<image width=\"400\" height=\"300\" src=\"Images\\" +configurationName + ".jpg\"></image><br/>";

                foreach (String type in rgPartsRequired)
                {
                    htmlText += "<p><b>" + type + ": </b>" + GetPartName(type) + "</p>";
                }

                htmlText += "<b>Configuration Cost: " + GetTotalCost().ToString() + "</b>";
                htmlText += "</div>";
                return htmlText;
            }   
        }

        private class ComputerComponent
        {
            public string Type { get; set; }
            public string Name { get; set; }
            public Double Cost { get; set; }


             public  ComputerComponent(string type, string name, double cost)
            {
                Type = type;
                Name = name;
                Cost = cost;
            }
        }
    }
}