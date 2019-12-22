using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace UITest.Helpers
{
    public class IndexPageHelper
    {
        public string[] DataLang = new string[]
        {
            "en-gb", "en-us", "de", "nl", "fr", "es", "es-ar", "ca", "it", "pt-pt", "pt-br", "no", "fi", "sv", "da",
            "cs", "hu", "ro", "ja", "zh-cn", "zh-tw", "pl", "el", "ru", "tr", "bg", "ar", "ko", "he", "lv",
            "uk", "id", "ms", "th", "et", "hr", "lt", "sk", "sr", "sl", "vi", "tl", "is"
        };

        public string[] DataCurr = new string[]
        {
            "ARS", "AUD", "AZN", "BHD", "BYN", "BRL", "BGN", "CAD", "XOF", "CLP", "CNY", "COP", "CZK",
            "DKK", "EGP", "EUR", "FJD", "GEL", "HKD", "HUF", "INR", "IDR", "ILS", "JPY", "JOD", "KZT",
            "KRW", "KWD", "MYR", "MXN", "MDL", "NAD", "TWD", "NZD", "NOK", "OMR", "PLN", "GBP", "QAR",
            "RON", "RUB", "SAR", "SGD", "ZAR", "SEK", "CHF", "THB", "TRY", "AED", "USD", "UAH"
        };

        public IWebDriver Setup()
        {
            return new ChromeDriver("D:\\Development\\.NET Core\\Tests\\UITest")
            {
                Url = "http://Booking.com/"
            };
        }
    }
}