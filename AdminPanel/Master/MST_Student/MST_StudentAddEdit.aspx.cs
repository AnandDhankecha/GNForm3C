using GNForm3C.BAL;
using GNForm3C.ENT;
using GNForm3C;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_StudentAddEdit : System.Web.UI.Page
{
    #region 10.0 Local Variables 

    String FormName = "MST_StudentAddEdit";

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
            #region 11.2 Fill Labels 

            FillLabels(FormName);

            #endregion 11.2 Fill Labels 

            #region 11.3 DropDown List Fill Section 

            FillDropDownList();

            #endregion 11.3 DropDown List Fill Section 

            #region 11.4 Set Control Default Value 

            lblFormHeader.Text = CV.PageHeaderAdd + " Student ";
            upr.DisplayAfter = CV.UpdateProgressDisplayAfter;
            txtStudentName.Focus();

            #endregion 11.4 Set Control Default Value 

            #region 11.5 Fill Controls 

            FillControls();

            #endregion 11.5 Fill Controls 

            #region 11.6 Set Help Text 

            ucHelp.ShowHelp("Help Text will be shown here");

            #endregion 11.6 Set Help Text 

        }
    }

    #endregion 11.0 Page Load Event

    #region 12.0 FillLabels 

    private void FillLabels(String FormName)
    {
    }

    #endregion 12.0 FillLabels 

    #region 13.0 Fill DropDownList 

    private void FillDropDownList()
    {
        CommonFillMethods.FillDropDownListGender(ddlGender);
        CommonFillMethods.FillDropDownListCurrentSem(ddlCurrentSem);

    }

    #endregion 13.0 Fill DropDownList

    #region 14.0 FillControls By PK  

    private void FillControls()
    {
        if (Request.QueryString["StudentID"] != null)
        {
            lblFormHeader.Text = CV.PageHeaderEdit + " Student ";
            MST_StudentBAL balMST_StudentBAL = new MST_StudentBAL();
            MST_StudentENT entMST_Student = new MST_StudentENT();
            entMST_Student = balMST_StudentBAL.SelectPK(CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]));

            if (!entMST_Student.StudentName.IsNull)
                txtStudentName.Text = entMST_Student.StudentName.Value.ToString();

            if (!entMST_Student.EnrollmentNo.IsNull)
                txtEnrollmentNo.Text = entMST_Student.EnrollmentNo.Value.ToString();

            if (!entMST_Student.RollNo.IsNull)
                txtRollNo.Text = entMST_Student.RollNo.ToString();

            if (!entMST_Student.CurrentSem.IsNull)
                ddlCurrentSem.SelectedValue = entMST_Student.CurrentSem.Value.ToString();

            if (!entMST_Student.EmailInstitute.IsNull)
                txtEmailInstitute.Text = entMST_Student.EmailInstitute.Value.ToString();

            if (!entMST_Student.EmailPersonal.IsNull)
                txtEmailPersonal.Text = entMST_Student.EmailPersonal.Value.ToString();

            if (!entMST_Student.BirthDate.IsNull)
                dtpBirthDate.Text = entMST_Student.BirthDate.Value.ToString();

            if (!entMST_Student.ContactNo.IsNull)
                txtContactNo.Text = entMST_Student.ContactNo.Value.ToString();

            if (!entMST_Student.Gender.IsNull)
                ddlGender.Text = entMST_Student.Gender.Value.ToString();

        }
    }

    #endregion 14.0 FillControls By PK 

    #region 15.0 Save Button Event 

    protected void btnSave_Click(object sender, EventArgs e)
    {
        Page.Validate();
        if (Page.IsValid)
        {
            try
            {
                MST_StudentBAL balMST_Student = new MST_StudentBAL();
                MST_StudentENT entMST_Student = new MST_StudentENT();

                #region 15.1 Validate Fields 

                String ErrorMsg = String.Empty;
                if (txtStudentName.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Student Name");
                if (txtEnrollmentNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Enrollmentno");

                if (ddlCurrentSem.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Current Sem ");

                if (txtEmailPersonal.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Personal Email");
                if (dtpBirthDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birth Date");
                if (txtContactNo.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("ContactNo");
                if (dtpBirthDate.Text.Trim() == String.Empty)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredField("Birth Date");
                if (ddlGender.SelectedIndex == 0)
                    ErrorMsg += " - " + CommonMessage.ErrorRequiredFieldDDL("Gender");

                if (ErrorMsg != String.Empty)
                {
                    ErrorMsg = CommonMessage.ErrorPleaseCorrectFollowing() + ErrorMsg;
                    ucMessage.ShowError(ErrorMsg);
                    return;
                }

                #endregion 15.1 Validate Fields

                #region 15.2 Gather Data 


                if (txtStudentName.Text.Trim() != String.Empty)
                    entMST_Student.StudentName = txtStudentName.Text.Trim();

                if (txtEnrollmentNo.Text.Trim() != String.Empty)
                    entMST_Student.EnrollmentNo = txtEnrollmentNo.Text.Trim();

                if (txtEnrollmentNo.Text.Trim() != String.Empty)
                    entMST_Student.EnrollmentNo = txtEnrollmentNo.Text.Trim();

                if (txtRollNo.Text.Trim() != String.Empty)
                    entMST_Student.RollNo = Convert.ToInt32(txtRollNo.Text.Trim());

                if (txtEmailInstitute.Text.Trim() != String.Empty)
                    entMST_Student.EmailInstitute = txtEmailInstitute.Text.Trim();

                if (txtEmailPersonal.Text.Trim() != String.Empty)
                    entMST_Student.EmailPersonal = txtEmailPersonal.Text.Trim();

                if (dtpBirthDate.Text.Trim() != String.Empty)
                    entMST_Student.BirthDate = Convert.ToDateTime(dtpBirthDate.Text.Trim());

                if (txtContactNo.Text.Trim() != String.Empty)
                    entMST_Student.ContactNo = txtContactNo.Text.Trim();

                if (txtEnrollmentNo.Text.Trim() != String.Empty)
                    entMST_Student.EnrollmentNo = txtEnrollmentNo.Text.Trim();

                if (ddlCurrentSem.SelectedIndex > 0)
                    entMST_Student.CurrentSem = Convert.ToInt32(ddlCurrentSem.SelectedValue);

                if (ddlGender.SelectedIndex > 0)
                    entMST_Student.Gender = ddlGender.SelectedValue.ToString();

                entMST_Student.UserID = Convert.ToInt32(Session["UserID"]);

                entMST_Student.Created = DateTime.Now;

                entMST_Student.Modified = DateTime.Now;


                #endregion 15.2 Gather Data 


                #region 15.3 Insert,Update,Copy 

                if (Request.QueryString["StudentID"] != null && Request.QueryString["Copy"] == null)
                {
                    entMST_Student.StudentID = CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]);
                    if (balMST_Student.Update(entMST_Student))
                    {
                        Response.Redirect("MST_StudentList.aspx");
                    }
                    else
                    {
                        ucMessage.ShowError(balMST_Student.Message);
                    }
                }
                else
                {
                    if (Request.QueryString["StudentID"] == null || Request.QueryString["Copy"] != null)
                    {
                        if (balMST_Student.Insert(entMST_Student))
                        {
                            ucMessage.ShowSuccess(CommonMessage.RecordSaved());
                            ClearControls();
                        }
                    }
                }

                #endregion 15.3 Insert,Update,Copy

            }
            catch (Exception ex)
            {
                ucMessage.ShowError(ex.Message);
            }
        }
    }

    #endregion 15.0 Save Button Event 

    #region 16.0 Clear Controls 

    private void ClearControls()
    {
        txtStudentName.Text = String.Empty;
        txtEnrollmentNo.Text = String.Empty;
        ddlCurrentSem.SelectedIndex = 0;
        ddlGender.SelectedIndex = 0;

        txtRollNo.Text = String.Empty;
        txtEmailInstitute.Text = String.Empty;
        txtEmailPersonal.Text = String.Empty;
        dtpBirthDate.Text = String.Empty;
        txtContactNo.Text = String.Empty;
        txtStudentName.Focus();
    }

    #endregion 16.0 Clear Controls 
}