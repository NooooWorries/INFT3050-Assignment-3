using System;
using System.Web.UI;
using BusinessLogicLayer;
using BusinessObjectLayer;
namespace BattlingElementalTitans
{

    public partial class CreateCharacter : System.Web.UI.Page
    {
        /* 
         * Static variable belongs to class CreateCharacter only.
         * without static I cannot assign a value to these variables.
         */
        static string element;
        static string titan;
        string username;
        Boolean isFull;
        Boolean isUnique;
        Boolean isValidElement;
        int selection = 1;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];
        }

        protected void btnAir_Click(object sender, ImageClickEventArgs e)
        {
            // Make label and images visible and load titan images for air
            visualizeStepTwo();
            btnTitanOne.ImageUrl = "images/character/air1.jpg";
            btnTitanTwo.ImageUrl = "images/character/air2.jpg";
            btnTitanThree.ImageUrl = "images/character/air3.jpg";
            lblCharacterNameOne.Text = "Thunder Striker";
            lblCharacterNameTwo.Text = "Wind Cutter";
            lblCharacterNameThree.Text = "Air Ghost";
            element = "Air";
        }

        // Let labels and images visible
        private void visualizeStepTwo()
        {
            lblStepTwo.Visible = true;
            btnTitanOne.Visible = true;
            btnTitanTwo.Visible = true;
            btnTitanThree.Visible = true;
        }

        protected void btnEarth_Click(object sender, ImageClickEventArgs e)
        {
            visualizeStepTwo();
            btnTitanOne.ImageUrl = "images/character/earth1.jpg";
            btnTitanTwo.ImageUrl = "images/character/earth2.jpg";
            btnTitanThree.ImageUrl = "images/character/earth3.jpg";
            element = "Earth";
            lblCharacterNameOne.Text = "Moving Mountains";
            lblCharacterNameTwo.Text = "God of Trees";
            lblCharacterNameThree.Text = "Earth Giant";
        }

        protected void btnFire_Click(object sender, ImageClickEventArgs e)
        {
            visualizeStepTwo();
            btnTitanOne.ImageUrl = "images/character/fire1.jpg";
            btnTitanTwo.ImageUrl = "images/character/fire2.jpg";
            btnTitanThree.ImageUrl = "images/character/fire3.jpg";
            element = "Fire";
            lblCharacterNameOne.Text = "Fireballs Knight";
            lblCharacterNameTwo.Text = "Lava Destoryer";
            lblCharacterNameThree.Text = "Soul Burner";
        }

        protected void btnWater_Click(object sender, ImageClickEventArgs e)
        {
            visualizeStepTwo();
            btnTitanOne.ImageUrl = "images/character/water1.jpg";
            btnTitanTwo.ImageUrl = "images/character/water2.jpg";
            btnTitanThree.ImageUrl = "images/character/water3.jpg";
            element = "Water";
            lblCharacterNameOne.Text = "8-Tail Beast";
            lblCharacterNameTwo.Text = "Tsunami Monster";
            lblCharacterNameThree.Text = "King of Seas";
        }

        protected void btnTitanOne_Click(object sender, ImageClickEventArgs e)
        {
            selection = 1;
            visualizeStepThree();
            if (element == "Fire")
                titan = "Fireballs Knight";
            else if (element == "Water")
                titan = "8-Tall Beast";
            else if (element == "Earth")
                titan = "Moving Mountains";
            else if (element == "Air")
                titan = "Thunder Striker";
            lblChoice.Text = "Your choice is: " + element + ", " + titan;
        }

        private void visualizeStepThree()
        {
            lblChoice.Visible = true;
            lblStepThree.Visible = true;
            tbxName.Visible = true;
            btnCreate.Visible = true;
        }

        protected void btnTitanTwo_Click(object sender, ImageClickEventArgs e)
        {
            selection = 2;
            visualizeStepThree();
            if (element == "Fire")
                titan = "Lava Destoryer";
            else if (element == "Water")
                titan = "Tsunami Monster";
            else if (element == "Earth")
                titan = "God of Trees";
            else if (element == "Air")
                titan = "Wind Cutter";
            lblChoice.Text = "Your choice is: " + element + ", " + titan;
        }

        protected void btnTitanThree_Click(object sender, ImageClickEventArgs e)
        {
            selection = 3;
            visualizeStepThree();
            if (element == "Fire")
                titan = "Soul Burner";
            else if (element == "Water")
                titan = "King of Seas";
            else if (element == "Earth")
                titan = "Earth Giant";
            else if (element == "Air")
                titan = "Air Ghost";
            lblChoice.Text = "Your choice is: " + element + ", " + titan;
        }

        protected void btnCreate_Click(object sender, ImageClickEventArgs e)
        {
            if (tbxName.Text.Trim() != "")
            {
                // Validate name and character count               
                // this account already had 4 characters, cannot create. Delete one characte first, or 
                // duplicate titan name
                // other internal errors will redirect to error page and show error message
                BO_Titan boValidate = new BO_Titan();
                boValidate.Username = username;
                boValidate.TitanName = tbxName.Text.Trim();
                boValidate.Element = element;
                BL_Titan blValidate = new BL_Titan();
                try
                {
                    isFull = blValidate.recordTitanCount(boValidate);
                    isUnique = blValidate.recordDuplicateTitanName(boValidate);
                    isValidElement = blValidate.recordDuplicateElement(boValidate);
                }
                catch (Exception ex)
                {
                    Response.Redirect("Error.aspx?errorMessage=" + ex.Message, false);
                }
                finally
                {
                    boValidate = null;
                    blValidate = null;
                }
                if (isFull == true)
                {
                    string script = "alert(\"Maximun 4 Titans per account. Please delete before create a new one.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (isUnique == false)
                {
                    string script = "alert(\"Titan name already exist, please provide a new one.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else if (isValidElement == false)
                {
                    string script = "alert(\"The element you are trying to create had already exist, please choose other elements.\");";
                    ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                }
                else
                {
                    BO_Titan bo = new BO_Titan();
                    bo.Username = username;
                    bo.TitanName = tbxName.Text.Trim();
                    bo.Element = element;
                    bo.Selection = selection;
                    BL_Titan bl = new BL_Titan();
                    try
                    {
                        string result = bl.record_insert(bo);
                        if (result != null)
                        {
                            string script = "alert(\"Create success\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                            
                        }
                        else
                        {
                            string script = "alert(\"Create failed\");";
                            ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Redirect("Error.aspx?errorMessage=Database error", false);
                    }
                    finally
                    {
                        bo = null;
                        bl = null;
                    }
                }
            }
            else
            {
                string script = "alert(\"Please enter a valid name.\");";
                ScriptManager.RegisterStartupScript(this, GetType(), "ServerControlScript", script, true);
            }
        }
    }
}