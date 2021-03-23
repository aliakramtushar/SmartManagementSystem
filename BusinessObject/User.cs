using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SMSEngine.GlobalClass;


namespace BusinessObject
{
    public class User
    {
        public User()
        {
            UserID = 0;
            UserName = "";
            Password = "";
            UserType = EnumUserType.None;
            Email = "";
            Validity = true;  // use for developer to delete a user.
            Activity = true;
            Mobile = "";
            UserTypeInInt = 0;
            UserShortName = "";
            Code = "";
            ErrorMessage = "";
        }
        #region Property
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserShortName { get; set; }
        public string Password { get; set; }
        public EnumUserType UserType { get; set; }
        public string Email { get; set; }
        public string Mobile { get; set; }
        public string Code { get; set; }
        public bool Validity { get; set; }
        public int UserTypeInInt { get; set; }
        public bool Activity { get; set; }
        public string ErrorMessage { get; set; }
        #endregion

        #region Derived Property
        public string UserTypeSt
        {
            get
            {
                return this.UserType.ToString();
            }
        }
        public string ActivitySt
        {
            get
            {
                if(Activity==true)
                {
                    return "ACTIVE USER";
                }
                else
                {
                    return "INACTIVE USER";
                }
            }
        }
        #endregion
    }
    public interface IUser
    {
        User ValidateLogin(int nBUID, User oUser);
        List<User> Gets(int nBUID, int nUser);
        List<User> Gets(string sSQL, int nBUID, int nUser);
        User Get(int nID, int nUserID);
        User IUD(User oUser, int nUnserID);
        string Delete(User oUser, int nuserID);
    }


}
