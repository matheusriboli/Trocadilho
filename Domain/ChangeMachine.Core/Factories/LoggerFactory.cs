using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Utilities;
using Dlp.Framework.Container;

namespace ChangeMachine.Core.Factories {
    class LoggerFactory {

        public static ILogger GetLogger() {
            ConfigurationReader configReader = ConfigurationReader.GetInstance();
            if (configReader.LogType == "File") {
                return IocFactory.ResolveByName<ILogger>("Log_file");
            }
            return IocFactory.ResolveByName<ILogger>("Event_viewer");
        }

        }
}
