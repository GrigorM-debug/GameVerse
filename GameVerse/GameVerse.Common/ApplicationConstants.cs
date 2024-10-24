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

        public static class PlatformConstants
        {
            //Name
            public const int NameMinLength = 2;
            public const int NameMaxLength = 30;
        }
    }
}
