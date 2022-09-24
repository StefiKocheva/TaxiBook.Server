namespace TaxiBook.Server.Data
{
    public class Vallidation
    {
        public class Company
        {
            public const int MaxNameLength = 100;

            public const int MaxDescriptionLength = 500;

            public const int MinDescriptionLength = 10;
        }

        public class User
        {
            public const int MaxFirstNameLength = 40;

            public const int MaxLastNameLength = 40;
        }
    }
}
