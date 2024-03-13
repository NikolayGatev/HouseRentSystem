namespace HouseRentSystem.Common
{
    public static class DataLocalConstants
    {
        public static class Category
        {
            public const int MaxLegnthName = 50;
            public const int MinLegnthName = 5;
        }

        public static class House
        {
            public const int TitleMaxLegnth = 50;
            public const int TitleMinLegnth = 10;

            public const int AddressMaxLegnth = 150;
            public const int AddressMinLegnth = 30;

            public const int DescriptionMaxLegnth = 500;
            public const int DeskriptionMinLegnth = 50;

            public const string PricePerMonthMaxLegnth = "2000.00";
            public const string PricePerMonthMinLegnth = "0.00";
        }

        public static class Agent
        {
            public const int PhoneNumberMaxLegnth = 15;
            public const int PhoneNumberMinLegnth = 7;
        }
    }
}
