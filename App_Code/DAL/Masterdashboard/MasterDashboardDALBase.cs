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
    public class MasterDashboardDALBase : DataBaseConfig
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
        public MasterDashboardDALBase()
        {

        }
        #endregion Constructor

        #region Select

        #region Select Total Income/Expense
        public DataTable SelectTotalIncomeExpense(SqlInt32 hospitalID)
        {
            try
            {
                // Create a new SqlDatabase instance with the connection string
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);

                // Create a DbCommand for the stored procedure with a parameter
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DSB_GetTotalIncomeExpenseAmountPatientCount");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", DbType.Int32, hospitalID);


                // Create a DataTable to hold the results
                DataTable dtCount = new DataTable("PR_DSB_GetTotalIncomeExpenseAmountPatientCount");

                // Load the DataTable with the results from the stored procedure
                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCount);

                return dtCount;
            }
            catch (SqlException sqlex)
            {
                // Handle SQL exceptions
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                // Handle general exceptions
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }
        #endregion Select Total Income/Expense

        #region Select Day Wise Month Wise Income
        public DataTable SelectDayWiseMonthWiseIncome(SqlInt32 HospitalID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DSB_GetDayWiseMonthWiseIncome");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", DbType.Int32, HospitalID);
                

                DataTable dtCount = new DataTable("DayWiseMonthWiseIncome");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCount);

                return dtCount;
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
        #endregion Select Day Wise Month Wise Income

        #region Select Day Wise Month Wise Expense
        public DataTable SelectDayWiseMonthWiseExpense(SqlInt32 HospitalID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DSB_GetDayWiseMonthWiseExpense");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", DbType.Int32, HospitalID);

                DataTable dtCount = new DataTable("DayWiseMonthWiseIncome");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCount);

                return dtCount;
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
        #endregion Select Day Wise Month Wise Income

        #region Select Treatment Wise Summary
        public DataTable SelectTreatmentWiseSummary(SqlInt32 HospitalID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_DSB_TreatmentWiseSummary");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", DbType.Int32, HospitalID);

                DataTable dtCount = new DataTable("PR_DSB_TreatmentWiseSummary");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCount);

                return dtCount;
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
        #endregion Select Treatment Wise Summary

        #endregion Select
    }
}