using System.Globalization;
using System.Windows.Controls;

namespace SMSApp.Controls.FilePicker
{
    public class FileExtensionRule : ValidationRule
    {
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            if (value == null)
            {
                return new ValidationResult(false, null);
            }

            var fileName = value.ToString();
            if (fileName.Contains(".rar") || fileName.Contains(".exe"))
            {
                return new ValidationResult(false, "You can not upload '.rar' or '.exe' files.");
            }

            return ValidationResult.ValidResult;
        }
    }
}
