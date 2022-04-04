using SOLID.Enums;
using SOLID.Layouts;
using SOLID.Loggers;
using System;

namespace SOLID.Appenders
{
    public class FileAppender : Appender
    {
        private readonly ILogFile logFile;

        public FileAppender(ILayout layout, ILogFile logFile) 
            : base(layout)
        {
            this.logFile = logFile;
        }

        public override void Append(string date, ReportLevel reportLevel, string message)
        {
            if (!this.CanAppend(reportLevel))
            {
                return;     // т.е. не прави нищо
            }

            string content = string.Format(this.layout.Template, date, reportLevel, message) + Environment.NewLine;

            this.logFile.Write(content);

            this.MessagesCount++;

            /* 
             Като пишем във файла през Write() на logFile-а караме класа FileAppender да прави едно нещо - да append-ва. Ако пишем
             директно през Append() на FileAppender-а чрез File.AppendAllText("../../../log.txt", content) класът FileAppender
             ще прави две неща:
             1) append-ва;
             2) грижи се да работи с определен файл.
            
             Сега FileAppender генерира съобщение, което го append-ва към съответния logFile, а той пише съобщението във файла
            */


        }

        public override string ToString()
        {
            return base.ToString() + $", File size: {this.logFile.Size}";
        }
    }
}
