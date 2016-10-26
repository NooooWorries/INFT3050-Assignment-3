using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccessLayer;
using BusinessObjectLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BL_User
    {
        public string record_insert(BO_User regDetails)
        {
            DAL_User dal = new DAL_User();
            // password should has at least 8 characters.
            if (regDetails.Password.Length >= 8)
            {
                try
                {
                    return dal.registration_details(regDetails);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dal = null;
                }
            }
            else
            {
                return "2";
            }
        }
        public string record_login (BO_User loginDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.login_details(loginDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public DataSet record_profile(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.getProfile(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public Boolean recordDuplicateUsername(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                // Get the count of username
                // If count >=1, reject user's request to create a new user
                Boolean isUnique = false;
                int count = dal.duplicateUsername(userDetails);
                if (count == 0)
                    isUnique = true;
                return isUnique;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public int record_updateProfilePicture(BO_User userDetails)
        {
            // Change the profile picture location
            DAL_User dal = new DAL_User();
            try
            {
                return dal.updateProfilePicture(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public int record_updateFirstName(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.firstName_update(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public int record_updateScreenName(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.screenName_update(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public int record_updatePassword(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.password_update(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public int record_activate (BO_User activateDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.activate_details(activateDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public int record_activate_update(BO_User activateDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.activate_update(activateDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public string record_forgotPassword (BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.password_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public string record_profilePicture (BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.profilePicture_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }

        }
        public int record_exercisePoints(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.exercisePoints_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }

        }

        public int record_updateTempExercisePoints(BO_User userDetails)
        {
            // Check and update temp exercise points
            DAL_User dal = new DAL_User();
            int oneDayExercisePoints = 0;
            DateTime OneDayStartTime;
            int tempExercisePoints = 0;
            Int32 updateStatus = 0; // 1 success, 0 database error, 2 exceed than 1 time in 24 hrs.
            int updateExercisePoints = userDetails.OneDayExercisePoints; // exercise points that user want to update
            try
            {
                oneDayExercisePoints = dal.getOneDayExercisePoints(userDetails);
                OneDayStartTime = DateTime.Parse(dal.getOneDayStartTime(userDetails));
                tempExercisePoints = dal.getTempExercisePoints(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Calculate time span     
            
            if ((DateTime.Now - OneDayStartTime).TotalDays >= 1)
            {
                try
                {
                    // If more than 86400 seconds (1 day), and user want to update less than 500 points, update directly
                    userDetails.TempExercisePoints = updateExercisePoints;
                    updateStatus = dal.updateTempExercisePoints(userDetails);
                    userDetails.OneDayStartTime = DateTime.Now.ToString();
                    updateStatus = dal.updateOneDayStartTime(userDetails);
                    updateStatus = dal.updateUid(userDetails);
                }
                 catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dal = null;
                }
            }
            else
            {
                updateStatus = 2;
            }
            return updateStatus;
        }

        public string record_parentsEmail(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.parentsEmail_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public string record_username(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.username_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }
        public Boolean record_validateUid(BO_User userDetails)
        {
            // Validate uid and return back the result
            DAL_User dal = new DAL_User();
            int uid;
            Boolean isValid = false;
            try
            {
                uid = dal.uid_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
            if (userDetails.Uid == uid)
                isValid = true;
            return isValid;
        }

        public int record_exercisePoints_update(BO_User activateDetails)
        {
            DAL_User dal = new DAL_User();
            int tempExercisePoints;
            int status; // 1 success 0 database error
            try
            {
                // Get temp exercise points
                tempExercisePoints = dal.getTempExercisePoints(activateDetails);

                // set temp exercise points to 0;
                activateDetails.TempExercisePoints = 0;
                status = dal.updateTempExercisePoints(activateDetails);

                // get current exercise points balance and add temp exercise points
                int exercisePointsBalance = dal.exercisePoints_details(activateDetails);
                activateDetails.ExercisePoints = exercisePointsBalance + tempExercisePoints;

                // update new exercise points balance
                status = dal.updateExercisePoints(activateDetails);
                return status;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }

        public string record_screenName(BO_User userDetails)
        {
            DAL_User dal = new DAL_User();
            try
            {
                return dal.screenName_details(userDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
        }
    }
}
