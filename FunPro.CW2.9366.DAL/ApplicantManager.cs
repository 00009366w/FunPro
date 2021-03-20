using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlServerCe;
using System.Text;
using System.Windows.Forms;

namespace FunPro.CW2._9366.DAL
{
    public class ApplicantManager : DbManager
    {
        public void Create(Applicant a)
        {
            var connection = Connection;
            try
            {
                var sql = $@"
INSERT INTO Applicant (ap_name_9366, ap_score_9366, ap_tests_taken_9366) 
VALUES('{a.Name}', '{a.Score}', '{a.Tests_taken}',";
                var command = new SqlCeCommand(sql, connection);
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                if (connection.State != ConnectionState.Closed)
                {
                    connection.Close();
                }

            }
        }

        internal List<Applicant> GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
