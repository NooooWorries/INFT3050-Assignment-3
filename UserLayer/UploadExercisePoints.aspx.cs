using System;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web.UI;
using BusinessLogicLayer;
using BusinessObjectLayer;
namespace BattlingElementalTitans
{
    public partial class ExerciseUpload : System.Web.UI.Page
    {
        Random r = new Random();
        static int uid;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
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
            if (Session["UploadExercisePoints_TimeStamp"] == null)
                return false;
            else if (ViewState["TimeStamp"] == null)
                return false;
            else if (ViewState["TimeStamp"].ToString() ==
                     Session["UploadExercisePoints_TimeStamp"].ToString())
                return false;
            else
                return true;
        }

        // Source: Lecture slides 7a
        private void SaveTimeStamps()
        {
            DateTime dtm = DateTime.Now;
            ViewState.Add("TimeStamp", dtm);
            Session.Add("UploadExercisePoints_TimeStamp", dtm);
        }

        /* 
         * Send activate link to user
         * Source:http://stackoverflow.com/questions/32260/sending-email-in-net-through-gmail
         */
        private void sendEmail()
        {
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
                BO_User bo = new BO_User();
                bo.Username = username;
                BL_User bl = new BL_User();
                string parentsEmail = "";
                try
                {
                    parentsEmail = bl.record_parentsEmail(bo);
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
                }
                finally
                {
                    bl = null;
                }
                msg.To.Add(new MailAddress(parentsEmail));

                string activateAddress = "http://localhost:50655/ValidateExercise.aspx?username=" + username + "&uid=" + uid.ToString();
                msg.Subject = "Validate your child's exercise point";
                msg.IsBodyHtml = true;
                msg.Body = string.Format("<html><head></head><body><b>Your child tried to upload " + tbxSteps.Text.ToString() + " steps exercise record just now. <br />Please check the authenticity of your child's exercise record. You must validate in 24 hours. Once validated, click the link below to confirm : <br />" + activateAddress + " </b></body>");

                try
                {
                    client.Send(msg);
                }
                catch (Exception ex)
                {
                    script = "alert(" + ex.Message + ");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    Response.Redirect("Error.aspx",false);
                }
            }
            else
            {
                script = "alert(\"Incorrect email format for your parent's email address, please contact customer service.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void btnSubmitRecord_Click(object sender, ImageClickEventArgs e)
        {
            string script = script = "alert(\"\");";
            // Check the steps and convert to experience points
            int experiencePoints = 0;
            try
            {
                experiencePoints = Convert.ToInt32(Convert.ToInt32(tbxSteps.Text) * 0.01) ;
            }
            catch (Exception ex)
            {
                script = "alert(\"" + ex.Message + "\");";
            }
            // Need to save validation code from database in assignment.
            if (experiencePoints > 0)
            {
                // Generate pid and validation code
                uid = r.Next(100000000, 999999999);
                BO_User bo = new BO_User();
                bo.Uid = uid;      
                bo.Username = username;
                if (experiencePoints > 500)
                {
                    script = "alert(\"Maximum amount allowed per day are 500 points or 50000 steps. Please enter again.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (experiencePoints < 1)
                {
                    script = "alert(\"Minimum number of steps must be 100\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }

                else
                {
                    bo.TempExercisePoints = experiencePoints;
                    bo.OneDayExercisePoints = experiencePoints;
                    BL_User bl = new BL_User();
                    int status = 0;
                    try
                    {
                        status = bl.record_updateTempExercisePoints(bo);
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
                    }
                    finally
                    {
                        bl = null;
                    }
                    if (status == 1)
                    {
                        sendEmail();
                        string scriptS = "alert(\"Update success. Once your parents validated, exercise points will add to your account automatically.\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptS, true);
                    }
                    else if (status == 0)
                    {
                        string scriptS = "alert(\"Update failed, please try again\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptS, true);
                    }
                    else if (status == 2)
                    {
                        string scriptS = "alert(\"You have reached the maximum number of time (1) you can upload your exercise points today\");";
                        ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", scriptS, true);
                    }
                    
                }
            }
        }
    }
}