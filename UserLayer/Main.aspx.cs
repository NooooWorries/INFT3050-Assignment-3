using System;
using BusinessObjectLayer;
using BusinessLogicLayer;
using System.Drawing;
using System.Data;
using System.Web.UI.WebControls;

namespace BattlingElementalTitans
{
    public partial class Main : System.Web.UI.Page
    {
        string username;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            // Get experience points
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_User bl = new BL_User();
            
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
            if (dropTitan.Items.Count != 0)
                dropTitan_SelectedIndexChanged(null, null);
        }

        protected void dropTitan_SelectedIndexChanged(object sender, EventArgs e)
        {           
                BO_Titan bo = new BO_Titan();
                bo.Username = username;
                bo.TitanName = dropTitan.SelectedValue;
                BL_Titan bl = new BL_Titan();

                // Get the information from database and show on the screen
                try
                {
                    DataSet titanInfo = bl.recordTitanInfo(bo);
                    lblName.Text = titanInfo.Tables[0].Rows[0]["titanName"].ToString();
                    lblElement.Text = titanInfo.Tables[0].Rows[0]["element"].ToString();
                    lblLevel.Text = titanInfo.Tables[0].Rows[0]["level"].ToString();
                    lblStep.Text = titanInfo.Tables[0].Rows[0]["step"].ToString();
                    lblExp.Text = titanInfo.Tables[0].Rows[0]["experiencePoints"].ToString();
                    lblBattle.Text = titanInfo.Tables[0].Rows[0]["battles"].ToString();
                    lblWin.Text = titanInfo.Tables[0].Rows[0]["wins"].ToString();
                    lblLose.Text = titanInfo.Tables[0].Rows[0]["loses"].ToString();
                    imgTitan.ImageUrl = titanInfo.Tables[0].Rows[0]["pictureLocation"].ToString();
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