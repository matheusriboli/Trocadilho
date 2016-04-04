using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeMachine.Core.Utilities {
    class Logger {
        static Logger thisObj;
        private Logger() {
        }
        public static Logger GetInstance() {
            if (Logger.thisObj == null) {
                Logger.thisObj = new Logger();
            }            
            return Logger.thisObj;
        }

        public void LogException(CategoryEnum category, string message) {

        }
        public void LogInfo(CategoryEnum category, string message) {

        }
        public void LogWarning(CategoryEnum category, string message) {

        }
        public void LogDebug(CategoryEnum category, string message) {

        }
    } 
}
