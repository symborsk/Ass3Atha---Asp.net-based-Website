using System;
using System.Collections.Generic;
using System.Data;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using System.Linq;

namespace WebApplication1.Part3
{
    public partial class ComputerStore : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!IsPostBack)
            {
                if (Session["Items"] == null)
                {
                    Session["Items"] = new Dictionary<int, int> { };
                }

                if(Session["User"] !=  null)
                {
                    LoggedIn.Visible = true;
                    NotLoggedIn.Visible = false;
                    CurrentUserLoggedIn.Text = "Logged in as: " + Session["User"].ToString();
                }

                RecalcCart();
                LoadDropDownItems();

                MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components", con);

                con.Open();

                var reader = cmd.ExecuteReader();

                ProductsList.DataSource = reader;
                ProductsList.DataBind();

                ComputerComponentContent.Visible = true;
                computerDisplayList.Visible = false;
                ContactsPage.Visible = false;
                FeedbackForm.Visible = false;

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

            ComputerComponentContent.Visible = false;
            computerDisplayList.Visible = true;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;

            computerConfigList.InnerHtml = htmlText;
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

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;
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

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;

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

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;
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

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false; ;

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

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;

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

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;

            con.Close();
        }

        protected void ViewShoppingCartContents(Object sender, EventArgs e)
        {
            DataTable tab = GetAllCartItems();
            ShoppingCartData.DataSource = tab;
            ShoppingCartData.DataBind();
            ShoppingCartContents.Visible = true;
            SubmitError.Text = "";
        }

        protected void DisplaySearchResults(Object sender, EventArgs e)
        {
  MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select idComponent, Name, Price, Type from computer_components where name LIKE '%" + txtSearchMaster.Text.ToString() + "%'", con);

            con.Open();

            var reader = cmd.ExecuteReader();

            ProductsList.DataSource = reader;
            ProductsList.DataBind();

            ComputerComponentContent.Visible = true;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = false;

            con.Close();
        }

        protected void AddComputerConfiguration_Click(object sender, EventArgs e)
        {
            modalDialogComputer.Visible = true;
            ProductsList.DataSource = null;
            ProductsList.DataBind();
            CalculateTotalComputerWindow();
            ComputerDropDown_SelectedIndexChanged(ComputerDropDown, null);
        }

        protected void ComputerDropDown_SelectedIndexChanged(object sender, EventArgs e)
        {
            DropDownList list = (DropDownList)sender;

            if (list.ID == "ComputerDropDown")
            {
                String trimmedString = ComputerDropDown.SelectedItem.Value.Substring(1, ComputerDropDown.SelectedItem.Value.Length - 2);
                String[] ids = trimmedString.Split(',');

                try
                {
                    RamDropDown.SelectedValue = ids[0].ToString();
                    HardDriveDropDown.SelectedValue = ids[1].ToString();
                    CpuDropDown.SelectedValue = ids[2].ToString();
                    DisplayDropDown.SelectedValue = ids[3].ToString();
                    GPUDropDown.SelectedValue = ids[4].ToString();
                    OSDropDown.SelectedValue = ids[5].ToString();
                }
                catch (Exception ex)
                {

                }

            }

            CalculateTotalComputerWindow();
        }

        protected void AddItemToCart_OnClick(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            int componentId = Convert.ToInt32(button.CommandArgument);

            AddItemToCart(componentId);
        }

        private void AddItemToCart(int componentId)
        {
            Dictionary<int, int> rgItems = (Dictionary<int, int>)Session["Items"];

            if (rgItems.ContainsKey(componentId))
            {
                rgItems[componentId]++;
            }
            else
            {
                rgItems.Add(componentId, 1);
            }

            Session["Items"] = rgItems;

            RecalcCart();
        }

        private DataTable GetAllCartItems()
        {
            Dictionary<int, int> rgItems = (Dictionary<int, int>)Session["Items"];

            if (rgItems.Count == 0)
            {
                return null;
            }

            string containsString = "(";
            foreach (KeyValuePair<int, int> id in rgItems)
            {
                containsString += id.Key.ToString() + ",";
            }

            containsString = containsString.Substring(0, containsString.Length - 1);
            containsString += ")";

  MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select * from computer_components where idComponent IN " + containsString, con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();

            con.Open();
            adp.Fill(tab);
            con.Close();

            tab.Columns.Add("Count");

            foreach (KeyValuePair<int, int> id in rgItems)
            {
                tab.Select("idComponent=" + id.Key)[0]["Count"] = id.Value;
            }

            return tab;
        }

        private void RecalcCart()
        {
            DataTable tab = GetAllCartItems();

            Dictionary<int, int> rgItems = (Dictionary<int, int>)Session["Items"];

            if (tab == null)
            {
                ShoppingCart.Text = "Items: 0 - $0.0";
            }
            else
            {
                int count = tab.Rows.Count;
                Double tot = 0;
                foreach (KeyValuePair<int, int> item in rgItems)
                {
                    DataRow[] row = tab.Select("idComponent=" + item.Key);
                    tot += item.Value * Convert.ToDouble(row[0]["Price"]);
                }

                ShoppingCart.Text = "Items: " + count.ToString() + " - $" + tot.ToString("N2");
            }
        }

        private void LoadDropDownItems()
        {

  MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            MySqlCommand cmd = new MySqlCommand("Select * from computer_components", con);
            MySqlDataAdapter adp = new MySqlDataAdapter(cmd);
            DataTable tab = new DataTable();

            con.Open();
            adp.Fill(tab);
            con.Close();

            AddComponents(tab);

            con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            cmd = new MySqlCommand("Select* from computers", con);
            adp = new MySqlDataAdapter(cmd);
            tab = new DataTable();

            con.Open();
            adp.Fill(tab);
            con.Close();

            AddComputers(tab);
        }

        private void AddComponents(DataTable tab)
        {
            foreach (DataRow row in tab.Rows)
            {
                switch (row["Type"].ToString())
                {
                    case "Ram":
                        RamDropDown.Items.Add(new ListItem(row["Name"].ToString() + " -- " + row["Price"].ToString(), row["idComponent"].ToString()));
                        break;
                    case "HardDrive":
                        HardDriveDropDown.Items.Add(new ListItem(row["Name"].ToString() + " -- " + row["Price"].ToString(), row["idComponent"].ToString()));
                        break;
                    case "CPU":
                        CpuDropDown.Items.Add(new ListItem(row["Name"].ToString() + " -- " + row["Price"].ToString(), row["idComponent"].ToString()));
                        break;
                    case "Display":
                        DisplayDropDown.Items.Add(new ListItem(row["Name"].ToString() + " -- " + row["Price"].ToString(), row["idComponent"].ToString()));
                        break;
                    case "GPU":
                        GPUDropDown.Items.Add(new ListItem(row["Name"].ToString() + " -- " + row["Price"].ToString(), row["idComponent"].ToString()));
                        break;
                    case "OS":
                        OSDropDown.Items.Add(new ListItem(row["Name"].ToString() + " -- " + row["Price"].ToString(), row["idComponent"].ToString()));
                        break;
                    default:
                        break;
                }
            }
        }

        private void AddComputers(DataTable tab)
        {
            foreach (DataRow row in tab.Rows)
            {
                String key = GenerateIDList(tab.Columns.Count, row);
                ComputerDropDown.Items.Add(new ListItem(row["ConfigurationName"].ToString(), key));
            }
        }

        private string GenerateIDList(int columnCount, DataRow row)
        {
            string containsString = "(";

            //Skip the first column as it is always the configuration name
            for (int i = 1; i < columnCount; i++)
            {
                containsString += row[i].ToString() + ",";
            }

            //Trim last comma
            containsString = containsString.Substring(0, containsString.Length - 1);
            containsString += ")";

            return containsString;


        }

        private void CalculateTotalComputerWindow()
        {
            List<int> rgPartsSelected = new List<int> { };

            rgPartsSelected.Add(Convert.ToInt32(OSDropDown.SelectedItem.Value.ToString()));
            rgPartsSelected.Add(Convert.ToInt32(GPUDropDown.SelectedItem.Value.ToString()));
            rgPartsSelected.Add(Convert.ToInt32(HardDriveDropDown.SelectedItem.Value.ToString()));
            rgPartsSelected.Add(Convert.ToInt32(DisplayDropDown.SelectedItem.Value.ToString()));
            rgPartsSelected.Add(Convert.ToInt32(CpuDropDown.SelectedItem.Value.ToString()));
            rgPartsSelected.Add(Convert.ToInt32(RamDropDown.SelectedItem.Value.ToString()));

            String include = "(" + String.Join(",", rgPartsSelected) + ")";

            Session["LastSelectedComputerList"] = include;

            MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
            String s = "Select Sum(Price) as \"TotalPrice\" from computer_components where idComponent IN " + include;
            MySqlCommand cmd = new MySqlCommand("Select Sum(Price) as \"TotalPrice\" from computer_components where idComponent IN " + include, con);

            con.Open();
            var reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                TotalCostModal.Text = "Total Cost: " + reader["TotalPrice"];
            }

        }

        private class Computer
        {

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
                foreach (ComputerComponent comp in rgComponents)
                {
                    total += comp.Cost;
                }

                return total;
            }

            public void ReplacePart(ComputerComponent comp)
            {
                String type = comp.Type;
                foreach (ComputerComponent currentComp in rgComponents)
                {
                    if (type == currentComp.Type)
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
                htmlText += "<image width=\"300\" height=\"200\" src=\"Images\\" + configurationName + ".jpg\"></image><br/>";

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


            public ComputerComponent(string type, string name, double cost)
            {
                Type = type;
                Name = name;
                Cost = cost;
            }
        }

        protected void CancelComputer_Click(object sender, EventArgs e)
        {
            modalDialogComputer.Visible = false;
        }

        protected void AddComputer_Click(object sender, EventArgs e)
        {
            List<int> rgPartsSelected = new List<int> { };

            AddItemToCart(Convert.ToInt32(OSDropDown.SelectedItem.Value));
            AddItemToCart(Convert.ToInt32(GPUDropDown.SelectedItem.Value));
            AddItemToCart(Convert.ToInt32(HardDriveDropDown.SelectedItem.Value));
            AddItemToCart(Convert.ToInt32(DisplayDropDown.SelectedItem.Value));
            AddItemToCart(Convert.ToInt32(CpuDropDown.SelectedItem.Value));
            AddItemToCart(Convert.ToInt32(RamDropDown.SelectedItem.Value));

            modalDialogComputer.Visible = false;
        }

        protected void SubmitFormFeedback_Click(object sender, EventArgs e)
        {
            Response.Redirect("ComputerStore.aspx");
        }

        protected void FeedbackLink_ServerClick(object sender, EventArgs e)
        {
            ComputerComponentContent.Visible = false;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = false;
            FeedbackForm.Visible = true;
        }

        protected void ContactsLink_ServerClick(object sender, EventArgs e)
        {
            ComputerComponentContent.Visible = false;
            computerDisplayList.Visible = false;
            ContactsPage.Visible = true;
            FeedbackForm.Visible = false;
        }

        protected void CloseCart_Click(object sender, EventArgs e)
        {
            ShoppingCartContents.Visible = false;
            RecalcCart();
        }

        protected void SubmitCart_Click(object sender, EventArgs e)
        {
            if (Session["User"] != null)
            {
                String username = Session["User"].ToString();
                Dictionary<int, int> rgValues = (Dictionary<int, int>)Session["items"];
                String order = DictToString(rgValues);
                MySqlConnection con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                String s = "Insert into user_orders(Username,OrderContent) Values('" + username + "','" + order + "')";
                MySqlCommand cmd = new MySqlCommand("Insert into user_orders(Username,OrderContent) Values('" + username + "','" + order +"')", con);

                con.Open();

                cmd.ExecuteNonQuery();

                con.Close();

                Session["items"] = new Dictionary<int, int> { };
                ShoppingCartContents.Visible = false;
                RecalcCart();
            }
            else
            {
                SubmitError.Text = "Please Log In to submit an order";
            }
        }

        protected void DeleteItemFromCart(object sender, EventArgs e)
        {
            Dictionary<int, int> rgItems = (Dictionary<int, int>)Session["Items"];
            int id = Convert.ToInt32(((Button)sender).CommandArgument.ToString());

            rgItems.Remove(id);

            ViewShoppingCartContents(null, null);
        }

        protected void Login_Click(object sender, EventArgs e)
        {
            Response.Redirect("Login.aspx/?ReturnURL="+ System.Web.HttpContext.Current.Request.Url.AbsoluteUri);
        }

        protected void CreateUser_Click(object sender, EventArgs e)
        {
            Response.Redirect("RegisterUser.aspx");
        }

        protected void ViewContents_Click(object sender, EventArgs e)
        {
            Response.Redirect("PriorOrders.aspx");
        }

        protected void Logout_Click(object sender, EventArgs e)
        {
            Session["User"] = null;
            CurrentUserLoggedIn.Text = "";
            LoggedIn.Visible = false;
            NotLoggedIn.Visible = true;
        }

        public  string DictToString(Dictionary<int, int> source)
        {
            var pairs = source.Select(x => string.Format("{0}{1}{2}", x.Key, ":", x.Value));

            return string.Join(" ", pairs);
        }
    }
}