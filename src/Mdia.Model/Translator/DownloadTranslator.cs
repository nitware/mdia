using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class DownloadTranslator : BaseTranslator<Download, DOWNLOAD>
    {
        private ContentTranslator _contentTranslator;
        private PaymentTranslator _paymentTranslator;

        public DownloadTranslator()
        {
            _contentTranslator = new ContentTranslator();
            _paymentTranslator = new Translator.PaymentTranslator();
        }

        public override Download TranslateToModel(DOWNLOAD entity)
        {
            try
            {
                Download model = null;
                if (entity != null)
                {
                    model = new Download();
                    model.Id = entity.Download_Id;
                    model.Content = _contentTranslator.Translate(entity.CONTENT);
                    model.Payment = _paymentTranslator.Translate(entity.PAYMENT);
                    model.Date = entity.Date;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override DOWNLOAD TranslateToEntity(Download model)
        {
            try
            {
                DOWNLOAD entity = null;
                if (model != null)
                {
                    entity = new DOWNLOAD();
                    entity.Download_Id = model.Id;
                    entity.Content_Id = model.Content.Id;
                    entity.Payment_Id = model.Payment.Id;
                    entity.Date = model.Date;
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
