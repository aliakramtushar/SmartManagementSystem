using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class Store
    {
        public Store()
        {
            StoreID = 0;
            StoreName = "";
            StoreShortName = "";
            Capacity = 0;
            TotalQty = 0;
            ProductCount = 0;
            ErrorMessage = "";
        }
        #region Property
        public int StoreID { get; set; }
        public string StoreName { get; set; }
        public string StoreShortName { get; set; }
        public double Capacity { get; set; }
        public double TotalQty { get; set; }
        public double ProductCount { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property

        #endregion
    }
    public interface IStore
    {
        List<Store> Gets(int nBUID, int nStore);
        List<Store> Gets(string sSQL, int nBUID, int nStore);
        Store Get(int nID, int nStoreID);
        Store IUD(Store oStore, int nUnserID);
        string Delete(Store oStore, int nStoreID);

    }


}
