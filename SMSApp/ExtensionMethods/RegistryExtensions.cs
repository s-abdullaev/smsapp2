using Microsoft.Win32;

namespace SMSApp.ExtensionMethods
{
    public static class RegistryExtensions
    {
        public static string GetPropertyFromRegistry(this string nameOfTheProperty)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "SMSapp";
            const string keyName = userRoot + "\\" + subkey;

            return Registry.GetValue(keyName, nameOfTheProperty, "") as string;
        }
        public static void SetPropertyInRegistry(this string nameOfTheProperty, string value)
        {
            const string userRoot = "HKEY_CURRENT_USER";
            const string subkey = "SMSapp";
            const string keyName = userRoot + "\\" + subkey;

            Registry.SetValue(keyName, nameOfTheProperty, value);
        }

    }
}
