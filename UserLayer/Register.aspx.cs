using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BusinessObjectLayer;
using BusinessLogicLayer;

namespace BattlingElementalTitans
{
    public partial class Register : System.Web.UI.Page
    {
        static Random r = new Random(); // Generate vertification code and activate link
        static int activateCode = r.Next(10000000,99999999);
        protected void Page_Load(object sender, EventArgs e)
        {
            // Timestamp to solve back-button problems
            // Source: Lecture slides 7a
            if (IsExpired())
                Response.Redirect("Expired.aspx");
            else
                this.SaveTimeStamps();
            
                              
        }

        // check whether the timestamp is expired
        // Source: Lecture slides 7a
        private bool IsExpired()
        {
            if (Session["Register_TimeStamp"] == null)
                return false;
            else if (ViewState["TimeStamp"] == null)
                return false;
            else if (ViewState["TimeStamp"].ToString() ==
                     Session["Register_TimeStamp"].ToString())
                return false;
            else
                return true;
        }

        // Source: Lecture slides 7a
        private void SaveTimeStamps()
        {
            DateTime dtm = DateTime.Now;
            ViewState.Add("TimeStamp", dtm);
            Session.Add("Register_TimeStamp", dtm);
        }
    

    /* 
     * Send activate link to user
     * Source:http://stackoverflow.com/questions/32260/sending-email-in-net-through-gmail
     */

        private void sendEmail()
        {
            string username;
            username = tbxUsername.Text.Trim();

            string script = "alert(\"\");"; // Error message
            // Validate email format
            string emailStr = @"([a-zA-Z0-9_\.\-])+\@(([a-zA-Z0-9\-])+\.)+([a-zA-Z0-9]{2,5})+";
            Regex emailReg = new Regex(emailStr);
            if (emailReg.IsMatch(username))
            {
                // Send emails with password
                SmtpClient client = new SmtpClient();
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.EnableSsl = true;
                client.Host = "smtp.gmail.com";
                client.Port = 587;

                // setup Smtp authentication
                System.Net.NetworkCredential credentials =
                    new System.Net.NetworkCredential("czxbnb@gmail.com", "cheng2277980");
                client.UseDefaultCredentials = false;
                client.Credentials = credentials;

                MailMessage msg = new MailMessage();
                msg.From = new MailAddress("czxbnb@gmail.com", "B.E.T.T.E.R Account Center");
                msg.To.Add(new MailAddress(username));
                string activateAddress = "http://localhost:50655/Activate.aspx?username=" + username + "&activateCode=" + activateCode.ToString();
                msg.Subject = "Activate your B.E.T.T.E.R account";
                msg.IsBodyHtml = true;
                msg.Body = string.Format("<html><head></head><body><b>Please click the link below to activate your account: </br>" + activateAddress +" </b></body>");

               
                try
                {
                    client.Send(msg);
                    script = "alert(\"Almost success! One last step: go to your email inbox to activate your account!\");";
                    script += "window.close();";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                catch (Exception ex)
                {
                    script = "alert(" + ex.Message + ");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    Response.Redirect("Error.aspx", false); //Jump to error page
                }
            }
            else
            {
                script = "alert(\"Incorrect email format for username\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {
            string script = "";
            Boolean isUnique = true;
            try
            {
                BO_User boCheck = new BO_User();
                boCheck.Username = tbxUsername.Text.Trim();
                BL_User blCheck = new BL_User();
                isUnique = blCheck.recordDuplicateUsername(boCheck);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            if (tbxUsername.Text.Trim() == "" || tbxPassword.Text == "" || tbxRepeatPassword.Text == "" || tbxParentsEmail.Text.Trim() == "")
            {
                script = "alert(\"Please fulfill all details.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else if (tbxPassword.Text != tbxRepeatPassword.Text)
            {
                script = "alert(\"The two passwords you typed do not match.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else if (tbxUsername.Text.Trim() == tbxParentsEmail.Text.Trim())
            {
                script = "alert(\"Parents' email address should not be same as yours.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else if (isUnique == false)
            {
                script = "alert(\"Username already exist, please provide a new one.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                //Load or call Business object class in memory and get and set the value in variables
                BO_User bo = new BO_User();
                bo.Username = tbxUsername.Text.Trim();
                bo.Password = tbxPassword.Text;
                bo.ParentsEmail = tbxParentsEmail.Text;
                bo.ActivateCode = activateCode;
                bo.ProfilePictureLocation = "/ProfilePicture/sampleUser.jpg";
                bo.ScreenName = tbxScreenName.Text.Trim();
                bo.FirstName = tbxfirstName.Text.Trim();
                if (cbxAnonymous.Checked)
                    bo.Anonymous = "true";
                else
                    bo.Anonymous = "false";
                if (tbxfirstName.Text.Trim() == "")
                {
                    bo.Anonymous = "true";
                    bo.FirstName = "not provided";
                }
                BL_User bl = new BL_User();
                try
                {
                    string result = bl.record_insert(bo);
                    if (result != null && result != "2")
                    {
                        sendEmail();
                    }
                    else if (result == "2")
                    {
                        script = "alert(\"Password should has at least 8 characters.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
                    else
                    {
                        script = "alert(\"Register failed\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    }
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
               
            }
        }
    }
}
