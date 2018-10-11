using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Mobile.Validations
{
    public interface IValidationRule<T>
    {
        bool Check(T value);
        string Message { get; set; }
                
    }

}
