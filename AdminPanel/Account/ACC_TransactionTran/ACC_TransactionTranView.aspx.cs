using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
public partial class AdminPanel_Account_ACC_TransactionTran_ACC_TransactionTranView: System.Web.UI.Page
{
	#region Page Load Event 

	protected void Page_Load(object sender, EventArgs e)
	{
		#region 10.1 Check User Login 

		if (Session["UserID"] == null)
			Response.Redirect(CV.LoginPageURL);
			
 #endregion 10.1 Check User Login 

			if (!Page.IsPostBack)
			{
				if (Request.QueryString["TransactionTranID"] != null)
				{
					FillControls();
				}
			}
		}
		
 #endregion  

		#region FillControls
		private void FillControls()
		{
			if (Request.QueryString["TransactionTranID"] != null) 
			{
				ACC_TransactionTranBAL balACC_TransactionTran = new ACC_TransactionTranBAL();
				DataTable dtACC_TransactionTran = balACC_TransactionTran.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["TransactionTranID"]));
				if (dtACC_TransactionTran != null)
				{
					foreach (DataRow dr in dtACC_TransactionTran.Rows)
					{

						if (!dr["TransactionTranID"].Equals(DBNull.Value))
							lblTransactionTranID.Text = Convert.ToString(dr["TransactionTranID"]);

						if (!dr["SubTreatmentName"].Equals(DBNull.Value))
							lblSubTreatmentName.Text = Convert.ToString(dr["SubTreatmentName"]);

						if (!dr["Quantity"].Equals(DBNull.Value))
							lblQuantity.Text = Convert.ToString(dr["Quantity"]);

						if (!dr["Unit"].Equals(DBNull.Value))
							lblUnit.Text = Convert.ToString(dr["Unit"]);

						if (!dr["Rate"].Equals(DBNull.Value))
							lblRate.Text = Convert.ToString(dr["Rate"]);

						if (!dr["Amount"].Equals(DBNull.Value))
							lblAmount.Text = Convert.ToString(dr["Amount"]);

						if (!dr["Remarks"].Equals(DBNull.Value))
							lblRemarks.Text = Convert.ToString(dr["Remarks"]);

						if (!dr["UserName"].Equals(DBNull.Value))
							lblUserName.Text = Convert.ToString(dr["UserName"]);

						if (!dr["Created"].Equals(DBNull.Value))
							lblCreated.Text = Convert.ToDateTime(dr["Created"]).ToString(CV.DefaultDateTimeFormat);

						if (!dr["Modified"].Equals(DBNull.Value))
							lblModified.Text = Convert.ToDateTime(dr["Modified"]).ToString(CV.DefaultDateTimeFormat);

					}
				}
			}
		}
		#endregion FillControls
	}
