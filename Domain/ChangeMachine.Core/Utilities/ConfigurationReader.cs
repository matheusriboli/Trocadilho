using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace ChangeMachine.Core.Utilities {
    class ConfigurationReader {

        static ConfigurationReader thisObj;
        public string LogFile { get; }
        private ConfigurationReader() {
           this.LogFile = ConfigurationManager.AppSettings["LogFilePath"];
        }

        public static ConfigurationReader GetInstance() {
            if(thisObj == null)
                thisObj = new ConfigurationReader();
            return thisObj;
        }
    }
}
