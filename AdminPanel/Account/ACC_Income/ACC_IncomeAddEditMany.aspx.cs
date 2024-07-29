using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System.Data.SqlTypes;
using System.Collections.Generic;

public partial class AdminPanel_Account_ACC_Income_ACC_IncomeAddEditMany : System.Web.UI.Page
{
    #region 10.0 Local Variables

    String FormName = "ACC_IncomeAddEdit";

    #endregion 10.0 Variables

    #region 11.0 Page Load Event
    protected void Page_Load(object sender, EventArgs e)
    {
        #region 11.1 Check User Login

        if (Session["UserID"] == null)
            Response.Redirect(CV.LoginPageURL);

        #endregion 11.1 Check User Login

        if (!Page.IsPostBack)
        {
            if (Request.QueryString["HospitalID"] != null)
            {
                btnShow_Click(sender, e);
            }

            #region 11.2 Fill Labels

            FillLabels(FormName);

            #endregion 11.2 Fill Labels

            #region 11.3 DropDown List Fill Section

            CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);

            #endregion 11.3 DropDown List Fill Section

            #region 11.4 Set Control Default Value

            lblFormHeader.Text = CV.PageHeaderMany + " Income";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;


            #endregion 11.4 Set Control Default Value
        }
    }

    #endregion Pageload

    #region 12.0 FillLabels
    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels

    #region 13.0 Fill DropDownList
    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListHospitalID(ddlHospitalID);
    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 Show Button Event
    protected void btnShow_Click(object sender, EventArgs e)
    {
        SqlInt32 HospitalID = SqlInt32.Null;

        #region NavigateLogic
        if (Request.QueryString["HospitalID"] != null)
        {
            if (!Page.IsPostBack)
            {
                HospitalID = CommonFunctions.DecryptBase64Int32(Request.QueryString["HospitalID"]);
            }
            else
            {
                if (ddlHospitalID.SelectedIndex > 0)
                    HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
            }
        }
        else
        {
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
        }
        #endregion NavigateLogic

        ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();

        DataTable dt = balACC_Income.SelectShow(HospitalID);

        if (Request.QueryString["HospitalID"] != null)
            ddlHospitalID.SelectedValue = CommonFunctions.DecryptBase64(Request.QueryString["HospitalID"]);

        foreach (DataColumn dtc in dt.Columns)
        {
            dtc.AutoIncrement = false;
            dtc.AllowDBNull = true;
        }
        dt.AcceptChanges();

        int count = 10 - dt.Rows.Count;
        for (int i = 1; i <= count; i++)
        {
            dt.Rows.Add();
        }

        rpData.DataSource = dt;
        rpData.DataBind();
        Div_ShowResult.Visible = true;

    }

    #endregion 14.0 Show Button Event

    #region 15.0 Save Button Event
    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();

        if (Page.IsValid)
        {
            SqlInt32 HospitalID = SqlInt32.Null;
            if (ddlHospitalID.SelectedIndex > 0)
                HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);

            ACC_IncomeBAL balACC_Income = new ACC_IncomeBAL();
            ACC_IncomeENT entACC_Income = new ACC_IncomeENT();

            foreach (RepeaterItem items in rpData.Items)
            {
                try
                {
                    #region FindControl



                    var ddlFinYearID = (DropDownList)items.FindControl("ddlFinYearID");
                    var ddlIncomeTypeID = (DropDownList)items.FindControl("ddlIncomeTypeID");

                    var dtpIncomeDate = (TextBox)items.FindControl("dtpIncomeDate");

                    TextBox txtAmount = (TextBox)items.FindControl("txtAmount");
                    HiddenField Hdfiled = (HiddenField)items.FindControl("hdIncomeID");
                    TextBox txtNote = (TextBox)items.FindControl("txtNote");
                    CheckBox chkIsSelected = (CheckBox)items.FindControl("chkIsSelected");


                    #endregion FindControl

                    #region 15.1.1 Gather Data

                    entACC_Income.HospitalID = Convert.ToInt32(ddlHospitalID.SelectedValue);
                    entACC_Income.FinYearID = Convert.ToInt32(ddlFinYearID.SelectedValue);
                    entACC_Income.IncomeTypeID = Convert.ToInt32(ddlIncomeTypeID.SelectedValue);
                    entACC_Income.IncomeDate = Convert.ToDateTime(dtpIncomeDate.Text);
                    entACC_Income.Amount = Convert.ToDecimal(txtAmount.Text);
                    entACC_Income.Note = Convert.ToString(txtNote.Text);
                    entACC_Income.UserID = Convert.ToInt32(Session["UserID"]);
                    entACC_Income.Created = DateTime.Now;
                    entACC_Income.Modified = DateTime.Now;

                    #endregion 15.1.1 Gather Data

                    if (Hdfiled.Value != string.Empty)
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.2 Update Data
                            if (ddlIncomeTypeID.Text.Trim() == string.Empty)
                            {
                                ddlIncomeTypeID.Focus();
                                ucMessage.ShowError("Enter Income Type");
                                break;
                            }
                            else
                            {
                                entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                if (balACC_Income.Update(entACC_Income))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.RecordUpdated());
                                }
                            }

                            #endregion 15.1.2 Update Data
                        }
                        else
                        {
                            #region 15.1.3 Delete Data
                            if (ddlIncomeTypeID.Text.Trim() == string.Empty)
                            {
                                ddlIncomeTypeID.Focus();
                                ucMessage.ShowError("Enter Income Type");
                                break;
                            }
                            else
                            {
                                entACC_Income.IncomeID = Convert.ToInt32(Hdfiled.Value);
                                if (balACC_Income.Delete(entACC_Income.IncomeID))
                                {
                                    ucMessage.ShowSuccess(CommonMessage.DeletedRecord());
                                }
                            }

                            #endregion 15.1.3 Delete Data
                        }
                    }
                    else
                    {
                        if (chkIsSelected.Checked)
                        {
                            #region 15.1.4 Insert Data
                            if (ddlIncomeTypeID.Text.Trim() == string.Empty && txtAmount.Text.Trim() != string.Empty)
                            {
                                ddlIncomeTypeID.Focus();
                                ucMessage.ShowError("Enter Income Type");
                            }
                            else
                            {
                                if (ddlIncomeTypeID.Text.Trim() != string.Empty)
                                {
                                    if (balACC_Income.Insert(entACC_Income))
                                    {
                                        Div_ShowResult.Visible = false;
                                        ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                                    }
                                }
                            }
                            #endregion  15.1.4 Insert Data
                        }
                    }
                    Div_ShowResult.Visible = false;
                }
                catch (Exception ex)
                {
                    ucMessage.ShowError(ex.Message);
                }
            }
            ClearControls();
        }
    }

    #endregion 15.0 Save Button Event

    #region 16.0 Clear Controls
    private void ClearControls()
    {
        ddlHospitalID.SelectedIndex = 0;
    }

    #endregion 16.0 Clear Controls

    #region 17.0 Add Row Button
    protected void btnAdd_Click(object sender, EventArgs e)
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("IncomeType");
        dt.Columns.Add("Remarks");
        dt.Columns.Add("IncomeTypeID");

        foreach (RepeaterItem rp in rpData.Items)
        {
            TextBox txtIncomeType = (TextBox)rp.FindControl("txtIncomeType");
            TextBox txtRemarks = (TextBox)rp.FindControl("txtRemarks");
            HiddenField hdIncomeTypeID = (HiddenField)rp.FindControl("hdIncomeTypeID");

            DataRow dr = dt.NewRow();
            dr["IncomeType"] = txtIncomeType.Text.Trim();
            dr["Remarks"] = txtRemarks.Text.Trim();
            dr["IncomeTypeID"] = hdIncomeTypeID.Value.ToString();

            dt.Rows.Add(dr);
        }
        int count = 0;
        foreach (DataRow dr in dt.Rows)
        {
            if (dr["IncomeType"].ToString() != String.Empty)
                count++;
        }
        if (count == dt.Rows.Count)
            dt.Rows.Add();

        rpData.DataSource = dt;
        rpData.DataBind();
    }
    #endregion 17.0 Add Row Button

    protected void rpData_ItemDataBound(object sender, RepeaterItemEventArgs e)
    {
        if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
        {
            var ddlFinYearID = (DropDownList)e.Item.FindControl("ddlFinYearID");
            var ddlIncomeTypeID = (DropDownList)e.Item.FindControl("ddlIncomeTypeID");
            var txtAmount = (TextBox)e.Item.FindControl("txtAmount");
            var hdIncomeID = (HiddenField)e.Item.FindControl("hdIncomeID");
            var txtNote = (TextBox)e.Item.FindControl("txtNote");
            var chkIsSelected = (CheckBox)e.Item.FindControl("chkIsSelected");
            var dtpIncomeDate = (TextBox)e.Item.FindControl("dtpIncomeDate");

            if (ddlFinYearID != null)
            {
                CommonFillMethods.FillSingleDropDownListFinYearID(ddlFinYearID);
                string finYearID = DataBinder.Eval(e.Item.DataItem, "FinYearID").ToString();
                if (ddlFinYearID.Items.FindByValue(finYearID) != null)
                {
                    ddlFinYearID.SelectedValue = finYearID;
                }
            }

            if (ddlIncomeTypeID != null)
            {
                CommonFillMethods.FillSingleDropDownListIncomeTypeID(ddlIncomeTypeID);
                string incomeTypeID = DataBinder.Eval(e.Item.DataItem, "IncomeTypeID").ToString();
                if (ddlIncomeTypeID.Items.FindByValue(incomeTypeID) != null)
                {
                    ddlIncomeTypeID.SelectedValue = incomeTypeID;
                }
            }

            if (txtAmount != null)
            {
                txtAmount.Text = DataBinder.Eval(e.Item.DataItem, "Amount").ToString();
            }

            if (hdIncomeID != null)
            {
                hdIncomeID.Value = DataBinder.Eval(e.Item.DataItem, "IncomeID").ToString();
            }

            if (txtNote != null)
            {
                txtNote.Text = DataBinder.Eval(e.Item.DataItem, "Note").ToString();
            }


            if (dtpIncomeDate != null)
            {
                DateTime incomeDate;
                if (DateTime.TryParse(DataBinder.Eval(e.Item.DataItem, "IncomeDate").ToString(), out incomeDate))
                {
                    dtpIncomeDate.Text = incomeDate.ToString("dd-MM-yyyy");
                }
            }
        }
    }

}