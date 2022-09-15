namespace Theatre
{
    public static class ValidationConstants
    {
        public const int TheatreNameMinLength = 4;
        public const int TheatreNameMaxLength = 30;
        public const int TheatreDirectorMinLength = 4;
        public const int TheatreDirectorMaxLength = 30;
        public const sbyte TheatreNumberOfHallsMinValue = 1;
        public const sbyte TheatreNumberOfHallsMaxValue = 10;

        public const int PlayTitleMinLength = 4;
        public const int PlayTitleMaxLength = 50;
        public const int PlayDescriptionMaxLength = 700;
        public const int PlayScreenwriterMinLength = 4;
        public const int PlayScreenwriterMaxLength = 30;
        public const string PlayRatingMinValue = "0.00";
        public const string PlayRatingMaxValue = "10.00";

        public const int CastFullNameMinLength = 4;
        public const int CastFullNameMaxLength = 30;
        public const int CastPhoneNumberMaxLength = 15;
        public const string CastPhoneNumberReqEx = @"^(\+4{2}-[\d]{2}-[\d]{3}-[\d]{4})$";

        public const string TicketPriceMinValue = "1.00";
        public const string TicketPriceMaxValue = "100.00";
        public const sbyte TicketRowNumberMinValue = 1;
        public const sbyte TicketRowNumberMaxValue = 10;
    }
}
