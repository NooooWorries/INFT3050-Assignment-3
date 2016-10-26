using System;
using BusinessLogicLayer;
using BusinessObjectLayer;
using System.Data;
namespace BattlingElementalTitans
{
    public partial class Menu : System.Web.UI.MasterPage
    {
        String username;
        protected void Page_Load(object sender, EventArgs e)
        {
           /*
           * Query String
           * Source: http://www.dotnetperls.com/querystring
           **/
            username = Request.QueryString["username"];
            if (username != null)
            {
                lblUsername.Text = username;
            }

            // get profile picture path from database
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_User bl = new BL_User();
            try
            {
                string profilePictureLocation = bl.record_profilePicture(bo);
                imgProfilePicture.ImageUrl = profilePictureLocation;
                lblScreenName.Text = bl.record_profile(bo).Tables[0].Rows[0]["screenName"].ToString();
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            finally
            {
                bl = null;
            }
        }

        protected void ImageButton1_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx?username=" + lblUsername.Text,false);
        }

        protected void ImageButton2_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("SelectRival.aspx?username=" + lblUsername.Text, false);
        }

        protected void ImageButton3_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("FightHistory.aspx?username=" + lblUsername.Text, false);
        }

        protected void ImageButton4_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("CreateCharacter.aspx?username=" + lblUsername.Text, false);
        }

        protected void ImageButton5_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("ManageCharacter.aspx?username=" + lblUsername.Text, false);
        }

        protected void ImageButton6_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("HallOfFame.aspx?username=" + lblUsername.Text, false);
        }

        protected void ImageButton7_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("UploadExercisePoints.aspx?username=" + lblUsername.Text, false);
        }

        protected void ImageButton8_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("ManageExercisePoints.aspx?username=" + lblUsername.Text, false);
        }

        protected void imgProfilePicture_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("UploadProfilePicture.aspx?username=" + lblUsername.Text, false);
        }
    }
}