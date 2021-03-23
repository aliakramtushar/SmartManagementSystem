using BusinessObject;
using SMSEngine.GlobalClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.DataAccess
{
    class ContractorDA
    {
        public static string IUD(Contractor oContractor, EnumDBOperation oDBOperation, int nUserID)
        {
            return GlobalHelpers.ExcecuteQurey("EXEC SP_IUD_Contractor",
                oContractor.ContractorID, oContractor.ContractorName, oContractor.CompanyName, (int)oContractor.ContractorType, oContractor.Email,
                oContractor.Mobile, oContractor.Code, oContractor.Address, (int)oDBOperation, nUserID);
        }
        public static string Gets(int nBUID, int nContractor)
        {
            return "SELECT * FROM View_Contractor";
        }
        public static string GetsByContractorType(EnumContractorType nContractorType, int nContractor)
        {
            return "SELECT * FROM View_Contractor WHERE ContractorType = " + (int)nContractorType;
        }
        public static string Gets(string sSQL, int nBUID, int nContractor)
        {
            return sSQL;
        }
        public static string Get(int nID, int nContractorID)
        {
            return "SELECT * FROM View_Contractor WHERE [ContractorID] =" + nID;
        }

    }
}
