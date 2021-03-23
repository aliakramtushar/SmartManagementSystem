using System;
using System.Collections.Generic;
using System.Data.SqlClient;  
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Configuration;

namespace SMSEngine.DataBaseGateway
{
    public class CommonGateway
    {
        //private string ConnectionString = "Data Source=DESKTOP-4HV50SS\\SMARTMANAGEMENT;Database=SmartManagementSystem;User id=sa; Password=12345; Integrated Security=True;";
        private string ConnectionString = "Server=209.151.194.144,8494;Database=sms_chandpurelectric_db;User ID='aliakramtushar';password='2sR01676555291';Integrated Security=false";  // Alpha Net Hosting
        public SqlConnection Connection { get; set; }
        public SqlCommand Command { get; set; }
        public CommonGateway()
        {
            Connection = new SqlConnection(ConnectionString);
            Command = new SqlCommand();
            Command.Connection = Connection;
        }
    }
}
