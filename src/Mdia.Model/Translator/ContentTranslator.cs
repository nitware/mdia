using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class ContentTranslator : BaseTranslator<Content, CONTENT>
    {
        private UserTranslator _userTranslator;
        private ContentTypeTranslator _contentTypeTranslator;

        public ContentTranslator()
        {
            _userTranslator = new Translator.UserTranslator();
            _contentTypeTranslator = new Translator.ContentTypeTranslator();
        }

        public override Content TranslateToModel(CONTENT entity)
        {
            try
            {
                Content model = null;
                if (entity != null)
                {
                    model = new Content();
                    model.Id = entity.Content_Id;
                    model.Title = entity.Title;
                    model.Description = entity.Description;
                    model.DateUploaded = entity.Date_Uploaded;
                    model.Uploader = _userTranslator.Translate(entity.USER);
                    model.Type = _contentTypeTranslator.Translate(entity.CONTENT_TYPE);
                    model.Cost = entity.Cost;
                    model.Approved = entity.Approved;
                    model.Approver = _userTranslator.Translate(entity.USER1);
                    model.URL = entity.URL;
                    model.Size = entity.Size;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override CONTENT TranslateToEntity(Content model)
        {
            try
            {
                CONTENT entity = null;
                if (model != null)
                {
                    entity = new CONTENT();
                    entity.Content_Id = model.Id;
                    entity.Title = model.Title;
                    entity.Description = model.Description;
                    entity.Date_Uploaded = model.DateUploaded;
                    entity.Uploader_Id = model.Uploader.Id;
                    entity.Content_Type_Id = model.Type.Id;
                    entity.Cost = model.Cost;
                    entity.Approved = model.Approved;
                    entity.URL = model.URL;
                    entity.Size = model.Size;

                    if (model.Approver != null)
                    {
                        entity.Approver_Id = model.Approver.Id;
                    }
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
