using Microsoft.Win32;

namespace SMSApp.Helpers
{
    public class USSDHelper
    {
        public static string GetPropertyFromRegistry(string nameOfTheProperty)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "SMSapp";
            const string keyName = userRoot + "\\" + subkey;

            return Registry.GetValue(keyName, nameOfTheProperty, "") as string;
        }
        public static void SetPropertyInRegistry(string nameOfTheProperty, string value)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "SMSapp";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, nameOfTheProperty, value);
        }
    }
}
