using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace ChangeMachine.Core.Utilities {
    class EventViewerLogger : ILogger {
        static EventViewerLogger thisObj;
        const string SOURCE = "Trocadilho";
        private EventViewerLogger() { }
        public static EventViewerLogger GetInstance() {
            if (EventViewerLogger.thisObj == null) {
                EventViewerLogger.thisObj = new EventViewerLogger();
            }
            return EventViewerLogger.thisObj;
        }
        public void LogDebug(CategoryEnum category, object obj) {
            this.WriteMessage($"[DEBUG][{category}]: {JsonConvert.SerializeObject(obj)}", EventLogEntryType.Information);
        }

        public void LogException(Exception exception) {
            this.WriteMessage($"[EXCEPTION]: {exception.ToString()}", EventLogEntryType.Error);
        }

        public void LogInfo(CategoryEnum category, object obj) {
            this.WriteMessage($"[INFO][{category}]: {JsonConvert.SerializeObject(obj)}", EventLogEntryType.Information);
        }

        public void LogWarning(CategoryEnum category, object obj) {
            this.WriteMessage($"[WARNING][{category}]: {JsonConvert.SerializeObject(obj)}", EventLogEntryType.Warning);
        }

        private void WriteMessage(string message, EventLogEntryType entrytype) {
            
            if (!EventLog.SourceExists(SOURCE)) {
                EventLog.CreateEventSource(SOURCE, "Application");
            }
            EventLog.WriteEntry(SOURCE, message, entrytype);
        }
    }
}
