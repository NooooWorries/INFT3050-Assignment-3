using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjectLayer;
using DataAccessLayer;
namespace BusinessLogicLayer
{
    public class BL_Titan
    {
        static int status;
        public DataSet recordTitanList(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                return dal.titanName(titanDetails);
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

        public DataSet recordHOF(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                DataSet dataSet = dal.HOF(titanDetails);
                // Add a new column called rank
                dataSet.Tables[0].Columns.Add("Rank", typeof(int)).SetOrdinal(0);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i ++)
                {
                    // Add rank to dataset
                    dataSet.Tables[0].Rows[i][0] = i + 1; 
                    // If user ask for anonymous, set the value of name to ****
                    if (dataSet.Tables[0].Rows[i]["anonymous"].ToString() == "true")
                    {
                        dataSet.Tables[0].Rows[i]["firstName"] = "****";
                    }                  
                }
                // Remove column nonymous
                dataSet.Tables[0].Columns.Remove("anonymous");
                // Rename columns
                dataSet.Tables[0].Columns[1].ColumnName = "First name";
                dataSet.Tables[0].Columns[2].ColumnName = "Screen name";
                dataSet.Tables[0].Columns[3].ColumnName = "Titan name";
                dataSet.Tables[0].Columns[4].ColumnName = "Battles";
                dataSet.Tables[0].Columns[5].ColumnName = "Wins";
                dataSet.Tables[0].Columns[6].ColumnName = "Loses";
                dataSet.Tables[0].Columns[7].ColumnName = "Date ctreated";
                return dataSet;
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
        

        public DataSet recordTitanInfo (BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                return dal.titanInfo(titanDetails);
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
        public Boolean recordTitanCount (BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                // Get the count of character
                // If count >=4, reject user's request to create a new character
                Boolean isFull = true;
                int count = dal.titanCount(titanDetails);
                if (count < 4)
                    isFull = false;
                return isFull;
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

        public Boolean recordDuplicateTitanName (BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                // Get the count of character name
                // If count >=1, reject user's request to create a new character
                Boolean isUnique = false;
                int count = dal.titanDuplicateName(titanDetails);
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

        public Boolean recordDuplicateElement(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                // Get the count of character name
                // If count >=1, reject user's request to create a new character
                Boolean isUnique = false;
                int count = dal.titanDuplicateElement(titanDetails);
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
        public string record_insert(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan ();
            try
            {
                return dal.createTitan(titanDetails);
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
        public int record_changeName_update(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                return dal.changeTitanName(titanDetails);
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

        public int record_experiencePoints(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                return dal.experiencePoints(titanDetails);
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
        public int record_delete (BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                return dal.deleteTitan(titanDetails);
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

        public int record_exercisePoints_update (BO_Titan titanDetails)
        {
            DAL_Titan dalTitan = new DAL_Titan();
            DAL_User dalUser = new DAL_User();
            status = 0; // 0: database error, 1: success, 2: exercise points not enough, 3 HOF Titan
            int userExercisePoints;
            int titanExercisePoints;
            int exercisePointsAdd = titanDetails.ExperiencePoints; // exercise points that user want to arrange
            string HOF;// User cannot give a HOF titan any exercise points
            BO_User boUser = new BO_User();
            boUser.Username = titanDetails.Username;
            try
            {
                // Get user exercise points
                userExercisePoints = dalUser.exercisePoints_details(boUser);
                titanExercisePoints = dalTitan.titanExercisePoints(titanDetails);
                HOF = dalTitan.HOFStatus(titanDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            if (exercisePointsAdd > userExercisePoints)
                status = 2;
            else if (HOF == "true")
                status = 3;
            else
            {
                boUser.ExercisePoints = userExercisePoints - exercisePointsAdd;
                titanDetails.ExperiencePoints = titanExercisePoints + exercisePointsAdd;
                try
                {
                    // Update user's exercise points 
                    dalUser.updateExercisePoints(boUser);
                    // Add exercise points to titan
                    dalTitan.updateTitanExercisePoints(titanDetails);         
                    // Update level and step 
                    updateLevelStep(titanDetails);
                    status = 1;

                }
                catch (Exception ex)
                {
                    throw ex;
                }
                finally
                {
                    dalTitan = null;
                    dalUser = null;
                }
            }
            return status;
        }

        public DataSet rivalList(BO_Titan titanDetails)
        {
            // Send back the rival list
            DataSet dataSet;
            DAL_Titan dal = new DAL_Titan();
            try
            {
                dataSet =  dal.rivalList(titanDetails);
                for (int i = 0; i < dataSet.Tables[0].Rows.Count; i++)
                {
                    // If user ask for anonymous, set the value of name to ****
                    if (dataSet.Tables[0].Rows[i]["anonymous"].ToString() == "true")
                    {
                        dataSet.Tables[0].Rows[i]["firstName"] = "****";
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
            dataSet.Tables[0].Columns.Remove("anonymous");
            // Rename column
            dataSet.Tables[0].Columns[0].ColumnName = "Titan name";
            dataSet.Tables[0].Columns[1].ColumnName = "Screen name";
            dataSet.Tables[0].Columns[2].ColumnName = "First name";
            dataSet.Tables[0].Columns[3].ColumnName = "Element";
            dataSet.Tables[0].Columns[4].ColumnName = "Level";
            dataSet.Tables[0].Columns[5].ColumnName = "Step";
            return dataSet;
        }

        public int IsAbleToFight (BO_Titan titanDetails, BO_Titan rivalDetails)
        {
            // Check whether two titans are able to fight
            // 0 - HOF titan, not able to fight
            // 1 - able to fight
            // 2 - Step gap more than 2, not able to fight.
            // Rival HOF Titans will not display in rival list
            int status = 0;
            DataSet levelStep;
            DataSet rivalLevelStep;
            string HOF;
            DAL_Titan dal = new DAL_Titan();
            try
            {
                levelStep = dal.levelStep(titanDetails);
                rivalLevelStep = dal.levelStep(rivalDetails);
                HOF = dal.HOFStatus(titanDetails);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }

            int titanLevel = (Convert.ToInt32(levelStep.Tables[0].Rows[0]["level"]) - 1) * 4 + 
                             (Convert.ToInt32(levelStep.Tables[0].Rows[0]["step"]));
            int rivalLevel = (Convert.ToInt32(rivalLevelStep.Tables[0].Rows[0]["level"]) - 1) * 4 +
                             (Convert.ToInt32(rivalLevelStep.Tables[0].Rows[0]["step"]));
            if (titanLevel - rivalLevel < -2 || titanLevel - rivalLevel > 2)
                status = 2;
            else if (HOF == "true")
                status = 0;
            else
                status = 1;
            return status;
        }

        public DataSet recordFightInfo(BO_Titan titanDetails)
        {
            DAL_Titan dal = new DAL_Titan();
            try
            {
                return dal.fightInfo(titanDetails);
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

        public int updateLevelStep (BO_Titan titanDetails)
        {
            // Input titanName, username, experience points
            // update level and step data in database
            int status = 0;
            DAL_Titan dal = new DAL_Titan();
            int exp = titanDetails.ExperiencePoints;
            // status : 0 database error, 1 success, 2 HOF
            int level = 1;
            int step = 1;

            // Get level and step based on exp
            if (exp >= 0 && exp <= 200)
            {
                level = 1;
                step = 1;
            }
            else if (exp >= 201 && exp <= 425)
            {
                level = 1;
                step = 2;
            }
            else if (exp>= 426 && exp <= 675)
            {
                level = 1;
                step = 3;
            }
            else if (exp >= 676 && exp <= 1000 )
            {
                level = 1;
                step = 4;
            }
            else if ( exp >= 1001 && exp <= 1400)
            {
                level = 2;
                step = 1;
            }
            else if (exp >=1401 && exp <= 1900)
            {
                level = 2;
                step = 2;
            }
            else if (exp>= 1901 && exp <= 2400)
            {
                level = 2;
                step = 3;
            }
            else if (exp >= 2401 && exp <= 3000)
            {
                level = 2;
                step = 4;
            }
            else if (exp>= 3001 && exp <= 3700)
            {
                level = 3;
                step = 1;
            }
            else if (exp >= 3701 && exp <=4500)
            {
                level = 3;
                step = 2;
            }
            else if (exp>= 4501 && exp <= 5400)
            {
                level = 3;
                step = 3;
            }
            else if (exp>= 5401 && exp <= 6400)
            {
                level = 3;
                step = 4;
            }
            else if (exp>= 6401 && exp<= 7500)
            {
                level = 4;
                step = 1;
            }
            else if (exp>= 7501 && exp <= 8700)
            {
                level = 4;
                step = 2;
            }
            else if (exp>= 8701 && exp <= 10000)
            {
                level = 4;
                step = 3;
            }
            else if (exp >= 10001 && exp <= 11500)
            {
                level = 4;
                step = 4;
            }
            else if (exp >= 11501)
            {
                level = 4;
                step = 4;
                status = 2;
            }
            // Update level and step
            DAL_Titan dalLevelStep = new DAL_Titan();
            BO_Titan boLevelStep = new BO_Titan();
            boLevelStep.Username = titanDetails.Username;
            boLevelStep.TitanName = titanDetails.TitanName;
            boLevelStep.Level = level;
            boLevelStep.Step = step;
            try
            {
                dal.updateLevel(boLevelStep);
                dal.updateStep(boLevelStep);
                if (status == 2)
                {
                    boLevelStep.HOF = "true";
                    status = dal.updateHOF(boLevelStep);
                }
            }
           catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }

            return status;
        }
    }
}
