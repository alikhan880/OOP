using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoggerDependency {
    public interface ILoggerDependency {
        string GetCurrentDirectory();
        string GetDiretoryByLoggerName( string loggerName );
        string DefaultLogger {
            get;
        }
    }

    class Program {
        static void Main( string[] args ) {
            ILoggerDependency lgDepend = Mock
        }

    }
}
