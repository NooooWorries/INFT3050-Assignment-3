using System;
using BusinessLogicLayer;
using BusinessObjectLayer;
using System.Data;

namespace BattlingElementalTitans
{
    public partial class HallOfFame : System.Web.UI.Page
    {
        DataSet dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            
            if (!Page.IsPostBack)
            {
                BindData();
            }
        }

        public void BindData()
        {
            // read hof data from database
            BO_Titan bo = new BO_Titan();
            BL_Titan bl = new BL_Titan();
            try
            {
                dataSet = bl.recordHOF(bo);
                gridViewHOF.DataSource = dataSet;
                gridViewHOF.DataBind();
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

        protected void gridViewHOF_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gridViewHOF.PageIndex = e.NewPageIndex;
            BindData();
        }
    }
}