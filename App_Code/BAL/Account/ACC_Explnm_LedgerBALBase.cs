using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


namespace GNForm3C.BAL
{
    public abstract class ACC_Explnm_LedgerBALBase
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

        public ACC_Explnm_LedgerBALBase()
        {

        }

        #endregion Constructor



        #region SelectOperation

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlDateTime FromDate,SqlDateTime ToDate)
        {
            ACC_Explnm_LedgerDAL dalACC_Explnm_Ledger = new ACC_Explnm_LedgerDAL();
            return dalACC_Explnm_Ledger.SelectPage(PageOffset, PageSize, out TotalRecords,FromDate,ToDate);
        }

        #endregion SelectOperation

       

    }

}