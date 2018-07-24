using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SMSApp.Validation
{
    public class ValidationModelBase : BindableBase, IDataErrorInfo
    {
        public string Error
        {
            get { return null; }
        }

        public string this[string propertyName]
        {
            get
            {
                var value = GetType().GetProperty(propertyName).GetValue(this);
                var context = new ValidationContext(this) { MemberName = propertyName };
                var results = new List<ValidationResult>();

                Validator.TryValidateProperty(value, context, results);

                return results.Any()?results.First().ErrorMessage:null;
            }
        }
    }

}
