using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Model.Translator
{
    public class TranslatorFactory
    {
        public static dynamic Create(string typeName)
        {
            try
            {
                typeName = typeName.Replace("_", "").ToLower();
                switch (typeName)
                {
                    case "content":
                        {
                            return new ContentTranslator();
                        }
                    case "contenttype":
                        {
                            return new ContentTypeTranslator();
                        }
                    case "download":
                        {
                            return new DownloadTranslator();
                        }
                    case "payment":
                        {
                            return new PaymentTranslator();
                        }
                    case "paymentchannel":
                        {
                            return new PaymentChannelTranslator();
                        }
                    case "paymentmode":
                        {
                            return new PaymentModeTranslator();
                        }
                    case "role":
                        {
                            return new RoleTranslator();
                        }
                    case "user":
                        {
                            return new UserTranslator();
                        }

                    //case "persontype":
                    //    {
                    //        return new PersonTypeTranslator();
                    //    }
                    //case "right":
                    //    {
                    //        return new RightTranslator();
                    //    }
                    //case "roleright":
                    //    {
                    //        return new RoleRightTranslator();
                    //    }
                    //case "securityquestion":
                    //    {
                    //        return new SecurityQuestionTranslator();
                    //    }
                    //case "sex":
                    //    {
                    //        return new SexTranslator();
                    //    }
                 
                    default:
                        {
                            throw new NotImplementedException(typeName + " Translator not implemented!");
                        }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }




    }
}
