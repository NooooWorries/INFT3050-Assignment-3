using System;
using BusinessLogicLayer;
using BusinessObjectLayer;
using System.Data;

namespace BattlingElementalTitans
{
    public partial class FightHistory : System.Web.UI.Page
    {
        string username;
        DataSet dataSet;
        protected void Page_Load(object sender, EventArgs e)
        {
            username = Request.QueryString["username"];

            if (!Page.IsPostBack)
            {
                bindData();
            }
        }

        public void bindData()
        {
            BO_User bo = new BO_User();
            bo.Username = username;
            BL_Battle bl = new BL_Battle();
            try
            {
                dataSet = bl.recordHistory(bo);
                gridViewHistory.DataSource = dataSet;
                gridViewHistory.DataBind();
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

        protected void gridViewHistory_PageIndexChanging(object sender, System.Web.UI.WebControls.GridViewPageEventArgs e)
        {
            gridViewHistory.PageIndex = e.NewPageIndex;
            bindData();
        }
    }
}