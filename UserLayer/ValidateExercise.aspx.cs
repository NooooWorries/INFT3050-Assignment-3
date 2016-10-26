using System;
using BusinessLogicLayer;
using BusinessObjectLayer;

namespace BattlingElementalTitans
{
    public partial class ValidateExercise : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Query String
             * Source: http://www.dotnetperls.com/querystring
             **/
            string username = Request.QueryString["username"];
            int uid = 0;
            try
            {
                // If user enter string in validation address, use try catch to avoid program crash
                uid = Convert.ToInt32(Request.QueryString["uid"]);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            Boolean isValid = false;
            lblMsg.Text = "Your child's exercise record id is : " + uid;
            // Get uid from database
            BO_User bo = new BO_User();
            bo.Username = username;
            bo.Uid = uid;
            BL_User bl = new BL_User();
            try
            {
                isValid = bl.record_validateUid(bo);     
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            if (isValid == false)
            {
                lblMsg.Text += "Incorrect validation address.";
            }
            else
            {
                int status = 0;
                try
                {
                    status = bl.record_exercisePoints_update(bo);
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
                }
                finally
                {
                    bo = null;
                    bl = null;
                }
                if (status == 1)
                    lblMsg.Text += "\nValidate success!";
                else
                    lblMsg.Text += "\nValidate failed, please refresh this page to try again!";
            }
                       
        }
    }
}