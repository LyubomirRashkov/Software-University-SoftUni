namespace SoftJail
{
    public static class ValidationConstants
    {
        public const int PrisonerFullNameMinLength = 3;
        public const int PrisonerFullNameMaxLength = 20;
        public const string PrisonerNickNameRegEx = @"^(The )([A-Z][a-z]+)$";
        public const int PrisonerAgeMinValue = 18;
        public const int PrisonerAgeMaxValue = 65;
        public const string PrisonerBailMinValue = "0";
        public const string PrisonerBailMaxValue = "79228162514264337593543950335";

        public const int OfficerFullNameMinLength = 3;
        public const int OfficerFullNameMaxLength = 30;
        public const string OfficerSalaryMinValue = "0";
        public const string OfficerSalaryMaxValue = "79228162514264337593543950335";

        public const int DepartmentNameMinLength = 3;
        public const int DepartmentNameMaxLength = 25;

        public const int CellCellNumberMinValue = 1;
        public const int CellCellNumberMaxValue = 1000;

        public const string MailAddressRegEx = @"^([A-Za-z\s\d])+?( str\.)$";
    }
}
