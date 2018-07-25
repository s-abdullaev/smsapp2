using Prism.Mvvm;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace SMSApp.Validation
{
    public class ValidationModelBase : BindableBase, IDataErrorInfo
    {

        private List<ValidationResult> errors= new List<ValidationResult>();

        public string Error
        {
            get { return null; }
        }

        public bool HasErrors
        {
            get { return errors.Any(); }
        }

        public string this[string propertyName]
        {
            get
            {
                var value = GetType().GetProperty(propertyName).GetValue(this);
                var context = new ValidationContext(this) { MemberName = propertyName };
                errors = new List<ValidationResult>();

                Validator.TryValidateProperty(value, context, errors);

                RaisePropertyChanged("HasErrors");

                return errors.Any()?errors.First().ErrorMessage:null;
            }
        }
    }

}
