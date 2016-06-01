using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessObjectLayer
{
    public class BO_User
    {
        // Claim variables
        private string username;
        private string password;
        private string parentsEmail;
        private int exercisePoints;
        private int tempExercisePoints;
        private string activateStatus;
        private int activateCode;
        private string profilePictureLocation;
        private string screenName;
        private string anonymous;
        private string firstName;
        private int oneDayExercisePoints;
        private string oneDayStartTime;
        private int uid;
        // Get and set variables
        public string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        public string ParentsEmail
        {
            get
            {
                return parentsEmail;
            }
            set
            {
                parentsEmail = value;
            }
        }
        public int ExercisePoints
        {
            get
            {
                return exercisePoints;
            }
            set
            {
                exercisePoints = value;
            }
        }

        public int TempExercisePoints
        {
            get
            {
                return tempExercisePoints;
            }
            set
            {
                tempExercisePoints = value;
            }
        }

        public String ActivateStatus
        {
            get
            {
                return activateStatus;
            }
            set
            {
                activateStatus = value;
            }
        }

        public int ActivateCode
        {
            get
            {
                return activateCode;
            }
            set
            {
                activateCode = value;
            }
        }

        public string ProfilePictureLocation
        {
            get
            {
                return profilePictureLocation;
            }
            set
            {
                profilePictureLocation = value;
            }
        }

        public string ScreenName
        {
            get
            {
                return screenName;
            }
            set
            {
                screenName = value;
            }
        }

        public string Anonymous
        {
            get
            {
                return anonymous;
            }
            set
            {
                anonymous = value;
            }
        }

        public string FirstName
        {
            get
            {
                return firstName;
            }
            set
            {
                firstName = value;
            }
        }

        public int OneDayExercisePoints
        {
            get
            {
                return oneDayExercisePoints;
            }
            set
            {
                oneDayExercisePoints = value;
            }
        }

        public string OneDayStartTime
        {
            get
            {
                return oneDayStartTime;
            }
            set
            {
                oneDayStartTime = value;
            }
        }

        public int Uid
        {
            get
            {
                return uid;
            }
            set
            {
               uid = value;
            }
        }
    }
}
