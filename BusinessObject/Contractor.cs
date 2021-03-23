using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class Contractor
    {
        public Contractor()
        {
            ContractorID = 0;
            ContractorName = "";
            ContractorType = EnumContractorType.None;
            Email = "";
            Mobile = "";
            CompanyName = "";
            ContractorTypeInInt = 0;
            Code = "";
            Address = "";
            ErrorMessage = "";
        }
        #region Property
        public int ContractorID { get; set; }
        public string ContractorName { get; set; }
        public string CompanyName { get; set; }
        public EnumContractorType ContractorType { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public string Address { get; set; }
        public int ContractorTypeInInt { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property
        public string ContractorTypeSt
        {
            get
            {
                return this.ContractorType.ToString();
            }
        }
        #endregion
    }
    public interface IContractor
    {
        List<Contractor> Gets(int nBUID, int nUserID);
        List<Contractor> GetsByContractorType(EnumContractorType oContractorType, int nUserID);
        List<Contractor> Gets(string sSQL, int nBUID, int nUserID);
        Contractor Get(int nID, int nUserIDID);
        Contractor IUD(Contractor oContractor, int nUnserID);
        string Delete(Contractor oContractor, int nUserIDID);
    }


}
