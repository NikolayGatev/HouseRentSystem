﻿namespace HouseRentSystem.Common
{
    public static class MassageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PhoneExists = "Phone number already exists. Enter another one";

        public const string HasRents = "You should have no rents to become an agent";

        public const string PriceValue = "Price per month must be a positive number and less than {2} leva";
    }
}
