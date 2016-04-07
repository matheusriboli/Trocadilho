using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Utilities;

namespace ChangeMachine.Core.Factories {
    class LoggerFactory {

        public static ILogger GetLogger() {
            ConfigurationReader configReader = ConfigurationReader.GetInstance();
            if (configReader.LogType == "File") {
                return FileLogger.GetInstance();
            }
            return EventViewerLogger.GetInstance();
        }

        }
}
