using SOLID.Appenders;
using SOLID.Core.Factories;
using SOLID.Core.IO;
using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;

namespace SOLID.Core
{
    public class Engine : IEngine
    {
        private readonly IAppenderFactory appenderFactory;
        private readonly ILayoutFactory layoutFactory;
        private readonly IReader reader;

        private ILogger logger;

        public Engine(IAppenderFactory appenderFactory, ILayoutFactory layoutFactory, IReader reader)
        {
            this.appenderFactory = appenderFactory;
            this.layoutFactory = layoutFactory;
            this.reader = reader;
        }

        public void Run()
        {
            int numberOfAppenders = int.Parse(this.reader.ReadLine());

            IAppender[] appenders = this.ReadAppenders(numberOfAppenders);

            this.logger = new Logger(appenders);

            while (true)
            {
                string line = this.reader.ReadLine();

                if (line == "END")
                {
                    break;
                }

                string[] parts = line.Split('|', StringSplitOptions.RemoveEmptyEntries);

                ReportLevel reportLevel = Enum.Parse<ReportLevel>(parts[0], true);
                string date = parts[1];
                string message = parts[2];

                this.ProcessCommand(reportLevel, date, message);
            }

            Console.WriteLine("Logger info");

            Console.WriteLine(logger);
        }

        private void ProcessCommand(ReportLevel reportLevel, string date, string message)
        {
            if (reportLevel == ReportLevel.INFO)
            {
                this.logger.Info(date, message);
            }
            else if (reportLevel == ReportLevel.WARNING)
            {
                this.logger.Warning(date, message);
            }
            else if (reportLevel == ReportLevel.ERROR)
            {
                this.logger.Error(date, message);
            }
            else if (reportLevel == ReportLevel.CRITICAL)
            {
                this.logger.Critical(date, message);
            }
            else if (reportLevel == ReportLevel.FATAL)
            {
                this.logger.Fatal(date, message);
            }
        }

        private IAppender[] ReadAppenders(int numberOfAppenders)
        {
            IAppender[] appenders = new IAppender[numberOfAppenders];

            for (int i = 0; i < numberOfAppenders; i++)
            {
                string[] appenderParts = this.reader.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string appederType = appenderParts[0];
                string layoutType = appenderParts[1];

                ILayout layout = this.layoutFactory.CreateLayout(layoutType);

                ReportLevel reportLevel = appenderParts.Length == 3
                    ? Enum.Parse<ReportLevel>(appenderParts[2], true)
                    : ReportLevel.INFO;

                IAppender appender = this.appenderFactory.CreateAppender(appederType, layout, reportLevel);

                appenders[i] = appender;
            }

            return appenders;
        }
    }
}
