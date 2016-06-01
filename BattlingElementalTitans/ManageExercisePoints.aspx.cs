using BusinessLogicLayer;
using BusinessObjectLayer;
using System;
using System.Data;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BattlingElementalTitans
{
    public partial class ManageExercisePoints : System.Web.UI.Page
    {
        static int addExercisePoints;
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_User bl = new BL_User();
            bindExercisePoints();
            // Get titan list from database and add to drop down list
            BO_Titan boTitan = new BO_Titan();
            boTitan.Username = username;
            BL_Titan blTitan = new BL_Titan();
            if (!Page.IsPostBack)
            {
                try
                {
                    int exercisePoints = bl.record_exercisePoints(bo);
                    lblExercisePoints.Text = exercisePoints.ToString();
                    DataSet titanList = blTitan.recordTitanList(boTitan);
                    // Add titan list to drop down list
                    for (int i = 0; i < titanList.Tables[0].Select("titanName is not null").Length; i++)
                    {
                        dropTitan.Items.Add(new ListItem(titanList.Tables[0].Rows[i][0].ToString()));
                    }
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
                }
                finally
                {
                    bl = null;
                    blTitan = null;
                }
            }
            if (dropTitan.Items.Count!= 0)
                dropTitan_SelectedIndexChanged(null, null);
            else
            {
                btnAdd.Visible = false;
            }
        }

        public void bindExercisePoints()
        {
            // get exercise points value and show on the screen
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_User bl = new BL_User();
            try
            {
                int exercisePoints = bl.record_exercisePoints(bo);
                lblExercisePoints.Text = exercisePoints.ToString();
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

        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxAdd.Text.Trim() != "")
            {
                addExercisePoints = Convert.ToInt32(tbxAdd.Text);
                BO_Titan bo = new BO_Titan();
                bo.Username = username;
                bo.TitanName = lblTitan.Text;
                bo.ExperiencePoints = addExercisePoints;
                BL_Titan bl = new BL_Titan();
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
                    bl = null;
                }
                if (status == 0) // Database error
                {
                    string script = "alert(\"Failed to arrange exercise points, please try again.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (status == 1) // Success
                {
                    string script = "alert(\"Success!\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                    // Refresh data
                    dropTitan_SelectedIndexChanged(null, null);
                    bindExercisePoints();
                    tbxAdd.Text = "";

                }
                else if (status == 2) // Success
                {
                    string script = "alert(\"Exercise points not enough.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (status == 3) // User try to give exercise points to a HOF Titan
                {
                    string script = "alert(\"You cannot give a HOF character any exercise points\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
            }
            else
            {
                string script = "alert(\"Please enter a valid number.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }

        protected void dropTitan_SelectedIndexChanged(object sender, EventArgs e)
        {
            BO_Titan bo = new BO_Titan();
            bo.Username = username;
            bo.TitanName = dropTitan.SelectedValue;
            BL_Titan bl = new BL_Titan();
            try
            {
                DataSet titanInfo = bl.recordTitanInfo(bo);
                lblTitan.Text = titanInfo.Tables[0].Rows[0]["titanName"].ToString();
                lblExe.Text = titanInfo.Tables[0].Rows[0]["experiencePoints"].ToString();
                imgTitan.ImageUrl = titanInfo.Tables[0].Rows[0]["pictureLocation"].ToString();
                lblLevel.Text = titanInfo.Tables[0].Rows[0]["level"].ToString();
                lblStep.Text = titanInfo.Tables[0].Rows[0]["step"].ToString();
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