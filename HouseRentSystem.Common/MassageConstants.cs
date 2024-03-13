using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HouseRentSystem.Common
{
    public static class MassageConstants
    {
        public const string RequiredMessage = "The {0} field is required";

        public const string LengthMessage = "The field {0} must be between {2} and {1} characters long";

        public const string PhoneExists = "Phone number already exists. Enter another one";

        public const string HasRents = "You should have no rents to become an agent";
    }
}
