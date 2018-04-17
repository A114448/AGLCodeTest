using System;
namespace SampleApplication
{
   public interface ILogError
    {
        void WriteEventLogEntry(string message);
    }
}
