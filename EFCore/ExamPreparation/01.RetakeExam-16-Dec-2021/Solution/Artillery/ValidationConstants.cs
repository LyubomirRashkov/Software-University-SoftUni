namespace Artillery
{
    public static class ValidationConstants
    {
        public const int ShellCaliberMinLengthValue = 4;
        public const int ShellCaliberMaxLengthValue = 30;
        public const double ShellShellWeightMinValue = 2;
        public const double ShellShellWeightMaxValue = 1_680;

        public const int ManufacturerManufacturerNameMinLengthValue = 4;
        public const int ManufacturerManufacturerNameMaxLengthValue = 40;
        public const int ManufacturerFoundedMinLengthValue = 10;
        public const int ManufacturerFoundedMaxLengthValue = 100;

        public const int CountryCountryNameMaxLengthValue = 60;
        public const int CountryCountryNameMinLengthValue = 4;
        public const int CountryArmySizeMinValue = 50_000;
        public const int CountryArmySizeMaxValue = 10_000_000;

        public const int GunGunWeightMinValue = 100;
        public const int GunGunWeightMaxValue = 1_350_000;
        public const double GunBarrelLengthMinValue = 2.00;
        public const double GunBarrelLengthMaxValue = 35.00;
        public const int GunRangeMinValue = 1;
        public const int GunRangeMaxValue = 100_000;
    }
}
