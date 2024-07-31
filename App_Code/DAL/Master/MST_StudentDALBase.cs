using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;

namespace GNForm3C
{
    public class MST_StudentDALBase : DataBaseConfig
    {
        #region Properties

        private string _Message;
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

        #endregion Properties

        #region Constructor
        public MST_StudentDALBase()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #endregion Constructor

        #region InsertOperation

        public Boolean Insert(MST_StudentENT entMST_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Insert");

                sqlDB.AddOutParameter(dbCMD, "@StudentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.NVarChar, entMST_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.NVarChar, entMST_Student.EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, entMST_Student.RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, entMST_Student.CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitute", SqlDbType.NVarChar, entMST_Student.EmailInstitute);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.NVarChar, entMST_Student.EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.NVarChar, entMST_Student.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, entMST_Student.Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Student.UserID);
                sqlDB.AddInParameter(dbCMD, "@BirthDate", SqlDbType.DateTime, entMST_Student.BirthDate);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Student.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Student.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                entMST_Student.StudentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@StudentID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_StudentENT entMST_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Update");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, entMST_Student.StudentID);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.NVarChar, entMST_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.NVarChar, entMST_Student.EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, entMST_Student.RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, entMST_Student.CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitute", SqlDbType.NVarChar, entMST_Student.EmailInstitute);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.NVarChar, entMST_Student.EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.NVarChar, entMST_Student.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, entMST_Student.Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, entMST_Student.UserID);
                sqlDB.AddInParameter(dbCMD, "@BirthDate", SqlDbType.DateTime, entMST_Student.BirthDate);
                sqlDB.AddInParameter(dbCMD, "@Created", SqlDbType.DateTime, entMST_Student.Created);
                sqlDB.AddInParameter(dbCMD, "@Modified", SqlDbType.DateTime, entMST_Student.Modified);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Delete");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_StudentENT SelectPK(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectPK");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                MST_StudentENT entMST_Student = new MST_StudentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entMST_Student.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["StudentName"].Equals(System.DBNull.Value))
                            entMST_Student.StudentName = Convert.ToString(dr["StudentName"]);

                        if (!dr["EnrollmentNo"].Equals(System.DBNull.Value))
                            entMST_Student.EnrollmentNo = Convert.ToString(dr["EnrollmentNo"]);

                        if (!dr["RollNo"].Equals(System.DBNull.Value))
                            entMST_Student.RollNo = Convert.ToInt32(dr["RollNo"]);

                        if (!dr["CurrentSem"].Equals(System.DBNull.Value))
                            entMST_Student.CurrentSem = Convert.ToInt32(dr["CurrentSem"]);

                        if (!dr["EmailInstitute"].Equals(System.DBNull.Value))
                            entMST_Student.EmailInstitute = Convert.ToString(dr["EmailInstitute"]);

                        if (!dr["EmailPersonal"].Equals(System.DBNull.Value))
                            entMST_Student.EmailPersonal = Convert.ToString(dr["EmailPersonal"]);

                        if (!dr["ContactNo"].Equals(System.DBNull.Value))
                            entMST_Student.ContactNo = Convert.ToString(dr["ContactNo"]);

                        if (!dr["Gender"].Equals(System.DBNull.Value))
                            entMST_Student.Gender = Convert.ToString(dr["Gender"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMST_Student.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["BirthDate"].Equals(System.DBNull.Value))
                            entMST_Student.BirthDate = Convert.ToDateTime(dr["BirthDate"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Student.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Student.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                }
                return entMST_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        public DataTable SelectView(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectView");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectAll");

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectAll");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                return dtMST_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString StudentName, SqlString EnrollmentNo, SqlInt32 RollNo, SqlInt32 CurrentSem, SqlString EmailInstitute, SqlString EmailPersonal, SqlString ContactNo, SqlString Gender)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.VarChar, StudentName);
                sqlDB.AddInParameter(dbCMD, "@EnrollmentNo", SqlDbType.VarChar, EnrollmentNo);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitute", SqlDbType.VarChar, EmailInstitute);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.VarChar, EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.VarChar, Gender);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);

                DataTable dtMST_Student = new DataTable("PR_MST_Student_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Student);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtMST_Student;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion SelectOperation

    }
}