using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Endterm
{
    public static class Bootstrapper
    {
        public static void SetupContainer(IUnityContainer container)
        {
            container.RegisterType<IOperation, Currency>("Currency")
                .RegisterType<IOperation, Loan>("Loan")
                .RegisterType<IOperation, Location>("Location");
        }
    }
}
