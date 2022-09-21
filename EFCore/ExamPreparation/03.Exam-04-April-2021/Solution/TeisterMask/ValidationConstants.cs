namespace TeisterMask
{
    public static class ValidationConstants
    {
        public const int EmployeeUsernameMaxLength = 40;
        public const string EmployeeUsernameRegEx = @"^([A-Za-z\d]){3,40}$";
        public const int EmployeePhoneLength = 12;
        public const string EmployeePhoneRegEx = @"^(([\d]{3})-){2}([\d]{4})$";

        public const int ProjectNameMinLength = 2;
        public const int ProjectNameMaxLength = 40;

        public const int TaskNameMinLength = 2;
        public const int TaskNameMaxLength = 40;
    }
}
