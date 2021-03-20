using System.Data.SqlServerCe;

namespace FunPro.CW2._9366.DAL
{
    public class DbManager
    {
        protected SqlCeConnection Connection
        {
            get
            {
                return new SqlCeConnection(Properties.Settings.Default.ConnectionString);
            }
        }
    }
}
