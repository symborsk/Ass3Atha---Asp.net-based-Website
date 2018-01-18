using System;
using System.Data;
using MySql.Data.MySqlClient;

namespace WebApplication1
{
    public partial class slideshow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                DataTable rgNameCaptions = GetPicturesFromDatabase();
                Session["Images"] = rgNameCaptions;
                Session["CurrentPictureIndex"] = 0;
            }
        }

        protected void SlideShowTimer_Tick(object sender, EventArgs e)
        {
            String val = SequenceOption.SelectedValue.ToString();
            if( val == "Random")
            {
                Random rand = new Random();
                int index = rand.Next(0, 19);
                SetPicture(index);
            }
            else
            {
                NextPicture();
            }
        }

        protected void StartStop_Click(object sender, EventArgs e)
        {
            if(SlideShowTimer.Enabled == true)
            {
                SlideShowTimer.Enabled = false;
                StartStop.Text = "Start";
            }
            else
            {
                SlideShowTimer.Enabled = true;
                StartStop.Text = "Stop";
            }
        }

        protected void Previous_Click(object sender, EventArgs e)
        {
            String val = SequenceOption.SelectedValue.ToString();
            if (val == "Sequential")
            {
                PreviousPicture();
            }
        }

        protected void Next_Click(object sender, EventArgs e)
        {
            String val = SequenceOption.SelectedValue.ToString();
            if (val == "Sequential")
            {
                NextPicture();
            }
        }

        private DataTable GetPicturesFromDatabase()
        {
            DataTable tab = new DataTable();
            MySqlConnection con;
            try
            {
                con = new MySqlConnection("Data Source=localhost;Initial Catalog=sys; User Id=root;password=symbor97;");
                MySqlCommand cmd = new MySqlCommand("Select * from slideshow", con);
                MySqlDataAdapter sda = new MySqlDataAdapter();

                sda.SelectCommand = cmd;
                sda.Fill(tab);
                con.Close();
            }
            catch (Exception ex)
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Failue Connecting To Database", "alert('" + ex.Message + "');", true);
                tab = null;
            }

            return tab;
        }
        private void NextPicture()
        {
            int currentIndex = Convert.ToInt32(Session["CurrentPictureIndex"].ToString());
            if (currentIndex != 19)
            {
                currentIndex++;
            }
            else
            {
                currentIndex = 0;
            }

            SetPicture(currentIndex);
            Session["CurrentPictureIndex"] = currentIndex;
        }

        private void PreviousPicture()
        {
            int currentIndex = Convert.ToInt32(Session["CurrentPictureIndex"].ToString());
            if (currentIndex != 0)
            {
                currentIndex--;
            }
            else
            {       
                currentIndex = 19;
            }

            SetPicture(currentIndex);
            Session["CurrentPictureIndex"] = currentIndex;
        }

        private void SetPicture(int index)
        {
            DataTable tab = (DataTable) Session["Images"];

            String picUrl = @"Images\" + tab.Rows[index]["pic_name"].ToString();
            String caption = tab.Rows[index]["caption"].ToString();

            SlideshowImage.ImageUrl = picUrl;
            Caption.Text = caption;
        }
    }
}