using System;
using BusinessObjectLayer;
using BusinessLogicLayer;

namespace BattlingElementalTitans
{
    public partial class Activate : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            /*
             * Query String
             * Source: http://www.dotnetperls.com/querystring
             **/
            string username = Request.QueryString["username"];
            if (username != null)
            {
                lblMsg.Text = "Your username is: " + username;
            }          
            string activateCode = Request.QueryString["activateCode"];
            BO_User bo = new BO_User();  
            bo.ActivateCode = Convert.ToInt32(activateCode);
            bo.Username = username;
            BL_User bl = new BL_User();
            try
            {
                int activateStatus = bl.record_activate(bo);
                if (activateStatus == 1)
                {
                    // Update status
                    BO_User boUpdate = new BO_User();
                    boUpdate.Username = username;
                    BL_User blUpdate = new BL_User();
                    int updateStatus = blUpdate.record_activate_update(boUpdate);
                    if (updateStatus == 1)
                    {
                        lblMsg.Text = "Activate success.";
                    }
                    else
                    {
                        lblMsg.Text = "Failed to activate your account due to an internal error, please try again.";
                    }
                }
                else
                {
                    lblMsg.Text = "Incorrect activate link.";
                }
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
    }
}