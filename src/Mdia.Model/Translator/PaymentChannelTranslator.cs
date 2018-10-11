using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;

namespace Mdia.Model.Translator
{
    public class PaymentChannelTranslator : BaseTranslator<PaymentChannel, PAYMENT_CHANNEL>
    {
        public override PaymentChannel TranslateToModel(PAYMENT_CHANNEL entity)
        {
            try
            {
                PaymentChannel model = null;
                if (entity != null)
                {
                    model = new PaymentChannel();
                    model.Id = entity.Payment_Channel_Id;
                    model.Name = entity.Payment_Channel_Name;
                    model.Description = entity.Payment_Channel_Description;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PAYMENT_CHANNEL TranslateToEntity(PaymentChannel model)
        {
            try
            {
                PAYMENT_CHANNEL entity = null;
                if (model != null)
                {
                    entity = new PAYMENT_CHANNEL();
                    entity.Payment_Channel_Id = model.Id;
                    entity.Payment_Channel_Name = model.Name;
                    entity.Payment_Channel_Description = model.Description;
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
