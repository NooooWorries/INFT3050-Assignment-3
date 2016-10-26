using System;
using BusinessLogicLayer;
using BusinessObjectLayer;
using System.Data;

namespace BattlingElementalTitans
{
    public partial class Fight : System.Web.UI.Page
    {
        static string username;
        static string titanName;
        static string screenName;
        static string rivalScreenName;
        static string rivalTitanName;
        static string element;
        static string enemyElement;

        protected void Page_Load(object sender, EventArgs e)
        {
            
            username = Request.QueryString["username"];
            titanName = Request.QueryString["titanName"];
            rivalScreenName = Request.QueryString["rivalScreenName"];
            rivalTitanName = Request.QueryString["rivalTitanName"];

            // Get challenger's screenName
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_User bl = new BL_User();
            try
            {
                screenName = bl.record_screenName(bo);
                lblPlayer.Text = screenName;
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            finally
            {
                bl = null;
            }
            lblTitan.Text = titanName;
            lblPlayerEnemy.Text = rivalScreenName;
            lblTitanEnemy.Text = rivalTitanName;

            // Load challenger's details
            BO_Titan boChallenger = new BO_Titan();
            BO_Titan boRival = new BO_Titan();
            boChallenger.ScreenName = screenName;
            boChallenger.TitanName = titanName;
            boRival.ScreenName = rivalScreenName;
            boRival.TitanName = rivalTitanName;
            BL_Titan blFightInfo = new BL_Titan();
            DataSet challenger = new DataSet();
            DataSet rival = new DataSet();
            try
            {
                challenger = blFightInfo.recordFightInfo(boChallenger);
                rival = blFightInfo.recordFightInfo(boRival);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            finally
            {
                blFightInfo = null;
            }

            // Load picture
            imgTitan.ImageUrl = challenger.Tables[0].Rows[0]["pictureLocation"].ToString();
            imgTitanEnemy.ImageUrl = rival.Tables[0].Rows[0]["pictureLocation"].ToString();
            imgElement.ImageUrl = "/images/element/" + challenger.Tables[0].Rows[0]["element"].ToString() + ".jpg";
            imgElementEnemy.ImageUrl = "/images/element/" + rival.Tables[0].Rows[0]["element"].ToString() + ".jpg";

            element = challenger.Tables[0].Rows[0]["element"].ToString();
            enemyElement = rival.Tables[0].Rows[0]["element"].ToString();
            
            // Load information
            lblLevel.Text = challenger.Tables[0].Rows[0]["level"].ToString();
            lblLevelEnemy.Text = rival.Tables[0].Rows[0]["level"].ToString();

            lblSteps.Text = challenger.Tables[0].Rows[0]["step"].ToString();
            lblStepsEnemy.Text = rival.Tables[0].Rows[0]["step"].ToString();

            lblExp.Text = challenger.Tables[0].Rows[0]["experiencePoints"].ToString();
            lblExpEnemy.Text = rival.Tables[0].Rows[0]["experiencePoints"].ToString();

            lblWins.Text = challenger.Tables[0].Rows[0]["wins"].ToString();
            lblWinsEnemy.Text = rival.Tables[0].Rows[0]["wins"].ToString();

            lblLoses.Text = challenger.Tables[0].Rows[0]["loses"].ToString();
            lblLosesEnemy.Text = rival.Tables[0].Rows[0]["loses"].ToString();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Response.Redirect("FightOutcome.aspx",false);
        }

        protected void btnBattle_Click(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("FightOutcome.aspx?screenName=" + screenName +
                              "&titanName=" + titanName +
                              "&rivalScreenName=" + rivalScreenName + 
                              "&rivalTitanName="+ rivalTitanName +
                              "&username=" + username + 
                              "&element=" + element + 
                              "&enemyElement="+ enemyElement,false);
        }

        protected void btnCancel_Click1(object sender, System.Web.UI.ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx?username="+username,false);
        }
    }
}