using System.Data;
using BusinessObjectLayer;
using System.Data.SqlClient;
using System;

namespace DataAccessLayer
{
    public class DAL_Titan
    {
        // Data access layer: access to database  
        // Source: http://www.msdotnet.co.in/2014/07/how-to-implement-3-tier-architecture.html#.V0UXM1f7jQc

        public DataSet titanName(BO_Titan titanDetails)
        {
            // Get a list of titan name of a specific user and return a dataset
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT titanName FROM tblTitan WHERE username = '" +
                     titanDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }

        public DataSet HOF (BO_Titan titanDetails)
        {
            // Get a list of hof titan and return a dataset
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT u.anonymous, u.firstName, u.screenName, t.titanName, t.battles, t.wins, t.loses, t.dateCreated FROM tblTitan t, tblUser u WHERE t.username = u.username and t.HOF= 'true' ORDER BY t.wins";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }
        public int titanCount (BO_Titan titanDetails)
        {
            // Get the titan count of a specific user
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT COUNT(*) FROM tblTitan WHERE username = '" +
                                                  titanDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int titanDuplicateName (BO_Titan titanDetails)
        {
            // Validate whether the titan name is exist
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT COUNT(*) FROM tblTitan WHERE username = '" +
                                                  titanDetails.Username + "' and titanName = '" +
                                                  titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int titanDuplicateElement(BO_Titan titanDetails)
        {
            // Validate whether the titan name is exist
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT COUNT(*) FROM tblTitan WHERE username = '" +
                                                  titanDetails.Username + "' and element = '" +
                                                  titanDetails.Element + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
        public string createTitan (BO_Titan titanDetails)
        {
            // Create a new titan

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblTitan values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l)", con);
            try
            {
                cmd.Parameters.AddWithValue("@a", titanDetails.Username);
                cmd.Parameters.AddWithValue("@b", titanDetails.TitanName);
                cmd.Parameters.AddWithValue("@c", titanDetails.Element);
                cmd.Parameters.AddWithValue("@d", 1);
                cmd.Parameters.AddWithValue("@e", 1);
                cmd.Parameters.AddWithValue("@f", 0);
                cmd.Parameters.AddWithValue("@g", 0);
                cmd.Parameters.AddWithValue("@h", 0);
                cmd.Parameters.AddWithValue("@i", 0);
                string time = DateTime.Now.ToString();
                cmd.Parameters.AddWithValue("@j", time);
                cmd.Parameters.AddWithValue("@k", "false");
                string pictureLocation = "/images/character/" +
                                         titanDetails.Element.ToLower() +
                                         titanDetails.Selection + ".jpg";
                cmd.Parameters.AddWithValue("@l", pictureLocation);
                return cmd.ExecuteNonQuery().ToString();
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

        public DataSet titanInfo (BO_Titan titanDetails)
        {
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT * FROM tblTitan WHERE username = '" +
                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }

        
        public int changeTitanName(BO_Titan titanDetails)
        {
            // Change the name of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET titanName = '" + titanDetails.TitanName+ "' WHERE username = '" + 
                                     titanDetails.Username + "' and element = '" + titanDetails.Element + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return '
                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int deleteTitan(BO_Titan titanDetails)
        {
            // Change the name of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "DELETE FROM tblTitan WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return '
                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateTitanExercisePoints(BO_Titan titanDetails)
        {
            // Change the exercise points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET experiencePoints = '" + titanDetails.ExperiencePoints + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int count = Convert.ToInt32(cmd.ExecuteScalar());
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int titanExercisePoints(BO_Titan titanDetails)
        {
            // Get titan's exercise points
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT experiencePoints FROM tblTitan WHERE username = '" +
                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int exercisePoints = Convert.ToInt32(cmd.ExecuteScalar());
                return exercisePoints;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public string HOFStatus (BO_Titan titanDetails)
        {
            // Get titan's Hall of fame status
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT HOF FROM tblTitan WHERE username = '" +
                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string HOF = cmd.ExecuteScalar().ToString();
                return HOF;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int experiencePoints(BO_Titan titanDetails)
        {
            // Get titan's exp
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT experiencePoints FROM tblTitan WHERE username = '" +
                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int exp = Convert.ToInt32(cmd.ExecuteScalar());
                return exp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int battles(BO_Titan titanDetails)
        {
            // Get battle count
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT battles FROM tblTitan WHERE username = '" +
                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int exp = Convert.ToInt32(cmd.ExecuteScalar());
                return exp;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public DataSet rivalList(BO_Titan titanDetails)
        {
            // Get the rival list
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT u.anonymous, t.titanName, u.screenName, u.firstName, t.element, t.level, t.step FROM tblTitan t, tblUser u WHERE t.username = u.username and u.username <> '" +
                     titanDetails.Username + "' and t.HOF = 'false' ";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }

        public DataSet levelStep (BO_Titan titanDetails)
        {
            DataSet dataSet = new DataSet();
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
                {
                    con.Open();
                    string queryString = "SELECT level, step FROM tblTitan t, tblUser u WHERE u.username = t.username and titanName ='" + titanDetails.TitanName + "'and u.screenName ='" + titanDetails.ScreenName + "'";
                    SqlCommand cmd = new SqlCommand(queryString, con);
                    SqlDataAdapter adap = new SqlDataAdapter(cmd);
                    adap.Fill(dataSet);
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return dataSet;
        }

        public DataSet fightInfo(BO_Titan titanDetails)
        {
            // Get the fight info (based on screen name)
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT  t.element, t.pictureLocation, t.level, t.step, t.experiencePoints, t.wins, t.loses FROM tblTitan t, tblUser u WHERE t.username = u.username and u.screenName ='" + titanDetails.ScreenName + "' and t.titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }

        public DataSet fightInfo_Username(BO_Titan titanDetails)
        {
            // Get the fight info (based on username)
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT  t.element, t.pictureLocation, t.level, t.step, t.experiencePoints, t.wins, t.loses FROM tblTitan t, tblUser u WHERE t.username = u.username and u.username ='" + titanDetails.Username + "' and t.titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }

        public int updateExperiencePoints(BO_Titan titanDetails)
        {
            // Change the experience points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET experiencePoints = '" + titanDetails.ExperiencePoints + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateLevel(BO_Titan titanDetails)
        {
            // Change the exercise points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET level = '" + titanDetails.Level + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateBattle(BO_Titan titanDetails)
        {
            // Change the battle count of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET battles = '" + titanDetails.Battles + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return '
                int count = cmd.ExecuteNonQuery();
                return count;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateStep(BO_Titan titanDetails)
        {
            // Change the exercise points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET step = '" + titanDetails.Step + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateHOF(BO_Titan titanDetails)
        {
            // Change the exercise points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET HOF = '" + titanDetails.HOF + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateWins(BO_Titan titanDetails)
        {
            // Change the exercise points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET wins = '" + titanDetails.Wins + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }

        public int updateLoses(BO_Titan titanDetails)
        {
            // Change the exercise points of a specific titan
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblTitan SET loses = '" + titanDetails.Loses + "' WHERE username = '" +
                                     titanDetails.Username + "' and titanName = '" + titanDetails.TitanName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
                int result = Convert.ToInt32(cmd.ExecuteScalar());
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
        }
    }
}
