using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChangeMachine.Core.Utilities;

namespace ChangeMachine.Core.Test {
        class StubLogger : ILogger {
        public void LogDebug(CategoryEnum category, object obj) {

        }

        public void LogException(Exception exception) {

        }

        public void LogInfo(CategoryEnum category, object obj) {

        }

        public void LogWarning(CategoryEnum category, object obj) {

        }
    }
}
