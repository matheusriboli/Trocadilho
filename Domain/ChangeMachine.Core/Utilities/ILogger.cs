using System;

namespace ChangeMachine.Core.Utilities {
    public interface ILogger {
        void LogDebug(CategoryEnum category, object obj);
        void LogException(Exception exception);
        void LogInfo(CategoryEnum category, object obj);
        void LogWarning(CategoryEnum category, object obj);
    }
}