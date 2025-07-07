using System.Globalization;

namespace BlzMauiApp.Helpers
{
    public class GlobalHelper
    {
        public static string DateConvertion(string parameterDate)
        {
            DateTime Arrivaldates2 = DateTime.ParseExact(parameterDate, new string[] { "dd.MM.yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "dd/MM/yyyy" }, CultureInfo.InvariantCulture);
            var PCDate = Arrivaldates2.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
            return PCDate;
        }

        public static DateTime DateConvertionCSharp(string parameterDate)
        {
            try
            {
                CultureInfo provider = CultureInfo.InvariantCulture;
                DateTime dateTime = DateTime.ParseExact(parameterDate, new string[] { "dd.MM.yyyy", "dd-MM-yyyy", "yyyy-MM-dd", "dd/MM/yyyy", "MM/dd/yyyy" }, provider, DateTimeStyles.None);
                return dateTime;

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return DateTime.MinValue;
        }
    }
}
