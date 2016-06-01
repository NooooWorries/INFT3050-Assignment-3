using System;
using System.Web.UI;
using BusinessLogicLayer;
using BusinessObjectLayer;
using System.Data;

namespace BattlingElementalTitans
{
    public partial class FightOutcome : System.Web.UI.Page
    {
        static string username;
        static string titanName;
        static string screenName;
        static string rivalScreenName;
        static string rivalTitanName;
        static string rivalUsername;
        static string element;
        static string enemyElement;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
            titanName = Request.QueryString["titanName"];
            screenName = Request.QueryString["screenName"];
            rivalScreenName = Request.QueryString["rivalScreenName"];
            rivalTitanName = Request.QueryString["rivalTitanName"];
            element = Request.QueryString["element"];
            enemyElement = Request.QueryString["enemyElement"];

            lblPlayer.Text = screenName;
            lblPlayerEnemy.Text = rivalScreenName;
            lblTitan.Text = titanName;
            lblTitanEnemy.Text = rivalTitanName;

           

            // Get rival's username
            BO_User boUsername = new BO_User();
            boUsername.ScreenName = rivalScreenName;
            BL_User blUsername = new BL_User();
            try
            {
                rivalUsername = blUsername.record_username(boUsername);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            finally
            {
                blUsername = null;
            }

            // Connect to business layer
            // Business layer will calculate points and generate result
            BO_Battle bo = new BO_Battle();
            string[] result = new string[2];
            bo.Username = username;
            bo.TitanName = titanName;
            bo.Element = element;
            bo.EnemyUsername = rivalUsername;
            bo.EnemyTitanName = rivalTitanName;
            bo.EnemyElement = enemyElement;
            BL_Battle bl = new BL_Battle();
            try
            {
                if (!Page.IsPostBack)
                {
                    result = bl.fightResult(bo);
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
            lblRes.Text = result[0];
            lblExpObtained.Text = result[1];

            // Show titan information after information updated
            BO_Titan boTitan = new BO_Titan();
            BO_Titan boTitanRival = new BO_Titan();
            boTitan.Username = username;
            boTitan.TitanName = titanName;
            boTitanRival.Username = rivalUsername;
            boTitanRival.TitanName = rivalTitanName;
            DataSet titanInfo;
            DataSet rivalTitanInfo;
            BL_Titan blTitanInfo = new BL_Titan();
            try
            {
                titanInfo = blTitanInfo.recordFightInfo(boTitan);
                rivalTitanInfo = blTitanInfo.recordFightInfo(boTitanRival);
            }
            catch (Exception ex)
            {
                Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
            }
            finally
            {
                bl = null;
            }

            // Get fight info and show on the screen
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

        protected void btnBack_Click(object sender, ImageClickEventArgs e)
        {
            Response.Redirect("Main.aspx?username=" + username, false);
        }
    }
}