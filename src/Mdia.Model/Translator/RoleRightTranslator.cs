using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class RoleRightTranslator : BaseTranslator<RoleRight, ROLE_RIGHT>
    {
        private RoleTranslator roleTranslator;
        private RightTranslator rightTranslator;

        public RoleRightTranslator()
        {
            roleTranslator = new RoleTranslator();
            rightTranslator = new RightTranslator();
        }

        public override RoleRight TranslateToModel(ROLE_RIGHT entity)
        {
            try
            {
                RoleRight model = null;
                if (entity != null)
                {
                    model = new RoleRight();
                    model.Role = roleTranslator.Translate(entity.ROLE);
                    model.Right = rightTranslator.Translate(entity.RIGHT);
                    model.Description = entity.Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override ROLE_RIGHT TranslateToEntity(RoleRight model)
        {
            try
            {
                ROLE_RIGHT entity = null;
                if (model != null)
                {
                    entity = new ROLE_RIGHT();
                    entity.Role_Id = model.Role.Id;
                    entity.Right_Id = model.Right.Id;
                    entity.Description = model.Description;
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
