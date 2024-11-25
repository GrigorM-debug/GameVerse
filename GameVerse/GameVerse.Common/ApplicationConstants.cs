namespace GameVerse.Common
{
    public static class ApplicationConstants
    {
        //Project start date
        public const int ProjectStartDate = 2024;

        //DateTime format
        public const string DateTimeFormat = "dd-MM-yyyy";

        //Error Messages
        public const string LengthErrorMessage = "{0} must be between {2} and {1} characters long!";
        public const string InvalidDateTimeErrorMessage = $"Date must be in the following format - ${DateTimeFormat}";
        public const string RangeErrorMessage = "{0} must be a number between {1} and {2}!";

        public static class ApplicationUserConstants
        {
            //First Name
            public const int ApplicationUserFirtNameMinLength = 2;
            public const int ApplicationUserFirstNameMaxLength = 35;

            //Last Name
            public const int ApplicationUserLastNameMinLength = 2;
            public const int ApplicationUserLastNameMaxLength = 35;

            //Username
            public const int ApplicationUserUserNameMinLength = 3;
            public const int ApplicationUserUserNameMaxLength = 30;
        }

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

            //Quantity in Stock
            public const int QuantityInStockMinValue = 1;

            public const int QuantityInStockMaxValue = 100;

            //Game Type
            public const string InvalidGameTypeErrorMessage = "Invalid game type.";
            public const string NoGameTypeSelectedErrorMessage = "Please select Game Type";
        }

        public static class GenreConstants
        {
            //Name
            public const int NameMinLength = 3;
            public const int NameMaxlength = 50;
        }

        public static class ReviewConstants
        {
            //Rating
            public const int RatingMinValue = 1;
            public const int RatingMaxValue = 5;

            //Rating Content
            public const int ContentMinLength = 5;
            public const int ContentMaxLength = 200;
        }

        public static class EventConstants
        {
            //DateTime Format 
            public const string EventDateTimeFormat = "dd-MM-yyyy HH:mm";
            public const string EventDateTimeErrorMessage = $"Date must be in the following format - ${EventDateTimeFormat}";

            //Topic
            public const int TopicMinLength = 5;
            public const int TopicMaxLength = 70;

            //Description
            public const int DescriptionMinLength = 20;
            public const int DescriptionMaxLength = 500;

            //Ticket Price
            public const double TicketPriceMinValue = 1.00;
            public const double TicketPriceMaxValue = 1000.00;

            //Seats
            public const int SeatsMinValue = 1;
            public const int SeatsMaxValue = 1000;
        }

        public static class RestrictionsConstants
        {
            //Restriction Name 
            public const int RestrictionNameMinLength = 3;
            public const int RestrictionNameMaxLength = 50; 
        }
    }
}
