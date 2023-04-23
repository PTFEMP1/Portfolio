namespace Web_API
{
    public static class Constants
    {
        public static class Database
        {
            public const string DatabaseName = "Documents";
            public const string ConnectionString = "Database";
            public const string UserCollection = "User";
            public const string defaultPassword = "Passw0rd";
        }
        
        public static class Validations
        {
            public static readonly string[] badWords = { "Insult1", "Insult2" };
        }
    }
}
