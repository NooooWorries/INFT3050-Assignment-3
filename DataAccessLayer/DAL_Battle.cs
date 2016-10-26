using System;
using BusinessObjectLayer;
using System.Data.SqlClient;
using System.Data;

namespace DataAccessLayer
{
    public class DAL_Battle
    {
        public int Battle(BO_Battle battleDetails)
        {
            // Create a new titan

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblBattle values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j)", con);
            try
            {
                cmd.Parameters.AddWithValue("@a", battleDetails.Username);
                cmd.Parameters.AddWithValue("@b", battleDetails.EnemyUsername);
                cmd.Parameters.AddWithValue("@c", battleDetails.TitanName);
                cmd.Parameters.AddWithValue("@d", battleDetails.EnemyTitanName);
                cmd.Parameters.AddWithValue("@e", battleDetails.Date);
                cmd.Parameters.AddWithValue("@f", battleDetails.Result);
                cmd.Parameters.AddWithValue("@g", battleDetails.ExpObtained);
                cmd.Parameters.AddWithValue("@h", battleDetails.Element);
                cmd.Parameters.AddWithValue("@i", battleDetails.EnemyElement);
                cmd.Parameters.AddWithValue("@j", battleDetails.IsChallenger);
                return cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cmd.Dispose();
                con.Close();
                con.Dispose();
            }
        }

        public DataSet history(BO_User userDetails)
        {
            // Get a list of personalize battle history
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT DISTINCT titanName, enemyTitanName, result, date FROM tblBattle b where username ='" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }
    }
}
