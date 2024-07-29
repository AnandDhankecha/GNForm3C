using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;


namespace GNForm3C.ENT
{
    public abstract class ACC_Explnm_LedgerENTBase
    {
        #region Properties


        protected SqlInt32 _LedgerID;
        public SqlInt32 LedgerID
        {
            get
            {
                return _LedgerID;
            }
            set
            {
                _LedgerID = value;
            }
        }

        protected SqlString _LedgerType;
        public SqlString LedgerType
        {
            get
            {
                return _LedgerType;
            }
            set
            {
                _LedgerType = value;
            }
        }

        protected SqlDecimal _LedgerAmount;
        public SqlDecimal LedgerAmount
        {
            get
            {
                return _LedgerAmount;
            }
            set
            {
                _LedgerAmount = value;
            }
        }

        protected SqlDateTime _LedgerDate;
        public SqlDateTime LedgerDate
        {
            get
            {
                return _LedgerDate;
            }
            set
            {
                _LedgerDate = value;
            }
        }

        protected SqlString _LedgerNote;
        public SqlString LedgerNote
        {
            get
            {
                return _LedgerNote;
            }
            set
            {
                _LedgerNote = value;
            }
        }

        #endregion Properties

        #region Constructor

        public ACC_Explnm_LedgerENTBase()
        {

        }

        #endregion Constructor

        #region ToString

        public override String ToString()
        {
            String ACC_Explnm_LEdgerENT_String = String.Empty;

            if (!LedgerID.IsNull)
                ACC_Explnm_LEdgerENT_String += " LedgerID = " + LedgerID.Value.ToString();

            if (!LedgerType.IsNull)
                ACC_Explnm_LEdgerENT_String += "| LedgerType = " + LedgerType.Value.ToString();

            if (!LedgerAmount.IsNull)
                ACC_Explnm_LEdgerENT_String += "| LedgerAmount = " + LedgerAmount.Value.ToString();

            if (!LedgerDate.IsNull)
                ACC_Explnm_LEdgerENT_String += "| LedgerDate = " + LedgerDate.Value.ToString("dd-MM-yyyy");

            if (!LedgerNote.IsNull)
                ACC_Explnm_LEdgerENT_String += "| LedgerNote = " + LedgerNote.Value;

            ACC_Explnm_LEdgerENT_String = ACC_Explnm_LEdgerENT_String.Trim();

            return ACC_Explnm_LEdgerENT_String;
        }

        #endregion ToString

    }

}