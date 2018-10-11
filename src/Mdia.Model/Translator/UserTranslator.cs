using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class UserTranslator : BaseTranslator<User, USER>
    {
        private RoleTranslator _roleTranslator;

        public UserTranslator()
        {
            _roleTranslator = new Translator.RoleTranslator();
        }

        public override User TranslateToModel(USER entity)
        {
            try
            {
                User model = null;
                if (entity != null)
                {
                    model = new User();
                    model.Id = entity.User_Id;
                    model.FirstName = entity.First_Name;
                    model.Surname = entity.Surname;
                    model.PasswordSalt = entity.Password_Salt;
                    model.Email = entity.Email;
                    model.MobileNumber = entity.Mobile;
                    model.Password = entity.Password;
                    model.Role = _roleTranslator.Translate(entity.ROLE);
                    model.IsLocked = entity.Is_Locked;
                    model.DateCreated = entity.Date_Created;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override USER TranslateToEntity(User model)
        {
            try
            {
                USER entity = null;
                if (model != null)
                {
                    entity = new USER();
                    entity.User_Id = model.Id;
                    entity.First_Name = model.FirstName;
                    entity.Surname = model.Surname;
                    entity.Password_Salt = model.PasswordSalt;
                    entity.Email = model.Email;
                    entity.Mobile = model.MobileNumber;
                    entity.Password = model.Password;
                    entity.Role_Id = model.Role.Id;
                    entity.Is_Locked = model.IsLocked;
                    entity.Date_Created = model.DateCreated;
                }

                return entity;
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
