namespace BookShop
{
    public static class ValidationConstants
    {
        public const int AuthorFirstNameMinLength = 3;
        public const int AuthorFirstNameMaxLength = 30;
        public const int AuthorLastNameMinLength = 3;
        public const int AuthorLastNameMaxLength = 30;
        public const int AuthorPhoneMaxLength = 12;
        public const string AuthorPhoneRegEx = @"^(([\d]{3})-){2}([\d]{4})$";

        public const int BookNameMinLength = 3;
        public const int BookNameMaxLength = 30;
        public const string BookPriceMinValue = "0.01";
        public const string BookPriceMaxValue = "79228162514264337593543950335";
        public const int BookPagesMinValue = 50;
        public const int BookPagesMaxValue = 5000;
        public const int BookGenreMinValue = 1;
        public const int BookGenreMaxValue = 3;
    }
}
