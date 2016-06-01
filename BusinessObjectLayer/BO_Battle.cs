namespace BusinessObjectLayer
{
    public class BO_Battle
    {
        private string username;
        private string enemyUsername;
        private string titanName;
        private string enemyTitanName;
        private string element;
        private string enemyElement;
        private string date;
        private string result;
        private int expObtained;
        private string isChallenger;

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

        public string TitanName
        {
            get
            {
                return titanName;
            }
            set
            {
                titanName = value;
            }
        }

        public string EnemyUsername
        {
            get
            {
                return enemyUsername;
            }
            set
            {
                enemyUsername = value;
            }
        }

        public string EnemyTitanName
        {
            get
            {
                return enemyTitanName;
            }
            set
            {
                enemyTitanName = value;
            }
        }

        public string Element
        {
            get
            {
                return element;
            }
            set
            {
                element = value;
            }
        }

        public string EnemyElement
        {
            get
            {
                return enemyElement;
            }
            set
            {
                enemyElement = value;
            }
        }

        public string Date
        {
            get
            {
                return date;
            }
            set
            {
                date = value;
            }
        }

        public string Result
        {
            get
            {
                return result;
            }
            set
            {
                result = value;
            }
        }

        public int ExpObtained
        {
            get
            {
                return expObtained;
            }
            set
            {
                expObtained = value;
            }
        }

        public string IsChallenger
        {
            get
            {
                return isChallenger;
            }
            set
            {
                isChallenger = value;
            }
        }
    }
}
