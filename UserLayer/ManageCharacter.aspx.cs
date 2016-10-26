using BusinessLogicLayer;
using BusinessObjectLayer;
using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace BattlingElementalTitans
{
    public partial class ManageCharacter : System.Web.UI.Page
    {
        string username;
        string selectedItem;
        string element;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            bindTitanList();
            if (dropTitan.Items.Count != 0)
                dropTitan_SelectedIndexChanged(null, null);
            else
            {
                // If no character, hide function btns.
                btnChangeName.Visible = false;
                btnDelete.Visible = false;
                tbxChangeName.Visible = false;
            }
        }

        protected void dropTitan_SelectedIndexChanged(object sender, EventArgs e)
        {

            BO_Titan bo = new BO_Titan();
            bo.Username = username;
            selectedItem = dropTitan.SelectedValue;
            bo.TitanName = dropTitan.SelectedValue;
            BL_Titan bl = new BL_Titan();

            // Get the information from database and show on the screen
            try
            {
                DataSet titanInfo = bl.recordTitanInfo(bo);
                lblTitan.Text = titanInfo.Tables[0].Rows[0]["titanName"].ToString();
                lblElement.Text = titanInfo.Tables[0].Rows[0]["element"].ToString();
                lblLevel.Text = titanInfo.Tables[0].Rows[0]["level"].ToString();
                lblStep.Text = titanInfo.Tables[0].Rows[0]["step"].ToString();
                lblExp.Text = titanInfo.Tables[0].Rows[0]["experiencePoints"].ToString();
                lblBattle.Text = titanInfo.Tables[0].Rows[0]["battles"].ToString();
                lblWins.Text = titanInfo.Tables[0].Rows[0]["wins"].ToString();
                lblLoses.Text = titanInfo.Tables[0].Rows[0]["loses"].ToString();
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

        public void bindTitanList()
        {
            // Get titan list from database and add to drop down list
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
                    blTitan = null;
                }
            }
        }
        protected void btnChangeName_Click(object sender, EventArgs e)
        {
            if (tbxChangeName.Text.Trim() == "")
            {
                string script = "alert(\"Please provide a valid name\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
            else
            {
                // Update the name of a specific titan
                BO_Titan bo = new BO_Titan();
                bo.TitanName = tbxChangeName.Text.Trim(); // New name
                element = lblElement.Text;
                bo.Element = element;
                bo.Username = username;
                BL_Titan bl = new BL_Titan();
                try
                {
                    int updateStatus = bl.record_changeName_update(bo);
                    if (updateStatus == 1)
                    {
                        Response.Redirect("Main.aspx?username=" + username,false);
                    }
                    else
                    {
                        lblMsg.Text = "Update failed, please try again";
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

        protected void btnDelete_Click(object sender, EventArgs e)
        {
            // Delete a specific titan
            BO_Titan bo = new BO_Titan();
            bo.TitanName = lblTitan.Text; // New name        
            bo.Username = username;
            BL_Titan bl = new BL_Titan();
            try
            {
                int deleteStatus = bl.record_delete(bo);
                if (deleteStatus == 1)
                {
                    if (dropTitan.Items.Count != 1)
                    {
                        // Refresh data
                        dropTitan.Items.Remove(dropTitan.SelectedValue);
                        dropTitan_SelectedIndexChanged(null, null);
                    }
                    else
                    {
                        // Clear all data
                        dropTitan.Items.Clear();
                        lblElement.Text = "";
                        lblExp.Text = "";
                        lblLevel.Text = "";
                        lblLoses.Text = "";
                        lblStep.Text = "";
                        lblTitan.Text = "";
                        lblWins.Text = "";
                        lblBattle.Text = "";
                        imgTitan.ImageUrl = "";

                    }
                }
                else
                {
                    lblMsg.Text = "Delete failed, please try again";
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