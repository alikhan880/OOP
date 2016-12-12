using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EndPoint
{
    public static class Bootstrapper
    {
        public static void SetupContainer(IUnityContainer container)
        {
            container.RegisterType<IOperation, TestCurrency>("Currency")
                .RegisterType<IOperation, TestLoan>("Loan")
                .RegisterType<IOperation, TestLocation>("Location");
        }
    }
}
