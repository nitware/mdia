using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class ContentTypeTranslator : BaseTranslator<ContentType, CONTENT_TYPE>
    {
        public override ContentType TranslateToModel(CONTENT_TYPE entity)
        {
            try
            {
                ContentType model = null;
                if (entity != null)
                {
                    model = new ContentType();
                    model.Id = entity.Content_Type_Id;
                    model.Name = entity.Content_Type_Name;
                    model.Description = entity.Content_Type_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override CONTENT_TYPE TranslateToEntity(ContentType model)
        {
            try
            {
                CONTENT_TYPE entity = null;
                if (model != null)
                {
                    entity = new CONTENT_TYPE();
                    entity.Content_Type_Id = model.Id;
                    entity.Content_Type_Name = model.Name;
                    entity.Content_Type_Description = model.Description;
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
