using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class MST_StudentBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Public Properties

        #region Constructor
        public MST_StudentBALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_StudentENT entMST_Student)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            if (dalMST_Student.Insert(entMST_Student))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Student.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_StudentENT entMST_Student)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            if (dalMST_Student.Update(entMST_Student))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Student.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 StudentID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            if (dalMST_Student.Delete(StudentID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Student.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_StudentENT SelectPK(SqlInt32 StudentID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectPK(StudentID);
        }

        public DataTable SelectView(SqlInt32 StudentID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectView(StudentID);
        }

        public DataTable SelectAll()
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectAll();
        }

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString StudentName, SqlString EnrollmentNo, SqlInt32 RollNo, SqlInt32 CurrentSem, SqlString EmailInstitute, SqlString EmailPersonal, SqlString ContactNo, SqlString Gender)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectPage(PageOffset, PageSize, out TotalRecords, StudentName, EnrollmentNo, RollNo, CurrentSem, EmailInstitute, EmailPersonal, ContactNo, Gender);
        }

        #endregion SelectOperation

    }
}