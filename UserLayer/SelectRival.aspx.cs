using System;
using System.Web.UI;
using BusinessLogicLayer;
using BusinessObjectLayer;
using System.Data;
using System.Web.UI.WebControls;

namespace BattlingElementalTitans
{
    public partial class SelectRival : System.Web.UI.Page
    {
        string username;
        static string titan = "";
        static string screenName="";
        DataSet dataSet;
        static string rivalTitan = "";
        static string rivalScreenName = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            if (!Page.IsPostBack)
            {
                bindData(); // Get rival titan list
            }

            // Get my screen name
            // Get my titan list
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_User bl = new BL_User();
            try
            {
                screenName = bl.record_screenName(bo);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            finally
            {
                bl = null;
            }
            BO_Titan boTitan = new BO_Titan();
            boTitan.Username = username;
            BL_Titan blTitan = new BL_Titan();
            if (!Page.IsPostBack)
            {
                try
                {
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

        public void bindData()
        {
            // Get rival list from the database
            BO_Titan bo = new BO_Titan();
            bo.Username = username;
            BL_Titan bl = new BL_Titan();
            try
            {
                dataSet = bl.rivalList(bo);
                gridViewRival.DataSource = dataSet;
                gridViewRival.DataBind();
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

        protected void ImageButton1_Click(object sender, ImageClickEventArgs e)
        {

            if (dropTitan.Items.Count == 0)
            {
                string script = "alert(\"You do not have any titan to attend the battle.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else if (rivalTitan == "")
            {
                string script = "alert(\"Please select a rival titan\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else if (titan == "")
            {
                string script = "alert(\"Please choose a titan to attend the battle\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                BO_Titan bo = new BO_Titan();
                BO_Titan boRival = new BO_Titan();
                bo.TitanName = titan;
                boRival.TitanName = rivalTitan;
                bo.Username = username;
                bo.ScreenName = screenName;
                boRival.ScreenName = rivalScreenName;
                BL_Titan bl = new BL_Titan();
                int status = 0;
                try
                {
                    status = bl.IsAbleToFight(bo, boRival);
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
                }
                finally
                {
                    bl = null;
                }
                if (status == 0)
                {
                    string script = "alert(\"You cannot let a titan which is in Hall Of Fame to attend the battle\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (status == 2)
                {
                    string script = "alert(\"The level or step gap between you and rival is too large. \");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    Response.Redirect("Fight.aspx?username=" + username + 
                                       "&titanName=" + titan + 
                                       "&rivalScreenName=" + rivalScreenName +
                                       "&rivalTitanName=" + rivalTitan ,false);
                }
            }
        }

        protected void gridViewRival_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gridViewRival.PageIndex = e.NewPageIndex;
            bindData();
        }

        protected void gridViewRival_RowCommand(object sender, System.Web.UI.WebControls.GridViewCommandEventArgs e)
        {
            int index = Convert.ToInt32(e.CommandArgument);
            rivalTitan = gridViewRival.Rows[index].Cells[1].Text;
            rivalScreenName = gridViewRival.Rows[index].Cells[2].Text;
            lblRival.Text = "Rival: " + rivalTitan;
        }

        protected void dropTitan_SelectedIndexChanged(object sender, EventArgs e)
        {
            titan = dropTitan.SelectedValue;
        }
    }
}