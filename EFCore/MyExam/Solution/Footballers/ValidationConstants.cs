﻿namespace Footballers
{
    public static class ValidationConstants
    {
        public const int FootballerNameMinLength = 2;
        public const int FootballerNameMaxLength = 40;

        public const int TeamNameMinLength = 3;
        public const int TeamNameMaxLength = 40;
        public const string TeamNameRegEx = @"^([A-Za-z\d\s\.-]{3,40})$";
        public const int TeamNationalityMinLength = 2;
        public const int TeamNationalityMaxLength = 40;

        public const int CoachNameMinLength = 2;
        public const int CoachNameMaxLength = 40;
    }
}
