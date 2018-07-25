using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace SMSApp.Validation
{

    public class ModelWrapper<T> : NotifyDataErrorBase
    {
        public ModelWrapper(T model)
        {
            Model = model;
        }

        public T Model { get; }

        protected virtual TValue GetValue<TValue>([CallerMemberName]string propertyName=null)
        {
            return (TValue)typeof(T).GetProperty(propertyName).GetValue(Model);
        }

        protected virtual void SetValue<TValue>(TValue value, [CallerMemberName]string propertyName = null)
        {
            typeof(T).GetProperty(propertyName).SetValue(Model, value);
            RaisePropertyChanged(propertyName);
            ValidatePropertyInternal(propertyName, value);
        }

        private void ValidatePropertyInternal(string propertyName, object value)
        {
            ClearErrors(propertyName);

            ValidateDataAnnotations(propertyName, value);
            ValidateCustomErrors(propertyName);
        }

        private void ValidateDataAnnotations(string propertyName, object value)
        {
            // 1. Validate data annotations
            var context = new ValidationContext(Model) { MemberName = propertyName };
            var results = new List<ValidationResult>();

            Validator.TryValidateProperty(value, context, results);

            foreach (var result in results)
            {
                AddError(propertyName, result.ErrorMessage);
            }
        }

        private void ValidateCustomErrors(string propertyName)
        {
            // 2. Validate custom errors
            var errors = ValidateProperty(propertyName);
            if (errors != null)
            {
                foreach (var error in errors)
                {
                    AddError(propertyName, error);
                }
            }
        }

        protected virtual IEnumerable<string> ValidateProperty(string propertyName)
        {
            return null;
        }
    }


}
