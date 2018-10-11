using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class RoleTranslator : BaseTranslator<Role, ROLE>
    {
        private RightTranslator rightTranslator;

        public RoleTranslator()
        {
            rightTranslator = new RightTranslator();
        }

        public override Role TranslateToModel(ROLE entity)
        {
            try
            {
                Role model = null;
                if (entity != null)
                {
                    model = new Role();
                    model.Id = entity.Role_Id;
                    model.Name = entity.Role_Name;
                    model.Description = entity.Role_Description;

                    model.Rights = rightTranslator.TranslateToModel(entity.ROLE_RIGHT);
                    model.UserRight = new UserRight();
                    model.UserRight.Rights = model.Rights;
                    model.UserRight.Set();
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ROLE TranslateToEntity(Role model)
        {
            try
            {
                ROLE entity = null;
                if (model != null)
                {
                    entity = new ROLE();
                    entity.Role_Id = model.Id;
                    entity.Role_Name = model.Name;
                    entity.Role_Description = model.Description;
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
