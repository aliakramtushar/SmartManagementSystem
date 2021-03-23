using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMSEngine.GlobalClass
{
    public class GlobalEnum
    {
       
    }
    public class EnumClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
      
    }
    
    #region EnumUserType
    public enum EnumUserType
    {
        None = 0,
        Admin = 1,
        Manager = 2,
        Employee = 3
    }
    #endregion

    #region EnumEmployeeType
    public enum EnumEmployeeType
    {
        None = 0,
        Customer = 1,
        Supplier = 2,
        Buyer = 3,
    }
    #endregion

    #region EnumContractorType
    public enum EnumContractorType
    {
        None = 0,
        Supplier = 1,
        Buyer = 2,
        Customer = 3,
        Marketing_Person = 4,
    }
    #endregion
    #region EnumBillType
    public enum EnumBillStatus
    {
        None = 0,
        Paid = 1,
        Due = 2,
        Partial = 3,
    }
    #endregion

    #region EnumDBOperation
    public enum EnumDBOperation
    {
        None = 0,
        Insert = 1,
        Update = 2,
        Delete = 3,
        Accept = 4,
        Revise = 5,
        Custom_1 = 21
    }
    #endregion
    #region EnumMonth
    public enum EnumMonth
    {
        None = 0,
        January = 1,
        February = 2,
        March = 3,
        April = 4,
        May = 5,
        June = 6,
        July = 7,
        August = 8,
        September = 9,
        October = 10,
        November = 11,
        December = 12,
    }
    #endregion
}
