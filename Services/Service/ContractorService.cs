using System;
using BusinessObject;
using Services;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.DataBaseGateway;
using Services.DataAccess;
using System.Data.SqlClient;
using SMSEngine.GlobalClass;

namespace Services.Service
{
    public class ContractorService : CommonGateway, IContractor
    {
        #region Maping
        private Contractor MapObject(SqlDataReader oReader)
        {
            Contractor oContractor = new Contractor();
            oContractor.ContractorID = (int)oReader["ContractorID"];
            oContractor.ContractorName = oReader["ContractorName"].ToString();
            oContractor.CompanyName = oReader["CompanyName"].ToString();
            oContractor.Email = oReader["Email"].ToString();
            oContractor.Mobile = oReader["Mobile"].ToString();
            oContractor.ContractorType = (EnumContractorType)oReader["ContractorType"];
            oContractor.Code = oReader["Code"].ToString();
            oContractor.Address = oReader["Address"].ToString();
            oContractor.ContractorTypeInInt = (int)oReader["ContractorType"];
            return oContractor;
        }
        private Contractor MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            Contractor oContractor = new Contractor();
            oContractor = MapObject(oReader);
            return oContractor;
        }
        private List<Contractor> MakeObjects(SqlDataReader oReader)
        {
            List<Contractor> oContractors = new List<Contractor>();
            while (oReader.Read())
            {
                Contractor oContractor = MapObject(oReader);
                oContractors.Add(oContractor);
            }
            return oContractors;
        }
        #endregion

        #region Function Implementation
        public Contractor IUD(Contractor oContractor, int nUserID)
        {
            Connection.Open();
            if (oContractor.ContractorID == 0)
            {
                Command.CommandText = ContractorDA.IUD(oContractor, EnumDBOperation.Insert, nUserID);
            }
            else
            {
                Command.CommandText = ContractorDA.IUD(oContractor, EnumDBOperation.Update, nUserID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            Contractor _oContractor = new Contractor();
            if (reader.HasRows)
            {
                _oContractor = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oContractor;
        }
        public string Delete(Contractor oContractor, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = ContractorDA.IUD(oContractor, EnumDBOperation.Delete, nUserID);
            try
            {
                Command.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                sReturnMessage = e.Message.Split('~')[0];
            }
            Connection.Close();
            return sReturnMessage;
        }
        public List<Contractor> Gets(int nBUID, int nContractor)
        {
            Connection.Open();
            Command.CommandText = ContractorDA.Gets(nBUID, nContractor);

            SqlDataReader reader = Command.ExecuteReader();
            Contractor _oContractor = new Contractor();
            List<Contractor> _oContractors = new List<Contractor>();
            if (reader.HasRows)
            {
                _oContractors = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oContractors;
        }
        public List<Contractor> GetsByContractorType(EnumContractorType oContractorType, int nContractor)
        {
            Connection.Open();
            Command.CommandText = ContractorDA.GetsByContractorType(oContractorType, nContractor);

            SqlDataReader reader = Command.ExecuteReader();
            Contractor _oContractor = new Contractor();
            List<Contractor> _oContractors = new List<Contractor>();
            if (reader.HasRows)
            {
                _oContractors = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oContractors;
        }
        
        public List<Contractor> Gets(string sSQL, int nBUID, int nContractor)
        {
            Connection.Open();
            Command.CommandText = ContractorDA.Gets(sSQL, nBUID, nContractor);

            SqlDataReader reader = Command.ExecuteReader();
            Contractor _oContractor = new Contractor();
            List<Contractor> _oContractors = new List<Contractor>();
            if (reader.HasRows)
            {
                _oContractors = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oContractors;
        }
        public Contractor Get(int nID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = ContractorDA.Get(nID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            Contractor _oContractor = new Contractor();
            if (reader.HasRows)
            {
                _oContractor = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oContractor;
        }
        #endregion

    }
}
