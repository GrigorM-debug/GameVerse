namespace GameVerse.Common
{
    public static class ApplicationConstants
    {
        //Project start date
        public const int ProjectStartDate = 2024;

        //DateTime format
        public const string DateTimeFormat = "dd-MM-yyyy";

        //Error Messages
        public const string LengthErrorMessage = "{0} must be between {1} and {2} characters long!";
        public const string invalidDateTimeErrorMessage = $"Date must be in the following format - ${DateTimeFormat}";
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";

        public static class PlatformConstants
        {
            //Name
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
        }

        public static class GameConstants
        {
            //Title
            public const int TitleMinLength = 3;
            public const int TitleMaxLength = 70;

            //Description
            public const int DescriptionMinLength = 10;
            public const int DescriptionMaxLength = 1000;

            //Year Published
            public const int YearPublishedMinValue = 1950;
            public const int YearPublishedMaxValue = 2100;

            //Price
            public const double PriceMinValue = 1.00;
            public const double PriceMaxValue = 1000.00;

            //Publishing Studio
            public const int PublishingStudioMinLength = 2;
            public const int PublishingStudioMaxLength = 30;

        }

        public static class GenreConstants
        {
            //Name
            public const int NameMinLength = 3;
            public const int NameMaxlength = 50;
        }
    }
}
