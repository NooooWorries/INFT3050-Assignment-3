using System;
using BusinessObjectLayer;
using DataAccessLayer;
using System.Data;

namespace BusinessLogicLayer
{
    public class BL_Battle
    {
        public string[] fightResult(BO_Battle battleDetails)
        {
            string[] result = new string[2]; // result[0] win, lose, draw, database error result[1] exp obtained
            int exp = 0;
            int enemyExp = 0;
            // Get experience points
            BO_Titan boExp = new BO_Titan();
            BO_Titan boExpEnemy = new BO_Titan();
            boExp.TitanName = battleDetails.TitanName;
            boExp.Username = battleDetails.Username;
            boExpEnemy.TitanName = battleDetails.EnemyTitanName;
            boExpEnemy.Username = battleDetails.EnemyUsername;
            DAL_Titan dalExp = new DAL_Titan();
            try
            {
                exp = dalExp.experiencePoints(boExp);
                enemyExp = dalExp.experiencePoints(boExpEnemy);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dalExp = null;
            }

            // Calculate points
            int points = exp;
            int enemyPoints = enemyExp;
            // 1: element
            string element = battleDetails.Element;
            string enemyElement = battleDetails.EnemyElement;
            if ((element == "Water" && enemyElement == "Fire") ||
                 (element == "Fire" && enemyElement == "Air") ||
                 (element == "Air" && enemyElement == "Earth") ||
                 (element == "Earth" && enemyElement == "Water"))
                points = points + Convert.ToInt32(Math.Round(exp * 0.25, 0));
            else if ((element == "Fire" && enemyElement == "Water") ||
                 (element == "Air" && enemyElement == "Fire") ||
                 (element == "Earth" && enemyElement == "Air") ||
                 (element == "Water" && enemyElement == "Earth"))
                enemyPoints = enemyPoints + Convert.ToInt32(Math.Round(enemyExp * 0.25, 0));

            // 2: challenger get 25% more points
            points = points + Convert.ToInt32(Math.Round(exp * 0.25, 0));

            // 3: binary random either grant a 25% experience points bonus to The Challenger or the Defender.
            // 0 - challenger, 1 - defender
            Random r = new Random();
            int random = r.Next(0, 2);
            if (random == 0)
                points = points + Convert.ToInt32(Math.Round(exp * 0.25, 0));
            else if (random == 1)
                enemyPoints = enemyPoints + Convert.ToInt32(Math.Round(enemyExp * 0.25, 0));

            // Generate result
            string resultChallenger = "";
            string resultDefender = "";
            int expObtainedChallenger = 0;
            int expObtainedDefender = 0;
            if (points > enemyPoints)
            {
                resultChallenger = "win";
                resultDefender = "lose";
                expObtainedChallenger = Convert.ToInt32(Math.Round(exp * 0.25, 0));
            }
            else if (points < enemyPoints)
            {
                resultChallenger = "lose";
                resultDefender = "win";
                expObtainedDefender = Convert.ToInt32(Math.Round(enemyExp * 0.25, 0));
            }
            else if (points == enemyPoints)
            {
                resultChallenger = "draw";
                resultDefender = "draw";
            }
            // Add record to database
            // Challenger
            BO_Battle boChallenger = new BO_Battle();
            boChallenger.Username = battleDetails.Username;
            boChallenger.EnemyUsername = battleDetails.EnemyUsername;
            boChallenger.TitanName = battleDetails.TitanName;
            boChallenger.EnemyTitanName = battleDetails.EnemyTitanName;
            boChallenger.Date = DateTime.Now.ToString();
            boChallenger.Result = resultChallenger;
            boChallenger.ExpObtained = expObtainedChallenger;
            boChallenger.Element = element;
            boChallenger.EnemyElement = enemyElement;
            boChallenger.IsChallenger = "true";

            // Defender (Enemy)
            BO_Battle boDefender = new BO_Battle();
            boDefender.Username = battleDetails.EnemyUsername;
            boDefender.EnemyUsername = battleDetails.Username;
            boDefender.TitanName = battleDetails.EnemyTitanName;
            boDefender.EnemyTitanName = battleDetails.TitanName;
            boDefender.Date = boChallenger.Date;
            boDefender.Result = resultDefender;
            boDefender.ExpObtained = expObtainedDefender;
            boDefender.Element = enemyElement;
            boDefender.EnemyElement = element;
            boDefender.IsChallenger = "false";

            // Add battle record to database
            DAL_Battle dal = new DAL_Battle();
            try
            {
                dal.Battle(boChallenger);
                dal.Battle(boDefender);
            }
            catch (Exception ex)
            {
                throw ex;
            }

            // Update titan's experience points, win and loses.
            BO_Titan boTitanChallenger = new BO_Titan();
            BO_Titan boTitanDefender = new BO_Titan();
            boTitanChallenger.Username = battleDetails.Username;
            boTitanChallenger.TitanName = battleDetails.TitanName;
            boTitanDefender.Username = battleDetails.EnemyUsername;
            boTitanDefender.TitanName = battleDetails.EnemyTitanName;
            DAL_Titan dalTitan = new DAL_Titan();
            try
            {
                // Update experience points
                boTitanChallenger.ExperiencePoints = dalTitan.experiencePoints(boTitanChallenger) + expObtainedChallenger;
                boTitanDefender.ExperiencePoints = dalTitan.experiencePoints(boTitanDefender) + expObtainedDefender;
                dalTitan.updateExperiencePoints(boTitanChallenger);
                dalTitan = null;
                dalTitan = new DAL_Titan();
                dalTitan.updateExperiencePoints(boTitanDefender);
                dalTitan = null;
                dalTitan = new DAL_Titan();

                // Update battle count
                boTitanChallenger.Battles = Convert.ToInt32(dalTitan.battles(boTitanChallenger)) + 1;
                dalTitan.updateBattle(boTitanChallenger);
                boTitanDefender.Battles = Convert.ToInt32(dalTitan.battles(boTitanDefender)) + 1;
                dalTitan.updateBattle(boTitanDefender);

                // Update wins and loses
                // Challenger
                if (resultChallenger == "win")
                {
                    boTitanChallenger.Wins = Convert.ToInt32(dalTitan.fightInfo_Username(boTitanChallenger).Tables[0].Rows[0]["wins"]) + 1;
                    dalTitan.updateWins(boTitanChallenger);
                    dalTitan = null;
                    dalTitan = new DAL_Titan();
                }
                else if (resultChallenger == "lose")
                {
                    boTitanChallenger.Loses = Convert.ToInt32(dalTitan.fightInfo_Username(boTitanChallenger).Tables[0].Rows[0]["loses"]) + 1;
                    dalTitan.updateLoses(boTitanChallenger);
                    dalTitan = null;
                    dalTitan = new DAL_Titan();
                }
                // Defender
                if (resultDefender == "win")
                {
                    boTitanDefender.Wins = Convert.ToInt32(dalTitan.fightInfo_Username(boTitanDefender).Tables[0].Rows[0]["wins"]) + 1;
                    dalTitan.updateWins(boTitanDefender);
                    dalTitan = null;
                    dalTitan = new DAL_Titan();
                }
                else if (resultDefender == "lose")
                {
                    boTitanDefender.Loses = Convert.ToInt32(dalTitan.fightInfo_Username(boTitanDefender).Tables[0].Rows[0]["loses"]) + 1;
                    dalTitan.updateLoses(boTitanDefender);
                    dalTitan = null;
                    dalTitan = new DAL_Titan();
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
            // Update titan's level and step
            BL_Titan bl = new BL_Titan();
            bl.updateLevelStep(boTitanChallenger);
            bl.updateLevelStep(boTitanDefender);

            // Add data to string array result
            result[0] = resultChallenger;
            result[1] = expObtainedChallenger.ToString();
            return result;
        }

        public DataSet recordHistory(BO_User userDetails)
        {
            DAL_Battle dal = new DAL_Battle();
            DataSet dataSet;
            try
            {
                dataSet = dal.history(userDetails);
                dataSet.Tables[0].Columns[0].ColumnName = "Titan name";
                dataSet.Tables[0].Columns[1].ColumnName = "Enemy titan name";
                dataSet.Tables[0].Columns[2].ColumnName = "Result";
                dataSet.Tables[0].Columns[3].ColumnName = "Date";
                
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                dal = null;
            }
            return dataSet;
        }
    }
}