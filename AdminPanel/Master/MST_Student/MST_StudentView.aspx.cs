using GNForm3C;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class AdminPanel_Master_MST_Student_MST_StudentView : System.Web.UI.Page
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
            if (Request.QueryString["StudentID"] != null)
            {
                FillControls();
            }
        }
    }

    #endregion

    #region FillControls
    private void FillControls()
    {
        if (Request.QueryString["StudentID"] != null)
        {
            MST_StudentBAL balMST_Student = new MST_StudentBAL();
            DataTable dtMST_Student = balMST_Student.SelectView(CommonFunctions.DecryptBase64Int32(Request.QueryString["StudentID"]));
            if (dtMST_Student != null)
            {
                foreach (DataRow dr in dtMST_Student.Rows)
                {

                    if (!dr["StudentName"].Equals(DBNull.Value))
                        lblStudentName.Text = Convert.ToString(dr["StudentName"]);

                    if (!dr["EnrollmentNo"].Equals(DBNull.Value))
                        lblEnrollmentNo.Text = Convert.ToString(dr["EnrollmentNo"]);

                    if (!dr["RollNo"].Equals(DBNull.Value))
                        lblRollNo.Text = Convert.ToString(dr["RollNo"]);

                    if (!dr["CurrentSem"].Equals(DBNull.Value))
                        lblCurrentSem.Text = Convert.ToString(dr["CurrentSem"]);

                    if (!dr["EmailInstitute"].Equals(DBNull.Value))
                        lblEmailInstitute.Text = Convert.ToString(dr["EmailInstitute"]);

                    if (!dr["EmailPersonal"].Equals(DBNull.Value))
                        lblEmailPersonal.Text = Convert.ToString(dr["EmailPersonal"]);

                    if (!dr["BirthDate"].Equals(DBNull.Value))
                        lblBirthDate.Text = Convert.ToString(dr["BirthDate"]);

                    if (!dr["ContactNo"].Equals(DBNull.Value))
                        lblContactNo.Text = Convert.ToString(dr["ContactNo"]);

                    if (!dr["Gender"].Equals(DBNull.Value))
                        lblGender.Text = Convert.ToString(dr["Gender"]);

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