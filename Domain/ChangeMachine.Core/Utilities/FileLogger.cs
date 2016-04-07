using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ChangeMachine.Core.Utilities {
    class FileLogger : ILogger {
        static FileLogger thisObj;
        private FileLogger() { }
        public static FileLogger GetInstance() {
            if (FileLogger.thisObj == null) {
                FileLogger.thisObj = new FileLogger();
            }
            return FileLogger.thisObj;
        }

        public void LogException(Exception exception) {
            this.WriteMessage($"[EXCEPTION]: {exception.ToString()}");
        }
        public void LogInfo(CategoryEnum category, object obj) {
            this.WriteMessage($"[INFO][{category}]: {JsonConvert.SerializeObject(obj)}");
        }
        public void LogWarning(CategoryEnum category, object obj) {
            this.WriteMessage($"[WARNING][{category}]: {JsonConvert.SerializeObject(obj)}");
        }
        public void LogDebug(CategoryEnum category, object obj) {
            this.WriteMessage($"[DEBUG][{category}]: {JsonConvert.SerializeObject(obj)}");
        }
        private void WriteMessage(string msg) {
            ConfigurationReader configReader = ConfigurationReader.GetInstance();
            try {
                using (StreamWriter writer = File.AppendText(configReader.LogFile)) {
                    writer.WriteLine($"{DateTime.Now}: {msg}");
                }
            }
            catch (Exception) { }

            //StreamWriter writer = null;
            //try {
            //    writer = File.CreateText(configReader.GetConfigLogFileName());
            //    writer.Write("...");
            //    writer.Close ()
            //}
            //catch {
            //    if (writer != null) { writer.Close(); }
            //    throw;
            //}
        }
    }
}
