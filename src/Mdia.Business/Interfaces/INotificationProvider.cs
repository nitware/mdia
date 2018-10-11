using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mdia.Business.Interfaces
{
    public interface INotificationProvider<T, TResult>
    {
        TResult Send(T t);
    }


}
