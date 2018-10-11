using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Mdia.Entity;
using Mdia.Model.Model;


namespace Mdia.Model.Translator
{
    public class PaymentTranslator : BaseTranslator<Payment, PAYMENT>
    {
        private UserTranslator _userTranslator;
        private PaymentChannelTranslator _paymentChannelTranslator;
        private PaymentModeTranslator _paymentModeTranslator;

        public PaymentTranslator()
        {
            _userTranslator = new UserTranslator();
            _paymentModeTranslator = new Translator.PaymentModeTranslator();
            _paymentChannelTranslator = new Translator.PaymentChannelTranslator();
        }

        public override Payment TranslateToModel(PAYMENT entity)
        {
            try
            {
                Payment model = null;
                if (entity != null)
                {
                    model = new Payment();
                    model.Id = entity.Payment_Id;
                    model.Mode = _paymentModeTranslator.Translate(entity.PAYMENT_MODE);
                    model.Channel = _paymentChannelTranslator.Translate(entity.PAYMENT_CHANNEL);
                    model.User = _userTranslator.Translate(entity.USER);
                    model.SerialNumber = entity.Serial_Number;
                    model.InvoiceNumber = entity.Invoice_Number;
                    model.Paid = entity.Paid;
                    model.DatePaid = entity.Date_Paid;
                }

                return model;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public override PAYMENT TranslateToEntity(Payment model)
        {
            try
            {
                PAYMENT entity = null;
                if (model != null)
                {
                    entity = new PAYMENT();
                    entity.Payment_Id = model.Id;
                    entity.Payment_Mode_Id = model.Mode.Id;
                    entity.Payment_Channel_Id = model.Channel.Id;
                    entity.User_Id = model.User.Id;
                    entity.Serial_Number = model.SerialNumber;
                    entity.Invoice_Number = model.InvoiceNumber;
                    entity.Paid = model.Paid;
                    entity.Date_Paid = model.DatePaid;
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
