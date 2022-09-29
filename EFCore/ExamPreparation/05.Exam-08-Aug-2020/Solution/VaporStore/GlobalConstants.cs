using System;
using System.Collections.Generic;
using System.Text;

namespace VaporStore
{
    public static class GlobalConstants
    {
        public const string GamePriceMinValue = "0.0";
        public const string GamePriceMaxValue = "79228162514264337593543950335";

        public const string UserFullNameRegEx = @"^([A-Z][a-z]+)\s([A-Z][a-z]+)$";
        public const int UserUsernameMinLength = 3;
        public const int UserUsernameMaxLength = 20;
        public const int UserAgeMinValue = 3;
        public const int UserAgeMaxValue = 103;

        public const string CardNumberRegEx = @"^([\d]{4}\s){3}[\d]{4}$";
        public const string CardCVCRegEx = @"^[\d]{3}$";

        public const string PurchaseProductKeyRegEx = @"^(([A-Z\d]{4}-){2})[A-Z\d]{4}$";
    }
}
