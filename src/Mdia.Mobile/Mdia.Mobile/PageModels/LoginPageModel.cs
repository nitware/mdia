using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Mobile.PageModels.Base;
using Mdia.Mobile.Validations;
using System.Windows.Input;
using Xamarin.Forms;

namespace Mdia.Mobile.PageModels
{
    public class LoginPageModel : BasePageModel
    {
        private ValidatableObject<string> _userName;
        private ValidatableObject<string> _password;

        public LoginPageModel()
        {
            UserName = new ValidatableObject<string>();
            Password = new ValidatableObject<string>();

            SetValidationRules();
        }

        public ICommand LoginCommand => new Command(OnLoginCommand);
        public ICommand UserNameValidationCommand => new Command(() => ValidateUserName());

        public ValidatableObject<string> UserName
        {
            get { return _userName; }
            set { SetProperty(ref _userName, value); }
        }
        public ValidatableObject<string> Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }


        private bool ValidateUserName()
        {
            return UserName.Validate();
        }
        private void OnLoginCommand()
        {
            try
            {
                IsBusy = true;

                

                if (EntryIsInvalid())
                {
                    return;
                }


                IsBusy = false;
            }
            catch(Exception ex)
            {
                IsBusy = false;
            }
        }

        private bool EntryIsInvalid()
        {
            try
            {
                bool usernameIsValid = ValidateUserName();
                bool passwordIsValid = Password.Validate();
                
                return (usernameIsValid && passwordIsValid);
            }
            catch(Exception)
            {
                throw;
            }
        }

        private void SetValidationRules()
        {
            //Username.Validations.Clear();
            //Password.Validations.Clear();

            UserName.Validations.Add(new IsNotNullOrEmptyRule<string> { Message = "Username is required!" });
            Password.Validations.Add(new IsNotNullOrEmptyRule<string> { Message = "Password is required!" });
        }





    }
}
