using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjectLayer;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace DataAccessLayer
{
    public class DAL_User
    {
        // Data access layer: access to database  
        // Source: http://www.msdotnet.co.in/2014/07/how-to-implement-3-tier-architecture.html#.V0UXM1f7jQc
        public string registration_details(BO_User regDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            SqlCommand cmd = new SqlCommand("insert into tblUser values(@a,@b,@c,@d,@e,@f,@g,@h,@i,@j,@k,@l,@m,@n)", con);
            try
            {
                cmd.Parameters.AddWithValue("@a", regDetails.Username);
                cmd.Parameters.AddWithValue("@b", regDetails.Password);
                cmd.Parameters.AddWithValue("@c", regDetails.ParentsEmail);
                cmd.Parameters.AddWithValue("@d", 100);
                cmd.Parameters.AddWithValue("@e", 0);
                cmd.Parameters.AddWithValue("@f", "false");
                cmd.Parameters.AddWithValue("@g", regDetails.ActivateCode);
                cmd.Parameters.AddWithValue("@h", regDetails.ProfilePictureLocation);
                cmd.Parameters.AddWithValue("@i", regDetails.ScreenName);
                cmd.Parameters.AddWithValue("@j", regDetails.Anonymous);
                cmd.Parameters.AddWithValue("@k", regDetails.FirstName);
                cmd.Parameters.AddWithValue("@l", 0);
                string startDate = DateTime.Now.AddDays(-1).ToString(); ;     
                cmd.Parameters.AddWithValue("@m", startDate);
                cmd.Parameters.AddWithValue("@n", 0);
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

        public int duplicateUsername(BO_User userDetails)
        {
            // Validate whether the user name is exist
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT COUNT(*) FROM tblUser WHERE username = '" +
                                                  userDetails.Username + "'";
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

        public int activate_details (BO_User activateDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Valid - 1
                // Invalid - 0
                string queryString = "SELECT activateCode FROM tblUser WHERE username = '" +
                                                  activateDetails.Username + "' and activateStatus =  'false'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int activateCode = Convert.ToInt32(cmd.ExecuteScalar());
                int result = 0;
                if (activateCode == activateDetails.ActivateCode)
                {
                    result = 1;
                }
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

        public int activate_update (BO_User activateDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET activateStatus = 'true' WHERE username = '" + activateDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public int firstName_update(BO_User activateDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET firstName = '" + activateDetails.FirstName +"' WHERE username = '" + activateDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public int password_update(BO_User activateDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET password = '" + activateDetails.Password + "' WHERE username = '" + activateDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public int screenName_update(BO_User activateDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET screenName = '" + activateDetails.ScreenName + "' WHERE username = '" + activateDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public string password_details (BO_User passwordDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT password FROM tblUser WHERE username = '" + passwordDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string password = cmd.ExecuteScalar().ToString();
                return password;
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

        public string profilePicture_details (BO_User profilePictureDetails)
        {
            // Get the profile picture location from database
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT profilePictureLocation FROM tblUser WHERE username = '" + profilePictureDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string profilePictureLocation = cmd.ExecuteScalar().ToString();
                return profilePictureLocation;
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
        public string login_details(BO_User loginDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Count the username and password, if result is 0, that means username of password is incorrect.
                // This approach can let program to validate user account on server side
                // incorrect username or password return 0
                // not activated return -1
                // valid return 1
                string queryString = "SELECT COUNT(*) FROM tblUser WHERE username = '" +
                                                  loginDetails.Username + "' and password = '" +
                                                  loginDetails.Password + "'";
                SqlCommand cmd = new SqlCommand(queryString, con );
                string str = cmd.ExecuteScalar().ToString();

                if (str != "0")
                {
                    string activateString = "SELECT activateStatus FROM tblUser WHERE username = '" +
                                                      loginDetails.Username + "' and password = '" +
                                                      loginDetails.Password + "'";
                    SqlCommand activateCmd = new SqlCommand(activateString, con);
                    string activateStatus = activateCmd.ExecuteScalar().ToString();
                    if (activateStatus == "false")
                        str = "-1";
                }
                return str;
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

        public int exercisePoints_details(BO_User exercisePointsDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Valid - 1
                // Invalid - 0
                string queryString = "SELECT exercisePoints FROM tblUser WHERE username = '" +
                                                  exercisePointsDetails.Username + "'";
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

        public int updateTempExercisePoints(BO_User userDetails)
        {
            // Add exercise points to tempExercisePoints attribute.

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET tempExercisePoints = '"+ userDetails.TempExercisePoints + "'WHERE username = '" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public int getTempExercisePoints(BO_User userDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Valid - 1
                // Invalid - 0
                string queryString = "SELECT tempExercisePoints FROM tblUser WHERE username = '" +
                                                  userDetails.Username + "'";
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

        public string getOneDayStartTime(BO_User userDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Valid - 1
                // Invalid - 0
                string queryString = "SELECT OneDayStartTime FROM tblUser WHERE username = '" +
                                                  userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string oneDayStartDate = cmd.ExecuteScalar().ToString();
                return oneDayStartDate;
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

        public int getOneDayExercisePoints(BO_User userDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Valid - 1
                // Invalid - 0
                string queryString = "SELECT OneDayExercisePoints FROM tblUser WHERE username = '" +
                                                  userDetails.Username + "'";
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
        public int updateOneDayStartTime(BO_User userDetails)
        {
            // Add exercise points to tempExercisePoints attribute.

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET OneDayStartTime = '" + userDetails.OneDayStartTime + "'WHERE username = '" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public int updateUid(BO_User userDetails)
        {
            // Update exercise validation code

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET uid = '" + userDetails.Uid + "'WHERE username = '" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public string parentsEmail_details(BO_User userDetails)
        {
            // Get parents email
           
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                // Valid - 1
                // Invalid - 0
                string queryString = "SELECT parentsEmail FROM tblUser WHERE username = '" +
                                                 userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string email =cmd.ExecuteScalar().ToString();
                return email;
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

        public int uid_details(BO_User userDetails)
        {
            // Get exercise points validation ID

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT uid FROM tblUser WHERE username = '" +
                                                 userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                int uid = Convert.ToInt32(cmd.ExecuteScalar());
                return uid;
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

        public int updateExercisePoints(BO_User userDetails)
        {
            // Add exercise points toexercisePoints attribute.

            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET exercisePoints = '" + userDetails.ExercisePoints + "'WHERE username = '" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public int updateProfilePicture(BO_User userDetails)
        {
            // Update the lastest profile picture path (server side)
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "UPDATE tblUser SET profilePictureLocation = '" + userDetails.ProfilePictureLocation + "'WHERE username = '" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                // If success, return 1 else return 0
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

        public string screenName_details(BO_User userDetails)
        {
            // Get the screenName from database
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT screenName FROM tblUser WHERE username = '" + userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string screenName = cmd.ExecuteScalar().ToString();
                return screenName;
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
        public string username_details(BO_User userDetails)
        {
            SqlConnection con = new SqlConnection(ConnectionString.connectionString);
            con.Open();
            try
            {
                string queryString = "SELECT username FROM tblUser WHERE screenName='" + userDetails.ScreenName + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                string password = cmd.ExecuteScalar().ToString();
                return password;
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
        public DataSet getProfile(BO_User userDetails)
        {
            // Get user details and store in a dataset
            DataSet dataSet = new DataSet();
            using (SqlConnection con = new SqlConnection(ConnectionString.connectionString))
            {
                con.Open();
                string queryString = "SELECT screenName, firstName, password FROM tblUser WHERE username ='" +userDetails.Username + "'";
                SqlCommand cmd = new SqlCommand(queryString, con);
                SqlDataAdapter adap = new SqlDataAdapter(cmd);
                adap.Fill(dataSet);
            };
            return dataSet;
        }
    }
}
