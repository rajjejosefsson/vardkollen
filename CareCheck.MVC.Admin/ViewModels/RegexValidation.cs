namespace CareCheck.MVC.Admin.ViewModels
{
    public static class RegexValidation
    {
        public const string SwedishPostalCode = @"(s -| S -){0,1}";
        public const string SwedishMobilePhone = @"(\+\d{1,2}\s)?\(?\d{3}\)?[\s.-]?\d{3}[\s.-]?\d{4}";
        public const string SwedishPersonNumber = @"(19|20)?[0-9]{2}[- ]?((0[0-9])|(10|11|12))[- ]?(([0-2][0-9])|(3[0-1])|(([7-8][0-9])|(6[1-9])|(9[0-1])))[- ]?[0-9]{4}";


    }
}