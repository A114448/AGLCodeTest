using System.Diagnostics;

namespace SampleApplication
{
    public class LogError : SampleApplication.ILogError
    {
        public void WriteEventLogEntry(string message)
        {            
            System.Diagnostics.EventLog eventLog = new System.Diagnostics.EventLog();

            if (!System.Diagnostics.EventLog.SourceExists("SampleApplication"))
            {
                System.Diagnostics.EventLog.CreateEventSource("SampleApplication", "Application");
            }
            eventLog.Source = "SampleApplication";
            int eventID = 8;
            eventLog.WriteEntry(message, System.Diagnostics.EventLogEntryType.Error, eventID);
            eventLog.Close();
        }
    }
}