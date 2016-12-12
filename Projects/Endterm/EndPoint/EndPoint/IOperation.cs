using Messaging;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPoint
{
    public interface IOperation
    {
        void Response();
        void Parser( Message msg );
    }
}
