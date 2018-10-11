using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.PageModels.Base;

namespace Mdia.Mobile.Validations
{
    public class ValidatableObject<T> : BasePropertyChangeNotifier //, IValidate
    {
        private T _value;
        private bool _isValid;
        private List<string> _errors;
        private readonly List<IValidationRule<T>> _validations;

        public ValidatableObject()
        {
            IsValid = true;
            Errors = new List<string>();
            _validations = new List<IValidationRule<T>>();

            //_isValid = true;
            //_errors = new List<string>();
            //_validations = new List<IValidationRule<T>>();
        }

        public List<IValidationRule<T>> Validations => _validations;

        public List<string> Errors
        {
            set { SetProperty(ref _errors, value); }
            get { return _errors; }
        }
        public T Value
        {
            set { SetProperty(ref _value, value); }
            get { return _value; }
        }
        public bool IsValid
        {
            set { SetProperty(ref _isValid, value); }
            get { return _isValid; }
        }
        
        public bool Validate()
        {
            Errors.Clear();

            IEnumerable<string> errors = _validations.Where(v => !v.Check(Value)).Select(v => v.Message);

            Errors = errors.ToList();
            IsValid = !Errors.Any();

            return this.IsValid;
        }




    }
}
