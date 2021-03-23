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
    public class UserService : CommonGateway, IUser
    {
        #region Maping
        private User MapObject(SqlDataReader oReader)
        {
            User oUser = new User();
            oUser.UserID = (int)oReader["UserID"];
            oUser.UserName = oReader["UserName"].ToString();
            oUser.Password = oReader["Password"].ToString();
            oUser.UserShortName = oReader["UserShortName"].ToString();
            oUser.Email = oReader["Email"].ToString();
            oUser.Validity = Convert.ToBoolean(oReader["Validity"]);
            oUser.Activity = Convert.ToBoolean(oReader["Activity"]);
            oUser.Mobile = oReader["Mobile"].ToString();
            oUser.UserType = (EnumUserType)oReader["UserType"];
            oUser.Code = oReader["Code"].ToString();
            oUser.UserTypeInInt = (int)oReader["UserType"];
            return oUser;
        }
        private User MakeObject(SqlDataReader oReader)
        {
            oReader.Read();
            User oUser = new User();
            oUser = MapObject(oReader);
            return oUser;
        }
        private List<User> MakeObjects(SqlDataReader oReader)
        {
            List<User> oUsers = new List<User>();
            while (oReader.Read())
            {
                User oUser = MapObject(oReader);
                oUsers.Add(oUser);
            }
            return oUsers;
        }
        #endregion

        #region Function Implementation
        public User IUD(User oUser, int nUserID)
        {
            Connection.Open();
            if(oUser.UserID==0)
            {
                Command.CommandText = UserDA.IUD(oUser, EnumDBOperation.Insert, nUserID);
            }
            else
            {
                Command.CommandText = UserDA.IUD(oUser, EnumDBOperation.Update, nUserID);
            }
            SqlDataReader reader = Command.ExecuteReader();
            User _oUser = new User();
            if (reader.HasRows)
            {
                _oUser = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oUser;
        }
        public string Delete(User oUser, int nUserID)
        {
            string sReturnMessage = "";
            Connection.Open();
            Command.CommandText = UserDA.IUD(oUser, EnumDBOperation.Delete, nUserID);
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
        public User ValidateLogin(int nBUID, User oUser)
        {
            Connection.Open();
            Command.CommandText = UserDA.ValidateLogin(nBUID, oUser);

            SqlDataReader reader = Command.ExecuteReader();
            User _oUser = new User();
            if(reader.HasRows)
            {
                _oUser = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oUser;
        }
        public List<User> Gets(int nBUID, int nUser)
        {
            Connection.Open();
            Command.CommandText = UserDA.Gets(nBUID, nUser);

            SqlDataReader reader = Command.ExecuteReader();
            User _oUser = new User();
            List<User> _oUsers = new List<User>();
            if (reader.HasRows)
            {
                _oUsers = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oUsers;
        }
        public List<User> Gets(string sSQL, int nBUID, int nUser)
        {
            Connection.Open();
            Command.CommandText = UserDA.Gets(sSQL, nBUID, nUser);

            SqlDataReader reader = Command.ExecuteReader();
            User _oUser = new User();
            List<User> _oUsers = new List<User>();
            if (reader.HasRows)
            {
                _oUsers = MakeObjects(reader);
            }
            reader.Close();
            Connection.Close();
            return _oUsers;
        }
        public User Get(int nID, int nUserID)
        {
            Connection.Open();
            Command.CommandText = UserDA.Get(nID, nUserID);

            SqlDataReader reader = Command.ExecuteReader();
            User _oUser = new User();
            if (reader.HasRows)
            {
                _oUser = MakeObject(reader);
            }
            reader.Close();
            Connection.Close();
            return _oUser;
        }
        #endregion

    }
}
