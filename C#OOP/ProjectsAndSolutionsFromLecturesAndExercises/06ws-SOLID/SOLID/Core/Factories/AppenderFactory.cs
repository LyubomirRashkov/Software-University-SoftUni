using SOLID.Appenders;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;

namespace SOLID.Core.Factories
{
    public class AppenderFactory : IAppenderFactory
    {
        public IAppender CreateAppender(string type, ILayout layout, ReportLevel reportLevel)
        {
            IAppender appender;

            if (type == nameof(ConsoleAppender))
            {
                appender = new ConsoleAppender(layout)
                {
                    ReportLevel = reportLevel
                };
            }
            else if (type == nameof(FileAppender))
            {
                appender = new FileAppender(layout, new LogFile())
                {
                    ReportLevel = reportLevel
                };
            }
            else
            {
                throw new ArgumentException($"{type} is invalid Appender type!");
            }

            return appender;
        }
    }
}
