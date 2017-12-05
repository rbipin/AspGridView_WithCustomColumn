using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Web.UI.HtmlControls;
using DataLayer;

namespace AspDataGrid
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void Page_PreRender(object sender, EventArgs e)
        {
            GetData getGridViewData = new GetData();
            DataTable gridData = getGridViewData.GetGridData();
            aspGridView.DataSource = gridData;
            aspGridView.DataBind();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void aspGridView_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int rowIndex = 0;
            string ordernum = string.Empty;
            string approverid = string.Empty;
            UpdateData updateDataInDb = null;
            try
            {
                switch (e.CommandName)
                {
                    case "ApproveOrder":
                        rowIndex = Convert.ToInt32(e.CommandArgument);
                        GridViewRow row = aspGridView.Rows[rowIndex];
                        approverid = ((TextBox)row.FindControl("txtApproveId")).Text.ToString().Trim();
                        ordernum = row.Cells[0].Text.ToString().Trim();
                        updateDataInDb = new UpdateData();
                        updateDataInDb.UpdateApproverId(ordernum, approverid);
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void aspGridView_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            Button approveOrderBtn = null;
            DataRowView datarow = null;
            Label approvedBy = null;
            Label alertText = null;
            TextBox approvalid = null;
            HtmlGenericControl approvalSection = null;
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    datarow = (DataRowView)e.Row.DataItem;
                    if (!string.IsNullOrEmpty(datarow[5].ToString()))
                    {
                        approvalSection = (HtmlGenericControl)e.Row.FindControl("ApprovalSection");
                        approvalSection.Visible = false;
                        approvedBy = (Label)e.Row.FindControl("txtapprovedBy");
                        approvedBy.Visible = true;
                    }
                    else
                    {
                        approveOrderBtn = (Button)e.Row.FindControl("btnApproveOrder");
                        alertText = (Label)e.Row.FindControl("alertMsg");
                        approvalid = (TextBox)e.Row.FindControl("txtApproveId");
                        if (approveOrderBtn != null)
                            approveOrderBtn.OnClientClick = "return ValidateInput('" + approvalid.ClientID + "','" + alertText.ClientID + "')";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}